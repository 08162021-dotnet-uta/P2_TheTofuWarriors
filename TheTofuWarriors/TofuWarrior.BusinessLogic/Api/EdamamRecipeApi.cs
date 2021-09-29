using System;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Diagnostics;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Collections.Specialized;
using System.Web;
using Microsoft.Extensions.Logging;
using TheTofuWarrior.Model.ViewModels;

namespace TofuWarrior.BusinessLogic.Api
{
    public class EdamamRecipeApi
    {
        private readonly IHttpClientFactory _clientFactory;
		private readonly IConfiguration _config;
		private ILogger<EdamamRecipeApi> _logger;
        public EdamamRecipeApi(IConfiguration config, IHttpClientFactory clientFactory, ILogger<EdamamRecipeApi> logger)
        {
            _clientFactory = clientFactory;
			_config = config;
			_logger = logger;
        }
        public async Task<EdamamRecipeModel> SearchRecipeAsync(List<string> keywords, List<ViewModelTag> tags)
        {
			//string url = $"https://edamam-recipe-search.p.rapidapi.com/search?q={keyword}";
			string baseUrl = _config["EdamamAPIEndpoint"];
			string appId = _config["EdamamAppId"];
			string apiKey = _config["EdamamAPIKey"];

			_logger.LogDebug("Url: {0}", baseUrl);
			_logger.LogDebug("app id: {0}", appId);
			_logger.LogDebug("api key: {0}", apiKey);

			var uri = new UriBuilder(baseUrl);
			var queryParams = HttpUtility.ParseQueryString("");
			queryParams["type"] = "public";
			queryParams["app_id"] = appId;
			queryParams["app_key"] = apiKey;
			queryParams["q"] = string.Join<string>(",", keywords);

			var additionalParams = BuildQueryParamsFromTags(tags);
			var allParams = queryParams.ToString() + additionalParams;
			_logger.LogDebug("Query params: {0}", allParams);
			uri.Query = allParams;
			var url = uri.ToString();

			try
			{
				var useCachedResult = bool.Parse(_config["EdamamUseFakeRequest"]);
				_logger.LogInformation("useCachedResult: {0}", useCachedResult);
				if (useCachedResult)
				{
					var cachedJsonStr = File.ReadAllText("./cachedResponse.json");
					return JsonConvert.DeserializeObject<EdamamRecipeModel>(cachedJsonStr);
				}

			} catch (Exception e)
			{
				// configuration not set, or failed to use cached result. continue on as normal.
				_logger.LogError("Encountered error using cached API result {0}", e);
			}

			_logger.LogInformation("sending edamam api request: {0}", url.ToString());
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            //request.Headers.Add("x-rapidapi-host", "edamam-recipe-search.p.rapidapi.com");
            //request.Headers.Add("x-rapidapi-key", "5d31783a98msh437c1f02f7cf668p10a870jsn85d41044eaa6");

            var client = _clientFactory.CreateClient();
            var response = client.Send(request);

            if (response.IsSuccessStatusCode)
            {
                string resJsonStr = await response.Content.ReadAsStringAsync();
				//Trace.WriteLine(resJsonStr);
				_logger.LogDebug(resJsonStr);
				//File.WriteAllText("./cachedResponse.json", resJsonStr);
                return JsonConvert.DeserializeObject<EdamamRecipeModel>(resJsonStr);
            } else
			{
				_logger.LogError(response.ToString());
			}
            return null;
        }

		public static string BuildQueryParamsFromTags(List<ViewModelTag> tags)
		{
			Dictionary<int, List<string>> newParams = new();
			var validTagTypes = ApiTagTypes.GetValidTypeIds();
			foreach (var typeId in validTagTypes)
			{
				newParams[typeId] = new List<string>();
			}

			foreach (var tag in tags)
			{
				if (tag.TagType == null || !validTagTypes.Contains((int) tag.TagType))
				{
					throw new ArgumentException($"Invalid tag type given in search params: '{tag.TagType}'");
				}
				int typeId = (int)tag.TagType;
				if (!ApiTagTypes.IsValidLabel(typeId, tag.Name))
				{
					throw new ArgumentException($"Invalid tag type value '{tag.Name}' given in search params for type '{typeId}'");
				}
				newParams[typeId].Add(tag.Name);
			}
			var result = "";
			foreach (var (typeId, vals) in newParams)
			{
				if (vals.Count == 0) { continue; }
				var label = ApiTagTypes.GetQueryParamForType(typeId);
				foreach (var val in vals)
				{
					result += $"&{label}={val}";
				}
			}
			return result;
		}
    }

   
}