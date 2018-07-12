import { Component, OnInit, Input } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material';
import { ReportModalComponent } from '../../../report-modal/report-modal.component';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.scss']
})
export class CommentComponent implements OnInit {

  _comment;

  get name() {
    return this._comment;
  }

  @Input()
  set comment(comment) {
    comment.existanceDuration = this.getCommentExistanceDuration(comment);
    this._comment = comment;
  }

  reportModalRef: MatDialogRef<ReportModalComponent>;

  constructor(private _dialog: MatDialog) {
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

  ngOnInit() {
  }

}
