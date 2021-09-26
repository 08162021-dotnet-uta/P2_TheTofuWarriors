import { Component, OnInit } from '@angular/core';

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

  constructor() { }

  searchTerms: any[] = [];
  curTerm: string = "";
  curType: string = "";

  ngOnInit(): void {
  }

  updateType(event: any) {
    this.curType = event.target.value;
  }

  addSearchTerm() {
    console.log(`Adding term ${this.curTerm}, ${this.curType}`);
    this.searchTerms.push({ value: this.curTerm, type: this.curType });
  }

  updateTerm(event: any) {
    console.log(event);
    this.curTerm = event.target.value;
  }

  removeSearchTerm(term: any) {
    console.log("removing", term);
    this.searchTerms = this.searchTerms.filter(t => t != term);
  }

}
