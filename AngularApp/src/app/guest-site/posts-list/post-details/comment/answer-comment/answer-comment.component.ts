import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { CommentService } from '../../comment.service';

@Component({
  selector: 'app-answer-comment',
  templateUrl: './answer-comment.component.html',
  styleUrls: ['./comment.component.scss']
})
export class CommentComponent implements OnInit, OnChanges {

    @Input() comment;

    likeValue: number;
    commentId: number;
  
    constructor(private _commentService: CommentService) { }
  
    ngOnInit() {
      if(this.comment.id !== undefined){
        this.commentId = this.comment.id;
        this._commentService.getCommentLikeForUser(this.commentId).subscribe(result => { this.likeValue = (result == null ? 0 : result.value) } )
      }
    }
  
    ngOnChanges(changes: SimpleChanges): void {
      if(this.comment.id !== undefined){
        this.commentId = this.comment.id;
        this._commentService.getCommentLikeForUser(this.commentId).subscribe(result => { this.likeValue = (result == null ? 0 : result.value) } )
      }
    }

}