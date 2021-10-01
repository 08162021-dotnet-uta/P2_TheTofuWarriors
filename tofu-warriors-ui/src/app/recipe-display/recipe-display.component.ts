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
  @Input() displayComments: boolean = true;

  ngOnInit(): void {
  }

  ngOnChanges(): void {
    console.log("recipe display:", this.recipe);
  }

  getTagClass(tagType: number): string {
    switch (tagType) {
      case 1:
        return 'bg-primary';
      case 2:
        return 'bg-secondary';
      case 3:
        return 'bg-danger';
      case 5:
        return 'bg-success';
      case 4:
        return 'bg-info';
      case 6:
        return 'bg-primary';
      default:
        return '';
    }
  }

}
