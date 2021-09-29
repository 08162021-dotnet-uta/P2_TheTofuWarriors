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
import { RecipesListComponent } from './recipes-list/recipes-list.component';


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
    RecipesListComponent
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
