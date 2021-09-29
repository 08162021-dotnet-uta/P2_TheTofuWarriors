import { Component, Input, OnInit } from '@angular/core';
import { CommentService } from '../comment.service';
import { Comment } from '../comment';
import { Recipe } from '../recipe';


@Component({
  selector: 'app-recipe-comment',
  templateUrl: './recipe-comment.component.html',
  styleUrls: ['./recipe-comment.component.css']
})
export class RecipeCommentComponent implements OnInit {

  constructor(private commentService: CommentService) { }

  @Input() comment: Comment | null = null;

  ngOnInit(): void {






  }
}
