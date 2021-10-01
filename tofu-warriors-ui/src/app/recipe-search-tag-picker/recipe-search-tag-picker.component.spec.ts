
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecipeSearchTagPickerComponent } from './recipe-search-tag-picker.component';

describe('RecipeSearchTagPickerComponent', () => {
  let component: RecipeSearchTagPickerComponent;
  let fixture: ComponentFixture<RecipeSearchTagPickerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecipeSearchTagPickerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RecipeSearchTagPickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
