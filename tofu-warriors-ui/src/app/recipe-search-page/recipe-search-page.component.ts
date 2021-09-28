import { Component, OnInit } from '@angular/core';
import { Recipe } from '../recipe';
import { RecipeService } from '../recipe.service';

interface SearchTerm {
  value: string;
  type: string;
}

@Component({
  selector: 'app-recipe-search-page',
  templateUrl: './recipe-search-page.component.html',
  styleUrls: ['./recipe-search-page.component.css']
})
export class RecipeSearchPageComponent implements OnInit {

  constructor(
    private recipeService: RecipeService
  ) { }

  searchTerms: any[] = [];
  results: Recipe[] = [];
  curTerm = {
    value: "",
    type: ""
  }
  //curTerm: string = "";
  //curType: string = "";
  status: string = "";

  ngOnInit(): void {
  }

  /*
  updateType(event: any) {
    this.curType = event.target.value;
  }

  updateTerm(event: any) {
    console.log(event);
    this.curTerm = event.target.value;
  }

  */
  addSearchTerm() {
    if (!this.curTerm.value || !this.curTerm.type) {
      this.status = "Please enter term and select type";
      return;
    } else {
      this.status = "";
    }
    console.log(`Adding term ${this.curTerm.value}, ${this.curTerm.type}`);
    this.searchTerms.push({ ...this.curTerm });
  }

  removeSearchTerm(term: any) {
    console.log("removing", term);
    this.searchTerms = this.searchTerms.filter(t => t != term);
  }

  clearResults() {
    this.results = [];
  }

  runSearch() {
    console.log("Searching... ", this.searchTerms);
    var name = "";
    for (const term of this.searchTerms) {
      if (term.type == "name_search") {
        name = term.value;
        break;
      }
    }
    if (name) {
      this.recipeService.searchRecipesByName(name).subscribe(recipes => {
        console.log("recipes", recipes);
        this.results = recipes;
      });
    }
  }

}
