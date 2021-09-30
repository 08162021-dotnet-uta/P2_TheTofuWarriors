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
<<<<<<< HEAD
import { RecipeCommentComponent } from './recipe-comment/recipe-comment.component';
import { AddCommentComponent } from './add-comment/add-comment.component';

=======
import { RecipesListComponent } from './recipes-list/recipes-list.component';

import { RecipeSearchTagPickerComponent } from './recipe-search-tag-picker/recipe-search-tag-picker.component';
>>>>>>> ebd37682e4bf12f7570006dd8f16bb0baabefac1

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
<<<<<<< HEAD
    RecipeCommentComponent,
    AddCommentComponent,

=======
    RecipesListComponent,
    RecipeSearchTagPickerComponent
>>>>>>> ebd37682e4bf12f7570006dd8f16bb0baabefac1
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
