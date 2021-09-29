import { User } from './user';

export interface Recipe {
  recipeId: number;
  creatorUserId: number;
  //creator: User;
  name: string;
  instructions: string;
  creationTime: Date;
  isExternal: boolean;
  imageUrl: string;
  apiKey: string;
  ingredients: any[];
  tags: any[];
}
