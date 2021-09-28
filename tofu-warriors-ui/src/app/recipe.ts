import { User } from './user';

export interface Recipe {
  recipeId: number;
  creatorUserId: number;
  //creator: User;
  name: string;
  instructions: string;
  creationTime: Date;
  ingredients: any[];
  tags: any[];
}
