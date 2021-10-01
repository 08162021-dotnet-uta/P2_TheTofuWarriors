
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecipeEditPageComponent } from './recipe-edit-page.component';

describe('RecipeEditPageComponent', () => {
  let component: RecipeEditPageComponent;
  let fixture: ComponentFixture<RecipeEditPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecipeEditPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RecipeEditPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
