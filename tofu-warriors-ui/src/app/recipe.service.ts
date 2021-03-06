import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { Recipe } from './recipe';
import { User } from './user';
import { UsersService } from './users.service';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {

  constructor(
    private httpClient: HttpClient,
  ) { }

  private jsonHeader = new HttpHeaders({
    "Content-Type": "application/json"
  });
  apiUrl: string = environment.tofuWarriorsApiUrl;

  getRecipesCreatedBy(userId: number): Observable<Recipe[]> {
    return this.httpClient.get<Recipe[]>(`${this.apiUrl}/User/${userId}/recipes`);
  }

  getRecipeById(recipeId: number): Observable<Recipe> {
    return this.httpClient.get<Recipe>(`${this.apiUrl}/Recipe/GetRecipeById?id=${recipeId}`);
  }

  //get the recipe list
  getRecipeList():Observable<Recipe[]>{
    return this.httpClient.get<Recipe[]>(`${this.apiUrl}/Recipe/GetAllRecipes`);
  }
  
  searchRecipesByName(name: string): Observable<Recipe[]> {
    return this.httpClient.get<Recipe[]>(`${this.apiUrl}/Recipe/SearchByIngredientName/${name}`);
  }

  searchRecipes(terms: string[], tags: any[]): Observable<Recipe[]> {
    return this.httpClient.post<Recipe[]>(`${this.apiUrl}/Recipe/Search`, { terms, tags }, { headers: this.jsonHeader });
  }

  saveUserRecipe(recipe: Recipe, user: User) {

    return this.httpClient.post<Recipe>(`${this.apiUrl}/Recipe/SaveUserRecipe`, { recipe, user }, { headers: this.jsonHeader });
  }
}
