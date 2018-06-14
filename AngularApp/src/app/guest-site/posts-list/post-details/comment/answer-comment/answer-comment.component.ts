import { Component, OnInit, Input, Output, OnChanges, SimpleChanges, EventEmitter } from '@angular/core';
import { CommentService } from '../../comment.service';
import { ICommentDto } from '../../../../dto/comment-dto';

@Component({
  selector: 'app-answer-comment',
  templateUrl: './answer-comment.component.html',
  styleUrls: ['./answer-comment.component.scss']
})
export class AnswerCommentComponent implements OnInit, OnChanges {

    @Input() answerComment: ICommentDto;

    likeValue: number;
    commentId: number;

    @Output() onAnswer: EventEmitter<any> = new EventEmitter();
  
    constructor(private _commentService: CommentService) { }
  
    ngOnInit() {
      if(this.answerComment.id !== undefined){
        this.commentId = this.answerComment.id;
        this._commentService.getCommentLikeForUser(this.commentId).subscribe(result => { this.likeValue = (result == null ? 0 : result.value) } )
      }
    }
  
    ngOnChanges(changes: SimpleChanges): void {
      if(this.answerComment.id !== undefined){
        this.commentId = this.answerComment.id;
        this._commentService.getCommentLikeForUser(this.commentId).subscribe(result => { this.likeValue = (result == null ? 0 : result.value) } )
      }
    }

    answer(){
      this.onAnswer.emit();
    }
}