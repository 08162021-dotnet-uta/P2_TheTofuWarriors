import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Recipe } from '../recipe';
import { RecipePageDataService } from '../recipe-page-data.service';
import { RecipeService } from '../recipe.service';
import { User } from '../user';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-recipe-edit-page',
  templateUrl: './recipe-edit-page.component.html',
  styleUrls: ['./recipe-edit-page.component.css']
})
export class RecipeEditPageComponent implements OnInit {

  constructor(
    private recipePageData: RecipePageDataService,
    private recipeService: RecipeService,
    private users: UsersService,
    private location: Location,
    private router: Router
  ) { }

  subscriptions: Subscription[] = [];
  recipe: Recipe | null = null;
  currentUser: User | null = null;

  ngOnInit(): void {
    this.currentUser = this.users.getCurrentUser();
    this.subscriptions.push(this.recipePageData.subscribeToRecipe((recipe) => {
      console.log("Recipe view page: ", recipe);
      this.recipe = recipe;
    }));
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(s => s.unsubscribe());
  }

  saveChanges(shouldSave: boolean): void {
    if (!shouldSave) {
      this.location.back();
      return;
    }
    if (!this.recipe) {
      // this really shouldn't be possible... the button shouldn't show up if there isn't a recipe
      throw new Error("No recipe data found");
    }
    if (!this.currentUser) {
      throw new Error("Must be logged in to edit recipe");
    }
    this.subscriptions.push(this.recipeService.saveUserRecipe(this.recipe, this.currentUser).subscribe(recipe => {
      this.recipe = recipe;
      let dest = `/recipies/${recipe.recipeId}/view`;
      this.router.navigate([dest], { replaceUrl: true });
      //this.location.replaceState(dest);
    }));
  }

}
