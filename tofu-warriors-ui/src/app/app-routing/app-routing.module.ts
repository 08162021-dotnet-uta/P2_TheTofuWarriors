import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from '../login/login.component';
import { RecipeBasePageComponent } from '../recipe-base-page/recipe-base-page.component';
import { RecipeCreatePageComponent } from '../recipe-create-page/recipe-create-page.component';
import { RecipeEditPageComponent } from '../recipe-edit-page/recipe-edit-page.component';
import { RecipeSearchPageComponent } from '../recipe-search-page/recipe-search-page.component';
import { RecipeViewPageComponent } from '../recipe-view-page/recipe-view-page.component';
import { RecipesListComponent } from '../recipes-list/recipes-list.component';
import { SignupComponent } from '../signup/signup.component';
import { UserHomePageComponent } from '../user-home-page/user-home-page.component';
import { UserProfilePageComponent } from '../user-profile-page/user-profile-page.component';


const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'home', component: UserHomePageComponent },
  { path: 'recipeSearch', component: RecipeSearchPageComponent },
  { path: 'user/:userId/profile', component: UserProfilePageComponent },
  { path: 'recipies', component: RecipesListComponent },
  { path: 'recipies/create', component: RecipeCreatePageComponent },
  {
    path: 'recipies/:recipeId', component: RecipeBasePageComponent,
    children: [
      { path: 'view', component: RecipeViewPageComponent },
      { path: 'edit', component: RecipeEditPageComponent },
      { path: 'clone', component: RecipeCreatePageComponent }
    ]
  }
];

@NgModule({

  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
