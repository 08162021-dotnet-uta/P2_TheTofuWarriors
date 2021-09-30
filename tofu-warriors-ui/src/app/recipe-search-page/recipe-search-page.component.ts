import { Component, OnInit } from '@angular/core';
import { Recipe } from '../recipe';
import { RecipeService } from '../recipe.service';
import { RecipeTag, SearchTerm } from '../search-term';


@Component({
  selector: 'app-recipe-search-page',
  templateUrl: './recipe-search-page.component.html',
  styleUrls: ['./recipe-search-page.component.css']
})
export class RecipeSearchPageComponent implements OnInit {

  constructor(
    private recipeService: RecipeService
  ) { }

  searchTerms: string[] = [];
  searchTags: RecipeTag[] = [];
  results: Recipe[] = [];
  /*
  curTerm = {
    value: "",
    type: ""
  }
  */
  status: string = "";

  ngOnInit(): void {
  }

  addSearchTerm(term: string) {
    /*
    if (!term.value || !term.type) {
      this.status = "Please enter term and select type";
      return;
    } else {
      this.status = "";
    }
    console.log(`Adding term ${term.value}, ${term.type}`);
    */
    console.log("adding term", term);
    this.searchTerms.push(term);
  }

  addSearchTag(tag: RecipeTag) {
    this.searchTags.push(tag);
  }

  removeSearchTerm(term: string) {
    console.log("removing", term);
    this.searchTerms = this.searchTerms.filter(t => t != term);
  }

  removeSearchTag(tag: RecipeTag) {
    this.searchTags = this.searchTags.filter(t => t != tag);
  }

  clearResults() {
    this.results = [];
  }

  runSearch() {
    console.log("Searching... ", this.searchTerms);
    if (!this.searchTerms) {
      // TODO: show message requiring search terms
      return;
    }
    this.recipeService.searchRecipes(this.searchTerms, this.searchTags).subscribe(recipes => {
      console.log("Search results: ", recipes);
      this.results = recipes
    });
    return;
    /*
    var name = "";
    for (const term of this.searchTerms) {
      if (term.type == 0) {
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
    */
  }

}
