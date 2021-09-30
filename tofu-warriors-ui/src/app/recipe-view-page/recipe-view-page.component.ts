import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from "@angular/common";
import { Recipe } from '../recipe';
import { RecipeService } from '../recipe.service';
import { User } from '../user';
import { UsersService } from '../users.service';
import { RecipePageDataService } from '../recipe-page-data.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-recipe-view-page',
  templateUrl: './recipe-view-page.component.html',
  styleUrls: ['./recipe-view-page.component.css']
})
export class RecipeViewPageComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private usersService: UsersService,
    private location: Location,
    private recipePageData: RecipePageDataService,
    private router: Router
  ) { }

  recipe: Recipe | null = null;
  currentUser: User | null = null;

  recipeEditable: boolean = false;

  private recipeSubscription: Subscription | null = null;

  ngOnInit(): void {
   this.recipeSubscription = this.recipePageData.subscribeToRecipe((recipe) => {
      console.log("Recipe view page: ", recipe);
      this.recipe = recipe;
      this.updateExtraInfo();
    });
   }

  ngOnDestroy(): void {
    this.recipeSubscription?.unsubscribe();
  }

  updateExtraInfo(): void {
    this.currentUser = this.usersService.getCurrentUser();
    if (!this.currentUser) {
      console.log("view updateExtraInfo 1");
      this.recipeEditable = false;
    } else if (!this.recipe) {
      console.log("view updateExtraInfo 2");
      this.recipeEditable = false;
    } else if (this.currentUser.userId == null || this.currentUser.userId !== this.recipe.creatorUserId) {
      console.log("view updateExtraInfo 3");
      this.recipeEditable = false;
    } else {
      console.log("view updateExtraInfo 4");
      this.recipeEditable = true;
    }
    console.log("view updateExtraInfo 5");
  }

  ngOnChanges(): void {
  }

  editRecipe(): void {
    console.log("Edit recipe");
    this.router.navigate(["../edit"], { relativeTo: this.route });
  }

  goBack(): void {
    this.location.back();
  }

  cloneRecipe(): void {
    console.log("Clone recipe");
    this.router.navigate(["../clone"], {
      relativeTo: this.route,
      state: { baseRecipe: this.recipe }
    });
  }

}
