import { Component, Input, OnInit } from '@angular/core';
import { CommentService } from '../comment.service';
import { Comment } from '../comment';
import { Recipe } from '../recipe';
import { ActivatedRoute } from '@angular/router';
import { RecipeService } from '../recipe.service';
import { UsersService } from '../users.service';
import { User } from '../user';



@Component({
  selector: 'app-recipe-comment',
  templateUrl: './recipe-comment.component.html',
  styleUrls: ['./recipe-comment.component.css']
})
export class RecipeCommentComponent implements OnInit {

  constructor(
    private commentService: CommentService,
    private recipeService: RecipeService,
    private userService: UsersService,
    private route: ActivatedRoute,
  ) { }

  @Input() comments: Comment[] = [];
  @Input() recipeId: number = 0;

  ngOnInit(): void {
  this.loadComment(this.recipeId)
  }
  loadComment(recipeId:number): void {

    this.commentService.getCommentsBy(recipeId).subscribe(comments => {
      console.log(`Got comment: ${comments}`, comments)
      this.comments = comments
    });

  }
  
  saveComment(commentText: string) {
    let user = this.userService.getCurrentUser()
    if(!user) throw new Error("must be logged in to comment")
    let comment =
    {
      commentId: 0,
      userId: user.userId,
      recipeId: this.recipeId,
      commentText: commentText,
      commentTime: new Date(),
      prevCommentId: null,
      subComments:[]
    }
    this.commentService.newComment(comment).subscribe(data => {
    this.loadComment(this.recipeId)
    })
    
  }
}
