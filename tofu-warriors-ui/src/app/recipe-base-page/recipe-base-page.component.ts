import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Recipe } from '../recipe';
import { RecipePageDataService } from '../recipe-page-data.service';
import { RecipeService } from '../recipe.service';
import { User } from '../user';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-recipe-base-page',
  templateUrl: './recipe-base-page.component.html',
  styleUrls: ['./recipe-base-page.component.css']
})
export class RecipeBasePageComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private recipePageData: RecipePageDataService,
    private usersService: UsersService,
    private location: Location
  ) {
  }

  recipe: Recipe | null = null;
  currentUser: User | null = null;
  recipeId: number = 0;
  currentView: string = "";

  private recipeSubscription: Subscription | null = null;

  ngOnInit(): void {
    let childRoute = this.route.firstChild;
    if (!childRoute) {
      this.location.go("view");
    }
    this.recipeSubscription = this.recipePageData.subscribeToRecipe((recipe) => {
      this.recipe = recipe;
      this.currentUser = this.usersService.getCurrentUser();
    });

    this.route.params.subscribe(params => {
      this.recipeId = params["recipeId"];
      if (!this.recipeId) {
        throw new Error("Valid RecipeId not provided");
      }
      this.recipePageData.setCurrentRecipe(this.recipeId);
    })
  }

  ngOnDestroy() {
    this.recipeSubscription?.unsubscribe();
    this.recipePageData.clear();
  }

}
