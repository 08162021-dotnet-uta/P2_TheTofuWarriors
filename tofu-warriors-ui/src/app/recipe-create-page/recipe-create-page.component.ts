import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Recipe } from '../recipe';
import { User } from '../user';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-recipe-create-page',
  templateUrl: './recipe-create-page.component.html',
  styleUrls: ['./recipe-create-page.component.css']
})
export class RecipeCreatePageComponent implements OnInit {

  constructor(
    private location: Location,
    private users: UsersService,
  ) {
    this.currentUser = this.users.getCurrentUser();
    this.recipe = {
      recipeId: 0,
      apiKey: "",
      creationTime: new Date(),
      creator: this.currentUser,
      creatorUserId: this.currentUser?.userId || 0,
      imageUrl: "",
      ingredients: [],
      instructions: "",
      isExternal: false,
      name: "",
      tags: []
    }
  }

  baseRecipe: Recipe | null = null;
  currentUser: User | null;
  recipe: Recipe;

  ngOnInit(): void {
    // get baseRecipe from state location (set by page that navigated here)
    let state = this.location.getState() as { baseRecipe: Recipe };
    console.log("nav: ", state);
    this.baseRecipe = state.baseRecipe;
    if (this.baseRecipe) this.populateRecipeFromBase(this.baseRecipe);
  }

  populateRecipeFromBase(base: Recipe) {
    let valuesToCopy = {
      recipeId: base.recipeId,
      apiKey: base.apiKey,
      imageUrl: base.imageUrl,
      ingredients: [ ...base.ingredients ],
      instructions: base.instructions,
      name: base.name,
      tags: [...base.tags]
    }
    this.recipe = { ...this.recipe, ...valuesToCopy };
    console.log("cloned recipe: ", this.recipe);
  }

  saveRecipe(): void {
    console.log("Saving", this.recipe);
  }
}
