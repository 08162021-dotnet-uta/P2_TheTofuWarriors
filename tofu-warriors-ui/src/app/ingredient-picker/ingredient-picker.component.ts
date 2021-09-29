import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Subscription } from 'rxjs';
import { Ingredient, MeasureUnit } from '../ingredient';
import { IngredientService } from '../ingredient.service';

@Component({
  selector: 'app-ingredient-picker',
  templateUrl: './ingredient-picker.component.html',
  styleUrls: ['./ingredient-picker.component.css']
})
export class IngredientPickerComponent implements OnInit {

  constructor(
    private ingredientService: IngredientService,
  ) { }

  @Output() add = new EventEmitter<Ingredient>();

  ingredients: Ingredient[] = [];
  measures: MeasureUnit[] = [];

  data = {
    quantity: 0,
    measureId: 0,
    ingredientId: 0
  }

  subscriptions: Subscription[] = [];

  ngOnInit(): void {
    this.subscriptions.push(this.ingredientService.getIngredients().subscribe(ingredients => {
      this.ingredients = ingredients;
    }));
    this.subscriptions.push(this.ingredientService.getMeasureUnits().subscribe(measures => {
      this.measures = measures;
    }));
  }

  ngOnDestroy(): void {
    for (let sub of this.subscriptions) {
      sub.unsubscribe();
    }
  }

  addIngredient() {
    let id: number = this.data.ingredientId;
    let ingredient = this.ingredients.find(i => i.ingredientId == id);
    let measure = this.measures.find(m => m.measureUnitId == this.data.measureId);
    if (ingredient) {
      let data = { ...ingredient, ...this.data, measureUnit: measure || null }
      console.log("Adding ingredient", data);
      this.add.emit(data);
    }
  }

}
