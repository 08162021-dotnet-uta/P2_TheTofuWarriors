import { Injectable } from '@angular/core';
import { Observer, PartialObserver, Subject, Subscription } from 'rxjs';
import { Recipe } from './recipe';
import { RecipeService } from './recipe.service';

@Injectable({
  providedIn: 'root'
})
export class RecipePageDataService {

  constructor(
    private recipeService: RecipeService,
  ) {
    this.recipeSubject = new Subject();
  }

  private recipeSubject: Subject<Recipe>;
  private currentRecipe: Recipe | null = null;

  subscribeToRecipe(subscriber: (value: Recipe) => void): Subscription {
    let sub: Subscription = this.recipeSubject.subscribe(subscriber);
    if (this.currentRecipe) subscriber(this.currentRecipe);
    return sub;
  }

  setCurrentRecipe(recipeId: number) {
    this.recipeService.getRecipeById(recipeId).subscribe(recipe => {
      this.currentRecipe = recipe;
      this.recipeSubject.next(recipe);
    });
  }

  clear() {
    this.currentRecipe = null;
  }

}
