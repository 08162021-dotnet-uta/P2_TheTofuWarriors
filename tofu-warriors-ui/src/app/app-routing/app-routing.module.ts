import { NgModule } from '@angular/core';
import { RouterModule,Routes } from '@angular/router';
import { LoginComponent } from '../login/login.component';
import { RecipeSearchPageComponent } from '../recipe-search-page/recipe-search-page.component';
import { SignupComponent } from '../signup/signup.component';
import { UserHomePageComponent } from '../user-home-page/user-home-page.component';


const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'home', component: UserHomePageComponent },
  { path: 'recipeSearch', component: RecipeSearchPageComponent }
];

@NgModule({

  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
