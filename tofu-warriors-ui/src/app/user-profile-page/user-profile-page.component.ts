import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Recipe } from '../recipe';
import { RecipeService } from '../recipe.service';
import { User } from '../user';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-user-profile-page',
  templateUrl: './user-profile-page.component.html',
  styleUrls: ['./user-profile-page.component.css']
})
export class UserProfilePageComponent implements OnInit {

  constructor(
    private userService: UsersService,
    private recipeService: RecipeService,
    private route: ActivatedRoute
  ) {
  }

  user: User | null = null;
  recipes: Recipe[] = [];

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      console.log(params);
      this.userService.getUserById(params["userId"]).subscribe(user => {
        this.user = user;
        this.recipeService.getRecipesCreatedBy(user.userId)
          .subscribe(recipes => this.recipes = recipes);
      });
    })
  }

}
