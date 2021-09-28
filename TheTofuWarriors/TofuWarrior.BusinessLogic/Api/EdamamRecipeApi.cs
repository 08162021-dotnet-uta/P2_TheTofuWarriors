using System;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Diagnostics;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TofuWarrior.BusinessLogic.Api
{
    public class EdamamRecipeApi
    {
        private readonly IHttpClientFactory _clientFactory;
        public EdamamRecipeApi(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<EdamamRecipeModel> SearchRecipeAsync(string keyword)
        {
            string url = $"https://edamam-recipe-search.p.rapidapi.com/search?q={keyword}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("x-rapidapi-host", "edamam-recipe-search.p.rapidapi.com");
            request.Headers.Add("x-rapidapi-key", "5d31783a98msh437c1f02f7cf668p10a870jsn85d41044eaa6");

            var client = _clientFactory.CreateClient();
            var response = client.Send(request);

            if (response.IsSuccessStatusCode)
            {
                string resJsonStr = await response.Content.ReadAsStringAsync();
                Trace.WriteLine(resJsonStr);
                return JsonConvert.DeserializeObject<EdamamRecipeModel>(resJsonStr);
            }
            return null;
        }
    }

   
}