import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort, MatTableDataSource, Sort } from '@angular/material';
import { ReportedCommentDto } from '../../../guest-site/dto/reported-comment-dto';
import { AdminReportingService } from '../admin-reporting.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BanUserDto } from '../../../guest-site/dto/ban-user-dto';

@Component({
  selector: 'app-admin-reported-comments',
  templateUrl: './admin-reported-comments.component.html',
  styleUrls: ['./admin-reported-comments.component.scss']
})
export class AdminReportedCommentsComponent implements OnInit {
  reportedComments: Array<ReportedCommentDto>;
  displayedColumns = ['username', 'text', 'creationDate', 'description', 'action'];
  dataSource;

  @ViewChild(MatSort) sort: MatSort;

  constructor(
    private _reportsService: AdminReportingService,
    private _router: Router,
    private _toastr: ToastrService
  ) {
    this.reportedComments = new Array<ReportedCommentDto>();
  }

  ngOnInit() {
    this.dataSource = new MatTableDataSource(this.reportedComments);
    this.fill()
    this.dataSource.sort = this.sort;
  }


  fill(){
    this._reportsService.getReportedComments().subscribe(data =>{
      this.reportedComments = data.reportedComments;
      this.dataSource = this.reportedComments;
    })
  }

  // showPost(postId: number){
  //   this._router.navigate([`/user/post/${postId}`]);
  // }

  showUser(username: string){
    this._router.navigate([`/user/author/${username}`]);
  }

  banUser(username: string, commentId: number) {
    var request = new BanUserDto();
    request.username = username;
    this._reportsService.banUser(request).subscribe(
      response => {
        this._toastr.success("Zabanowano użytnika");
        var index = this.reportedComments.findIndex(i => i.commentId == commentId)
        this.reportedComments.splice(index, 1)
      }
    )
  }

  deleteComment(commentId: number) {
    this._reportsService.deleteComment(commentId).subscribe(
      response => {
        this._toastr.success("Usunięto komentarz");
        var index = this.reportedComments.findIndex(i => i.commentId == commentId)
        this.reportedComments.splice(index, 1)
      }
    )
  }

  sortData(sort: Sort) {
    const data = this.reportedComments.slice();
    if (!sort.active || sort.direction == '') {
      this.dataSource = data;
      return;
    }

    this.dataSource = data.sort((a, b) => {
      let isAsc = sort.direction == 'asc';
      switch (sort.active) {
        case 'commentId': return this.compare(a.commentId, b.commentId, isAsc);
        case 'username': return this.compare(a.username, b.username, isAsc);
        case 'text': return this.compare(a.text, b.text, isAsc);
        case 'creationDate': return this.compare(a.creationDate, b.creationDate, isAsc);
        case 'description': return this.compare(a.description, b.description, isAsc);
        case 'action': return this.compare(a.commentId, b.commentId, isAsc);
        default: return 0;
      }
    });
  }

  compare(a, b, isAsc) {
    return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
  }
}
