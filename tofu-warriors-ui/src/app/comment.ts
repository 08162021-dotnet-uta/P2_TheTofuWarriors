import { User } from './user';
import { Recipe } from './recipe'
import { Time } from '@angular/common';

export interface Comment {
  commentId: number;
  userId: number;
  recipeId: number;
  commentText: string;
  commentTime: Date;
  prevCommentId: number | null;
  subComments: Comment[];
}
