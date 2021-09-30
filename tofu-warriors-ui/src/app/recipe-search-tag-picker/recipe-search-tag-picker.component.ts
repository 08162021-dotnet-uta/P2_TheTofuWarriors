import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { RecipeTag, SearchTerm, TagInfo } from '../search-term';

@Component({
  selector: 'app-recipe-search-tag-picker',
  templateUrl: './recipe-search-tag-picker.component.html',
  styleUrls: ['./recipe-search-tag-picker.component.css']
})
export class RecipeSearchTagPickerComponent implements OnInit {

  @Input() status = "";
  @Output() addTerm = new EventEmitter<string>();
  @Output() addTag = new EventEmitter<RecipeTag>();

  nameInput = null;

  constructor() { }

  ngOnInit(): void {
  }

  getValidTags = TagInfo.getValidTags;
  addSearchTerm(name: string): void {
    this.addTerm.emit(name);
  }

  addSearchTag(tagLabel: string): void {
    console.log("adding search term", tagLabel);
    let tag = TagInfo.getTagForLabel(tagLabel);
    this.addTag.emit(tag);
  }

}
