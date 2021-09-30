import { Component, Input, OnInit } from '@angular/core';
import { Recipe } from '../recipe';

@Component({
  selector: 'app-recipe-display',
  templateUrl: './recipe-display.component.html',
  styleUrls: ['./recipe-display.component.css']
})
export class RecipeDisplayComponent implements OnInit {

  constructor() { }

  @Input() recipe: Recipe | null = null;

  ngOnInit(): void {
  }

  ngOnChanges(): void {
    console.log("recipe display:", this.recipe);
  }

}
