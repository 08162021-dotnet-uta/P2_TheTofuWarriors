
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecipeViewPageComponent } from './recipe-view-page.component';

describe('RecipeViewPageComponent', () => {
  let component: RecipeViewPageComponent;
  let fixture: ComponentFixture<RecipeViewPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecipeViewPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RecipeViewPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
