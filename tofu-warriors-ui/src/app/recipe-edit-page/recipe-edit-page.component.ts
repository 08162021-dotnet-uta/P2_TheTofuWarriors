import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Recipe } from '../recipe';
import { RecipePageDataService } from '../recipe-page-data.service';

@Component({
  selector: 'app-recipe-edit-page',
  templateUrl: './recipe-edit-page.component.html',
  styleUrls: ['./recipe-edit-page.component.css']
})
export class RecipeEditPageComponent implements OnInit {

  constructor(
    private recipePageData: RecipePageDataService
  ) { }

  recipeSubscription: Subscription | null = null;
  recipe: Recipe | null = null;

  ngOnInit(): void {
   this.recipeSubscription = this.recipePageData.subscribeToRecipe((recipe) => {
      console.log("Recipe view page: ", recipe);
      this.recipe = recipe;
    });
  }

  ngOnDestroy(): void {
    this.recipeSubscription?.unsubscribe();
  }

}
