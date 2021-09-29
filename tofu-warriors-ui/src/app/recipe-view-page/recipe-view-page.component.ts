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
    });
   }

  ngOnDestroy(): void {
    this.recipeSubscription?.unsubscribe();
  }

  ngOnChanges(): void {
    this.currentUser = this.usersService.getCurrentUser();
    if (!this.currentUser) {
      this.recipeEditable = false;
    } else if (!this.recipe) {
      this.recipeEditable = false;
    } else if (this.currentUser.userId == null || this.currentUser.userId !== this.recipe.creatorUserId) {
      this.recipeEditable = false;
    } else {
      this.recipeEditable = true;
    }
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
