import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TagInfo, RecipeTag } from '../search-term';

@Component({
  selector: 'app-tag-picker',
  templateUrl: './tag-picker.component.html',
  styleUrls: ['./tag-picker.component.css']
})
export class TagPickerComponent implements OnInit {

  constructor() { }

  @Input() showCancel: boolean = false;
  @Output() addTag: EventEmitter<RecipeTag> = new EventEmitter<RecipeTag>();
  @Output() close: EventEmitter<any> = new EventEmitter<any>();

  tags = TagInfo.getValidTags();

  ngOnInit(): void {
  }

  submit(tagLabel: string) {
    let recipeTag = TagInfo.getTagForLabel(tagLabel);
    this.addTag.emit(recipeTag);
  }

  cancel() {
    this.close.emit();
  }

}
