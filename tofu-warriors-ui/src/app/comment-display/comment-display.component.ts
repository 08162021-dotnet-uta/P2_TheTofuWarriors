import { Component, Input, OnInit } from '@angular/core';
import { Comment } from '../comment';
import { CommentService } from '../comment.service';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-comment-display',
  templateUrl: './comment-display.component.html',
  styleUrls: ['./comment-display.component.css']
})
export class CommentDisplayComponent implements OnInit {
@Input() comment:Comment | null = null;
@Input() loadComment:( (recipeId:number)=> void) | null= null;
  constructor(   private commentService: CommentService,private userService: UsersService) { }

  ngOnInit(): void {
  }
  showAddComment:boolean = false;
  
  save(commentText: string) {
    let user = this.userService.getCurrentUser()
    if(!user) throw new Error("must be logged in to comment")
    if(! this.comment) throw new Error("No comments yet...")
    let comment =
    {
      commentId: 0,
      userId: user.userId,
      recipeId: this.comment.recipeId,
      commentText: commentText,
      commentTime: new Date(),
      prevCommentId:this.comment.commentId,
      subComments:[]
    }
    this.commentService.newComment(comment).subscribe(data => {
    if(this.loadComment){
      this.loadComment(comment.recipeId)
    }
    })
    
  }

  cancel(): void
  {
   this.showAddComment=false;
 
  }

}
