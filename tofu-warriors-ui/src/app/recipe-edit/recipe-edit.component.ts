import { Component, Input, OnInit } from '@angular/core';
import { Ingredient } from '../ingredient';
import { Recipe } from '../recipe';

@Component({
  selector: 'app-recipe-edit',
  templateUrl: './recipe-edit.component.html',
  styleUrls: ['./recipe-edit.component.css']
})
export class RecipeEditComponent implements OnInit {

  constructor(
  ) { }

  @Input() recipe: Recipe | null = null;

  ngOnInit(): void {
  }

  addIngredient(ingredient: Ingredient) {
    if (!this.recipe) {
      return;
    }
    if (!this.recipe.ingredients) {
      this.recipe.ingredients = [];
    }
    if (this.recipe.ingredients.find(i => this.isMatch(i, ingredient))) {
      // ingredient already in list
      return;
    }
    this.recipe.ingredients.push(ingredient);
  }

  isMatch(i1: Ingredient, i2: Ingredient): boolean {
      return (
        i1.ingredientId === i2.ingredientId
        && i1.measureUnitId == i2.measureUnitId
        && i1.quantity == i2.quantity
      );
  }

  removeIngredient(ingredient: Ingredient) {
    if (!this.recipe) {
      return;
    }
    if (!this.recipe.ingredients) {
      this.recipe.ingredients = [];
      return;
    }
    this.recipe.ingredients = this.recipe.ingredients.filter(i => !this.isMatch(i, ingredient));
  }

}
