import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { Recipe } from './recipe';
import { UsersService } from './users.service';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {

  constructor(
    private httpClient: HttpClient,
  ) { }

  apiUrl: string = environment.tofuWarriorsApiUrl;

  getRecipesCreatedBy(userId: number): Observable<Recipe[]> {
    return this.httpClient.get<Recipe[]>(`${this.apiUrl}/User/${userId}/recipes`);
  }

  //get the recipe list
  getRecipeList():Observable<Recipe[]>{
    return this.httpClient.get<Recipe[]>(`${this.apiUrl}/Recipe/GetAllRecipes`);
  }
}
