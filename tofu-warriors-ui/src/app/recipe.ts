import { Ingredient } from './ingredient';
import { RecipeTag } from './search-term';
import { User } from './user';

export interface Recipe {
  recipeId: number;
  creatorUserId: number;
  creator: User | null;
  name: string;
  instructions: string;
  creationTime: Date;
  isExternal: boolean;
  imageUrl: string;
  apiKey: string;
  ingredients: Ingredient[];
  tags: RecipeTag[];
}
