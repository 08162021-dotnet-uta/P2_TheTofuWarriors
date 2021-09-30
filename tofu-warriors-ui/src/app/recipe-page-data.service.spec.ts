import { TestBed } from '@angular/core/testing';

import { RecipePageDataService } from './recipe-page-data.service';

describe('RecipePageDataService', () => {
  let service: RecipePageDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RecipePageDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
