import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { RecipeService } from './recipe.service';

describe('RecipeService', () => {
  let service: RecipeService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule],
    });
    service = TestBed.inject(RecipeService);
  });

  it('#getRecipeList', (done: DoneFn) => {
    service.getRecipeList().subscribe(data=>
      {
        expect(data.length).toBeGreaterThan(0);
      });
    done();
  });
});
