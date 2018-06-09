import { Component, OnInit, Input, Inject } from '@angular/core';
import { ReportService } from './report.service';
import { ToastrService } from 'ngx-toastr';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { AddPostModalComponent } from '../posts-list/add-post-modal/add-post-modal.component';

@Component({
  selector: 'app-report-modal',
  templateUrl: './report-modal.component.html',
  styleUrls: ['./report-modal.component.scss']
})
export class ReportModalComponent implements OnInit {

  reportTypes;
  selectedType;
  constructor(private _toastr: ToastrService,
    private _reportService: ReportService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _dialogRef: MatDialogRef<AddPostModalComponent>) {

    _reportService.getReportTypes().subscribe(response => {
      this.reportTypes = response.reportTypes;
    })
  }

  ngOnInit() {
  }

  report() {
    if (!this.selectedType) {
      this._toastr.error("Nie wybrano powodu zgłoszenia");
    }

    var report = {
      postId: this.data.postId,
      commentId: this.data.commentId,
      reportTypeId: this.selectedType.id
    }

    if (report.commentId) {
      this._reportService.checkIfCommentAlreadyReported(report.commentId).subscribe(response => {
        if (response == true)
          this._toastr.error("Komentarz został już wcześniej zgłoszony");
        else
          this.performReport(report);

        this._dialogRef.close();

      })
    }
    else if (report.postId) {
      this._reportService.checkIfPostAlreadyReported(report.postId).subscribe(response => {
        if (response == true)
          this._toastr.error("Post został już wcześniej zgłoszony");
        else
          this.performReport(report);

        this._dialogRef.close();
      })
    }
  }

  performReport(report) {
    this._reportService.report(report).subscribe(response => {
      this._toastr.success("Zgłoszono post");
    }, error => {
      this._toastr.error(error.innerException.exceptionMessage);
    });

    this._toastr.info("Zgłaszanie postu...");
  }
}
