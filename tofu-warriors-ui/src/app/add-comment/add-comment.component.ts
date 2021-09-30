import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-add-comment',
  templateUrl: './add-comment.component.html',
  styleUrls: ['./add-comment.component.css']
})
export class AddCommentComponent implements OnInit {
  @Output() saveComment: EventEmitter<string> = new EventEmitter<string>()
  @Output() cancelEdit: EventEmitter<any> = new EventEmitter<any>();
  constructor() { }
  data = {
    commentText:""
  }
  ngOnInit(): void
  {

  }
  save(): void
  {
    this.saveComment.emit(this.data.commentText)
    this.data.commentText=""
  }
  cancel(): void
  {
   this.cancelEdit.emit();
    this.data.commentText=""
  }

}
