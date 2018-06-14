import {  Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { ReportModalComponent } from '../../../report-modal/report-modal.component';
import { ICommentDto } from "../../../dto/comment-dto";
import { IMasterCommentDto } from '../../../dto/master-comment-dto';
import { CommentService } from '../comment.service';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.scss']
})
export class CommentComponent implements OnInit {

  _comment: IMasterCommentDto;
  
  answerComments: Array<ICommentDto>;
  likeValue: number;
  commentId: number;
  newComment;

  get name() {
    return this._comment;
  }

  @Input() postId: number;
  @Input() rating: number;
  @Input()
  set comment(comment)  {
    comment.existanceDuration = this.getCommentExistanceDuration(comment);
    this._comment = comment;
  }
  isAnswerAreaVisible;

  reportModalRef: MatDialogRef<ReportModalComponent>;

  constructor(private _dialog: MatDialog,
              private _commentService: CommentService,
              private _toastr: ToastrService) {
  }

  getCommentExistanceDuration(comment) {
    var now = new Date();
    var creationDate = comment.creationDate.substring(0, comment.creationDate.length - 1)
    creationDate = new Date(creationDate);

    var diff = Math.abs(now.getTime() - creationDate.getTime());
    var diffInMinutes = Math.floor(diff / (1000 * 60));
    var diffInHours = Math.floor(diffInMinutes / 60);
    var diffInDays = Math.floor(diffInHours / 24);

    if (diffInDays > 30)
      return "dodano ponad miesiąc temu";

    if (diffInDays > 1)
      return `dodano ${diffInDays} dni temu`;

    if (diffInHours > 1)
      return `dodano ${diffInHours} godzin temu`;

    if (diffInMinutes > 1)
      return `dodano ${diffInMinutes} minut temu`;

    return "dodano przed chwilą";
  }

  reportComment() {
    this.reportModalRef = this._dialog.open(ReportModalComponent, {
      width: "550px",
      data: {
        commentId: this._comment.id
      }
    });
  }

  private addComment() {
    if (!this.comment.text) {
      this._toastr.error("Nie można dodać pustego komentarza")
      return;
    }
    this._commentService.addComment(this.comment).subscribe(response => {
      this.appendNewComment(response.comment);
      this._toastr.success("Dodano komentarz");
    }, error => {
      this._toastr.error("Dodawanie komentarza nie powiodło się");
    });

    this.comment.text = '';
  }

  private appendNewComment(comment){
    this.toggleAnswerArea();
    this.answerComments.push(comment);
  }

  private toggleAnswerArea(){
    this.isAnswerAreaVisible = !this.isAnswerAreaVisible;
  }

  ngOnInit() {
	  if(this._comment.id !== undefined){
      this.answerComments = this._comment.answers;
      this.commentId = this._comment.id;
      this.isAnswerAreaVisible = false;
      this.newComment = {
        PostId : this.postId,
        MasterCommentId : this.commentId
      }
      this._commentService.getCommentLikeForUser(this.commentId).subscribe(result => { this.likeValue = (result == null ? 0 : result.value) } )
    }
  }
  
  ngOnChanges(changes: SimpleChanges): void {
    if(this._comment.id !== undefined){
      this.answerComments = this._comment.answers;
      this.commentId = this._comment.id;
      this._commentService.getCommentLikeForUser(this.commentId).subscribe(result => { this.likeValue = (result == null ? 0 : result.value) } )
    }
  }

}
