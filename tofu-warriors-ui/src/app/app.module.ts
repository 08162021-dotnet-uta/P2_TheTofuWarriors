import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { UserDisplayComponent } from './user-display/user-display.component';
import { UserHomePageComponent } from './user-home-page/user-home-page.component';
import { RecipeSearchPageComponent } from './recipe-search-page/recipe-search-page.component';

@NgModule({
  declarations: [
    AppComponent,
    UserDisplayComponent,
    UserHomePageComponent,
    RecipeSearchPageComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
