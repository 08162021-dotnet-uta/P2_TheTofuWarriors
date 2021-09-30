import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecipeBasePageComponent } from './recipe-base-page.component';

describe('RecipeBasePageComponent', () => {
  let component: RecipeBasePageComponent;
  let fixture: ComponentFixture<RecipeBasePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecipeBasePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RecipeBasePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
