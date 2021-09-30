import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { UserDisplayComponent } from './user-display/user-display.component';
import { UserHomePageComponent } from './user-home-page/user-home-page.component';
import { RecipeSearchPageComponent } from './recipe-search-page/recipe-search-page.component';

import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { FormsModule,FormControl,FormGroup } from '@angular/forms';
import { UserProfilePageComponent } from './user-profile-page/user-profile-page.component';
import { RecipeDisplayComponent } from './recipe-display/recipe-display.component';

import { RecipeCommentComponent } from './recipe-comment/recipe-comment.component';
import { AddCommentComponent } from './add-comment/add-comment.component';


import { RecipesListComponent } from './recipes-list/recipes-list.component';

import { RecipeSearchTagPickerComponent } from './recipe-search-tag-picker/recipe-search-tag-picker.component';
import { InflencerActivitiesComponent } from './inflencer-activities/inflencer-activities.component';
import { RecipeViewPageComponent } from './recipe-view-page/recipe-view-page.component';
import { RecipeEditPageComponent } from './recipe-edit-page/recipe-edit-page.component';
import { RecipeCreatePageComponent } from './recipe-create-page/recipe-create-page.component';
import { RecipeBasePageComponent } from './recipe-base-page/recipe-base-page.component';
import { RecipeEditComponent } from './recipe-edit/recipe-edit.component';
import { IngredientPickerComponent } from './ingredient-picker/ingredient-picker.component';
import { CommentDisplayComponent } from './comment-display/comment-display.component';
import { TagPickerComponent } from './tag-picker/tag-picker.component';

@NgModule({
  declarations: [
    AppComponent,
    UserDisplayComponent,
    LoginComponent,
    SignupComponent,
    
    UserHomePageComponent,
    RecipeSearchPageComponent,
    UserProfilePageComponent,
    RecipeDisplayComponent,
    RecipeCommentComponent,
    AddCommentComponent,


    RecipesListComponent,
    RecipeSearchTagPickerComponent,
    InflencerActivitiesComponent,

    RecipeViewPageComponent,
    RecipeEditPageComponent,
    RecipeCreatePageComponent,
    RecipeBasePageComponent,
    RecipeEditComponent,
    IngredientPickerComponent,
    TagPickerComponent,
    CommentDisplayComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
