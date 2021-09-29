import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Recipe } from '../recipe';

@Component({
  selector: 'app-recipe-create-page',
  templateUrl: './recipe-create-page.component.html',
  styleUrls: ['./recipe-create-page.component.css']
})
export class RecipeCreatePageComponent implements OnInit {

  constructor(
    private location: Location
  ) { }

  baseRecipe: Recipe | null = null;

  ngOnInit(): void {
    let state = this.location.getState() as { baseRecipe: Recipe };
    console.log("nav: ", state);
    this.baseRecipe = state.baseRecipe;
  }

}
