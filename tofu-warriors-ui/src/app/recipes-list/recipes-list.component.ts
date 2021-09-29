import { Component, OnInit } from '@angular/core';
import { Recipe } from '../recipe';
import { RecipeService } from '../recipe.service';

@Component({
  selector: 'app-recipes-list',
  templateUrl: './recipes-list.component.html',
  styleUrls: ['./recipes-list.component.css']
})
export class RecipesListComponent implements OnInit {

  constructor(private recipeService:RecipeService ) { }
  recipies:Recipe[] = [];
  selectedRecipe?: Recipe;

  ngOnInit(): void {
    this.listAllRecipies();
  }
  onSelect(recipe:Recipe):void{
    this.selectedRecipe=recipe;
  }
  listAllRecipies():void{
    let theThis=this;
    this.recipeService.getRecipeList().subscribe(recipes=>theThis.recipies=recipes);
  
  }
}
