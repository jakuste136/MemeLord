import { Component, OnInit, ViewChild } from '@angular/core';
import { Sort, MatTableDataSource, MatSort } from '@angular/material';
import { ReportedPostDto } from '../../../guest-site/dto/reported-post-dto';
import { AdminReportingService } from '../admin-reporting.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-reported-posts',
  templateUrl: './admin-reported-posts.component.html',
  styleUrls: ['./admin-reported-posts.component.scss']
})
export class AdminReportedPostsComponent implements OnInit {

  reportedPosts: Array<ReportedPostDto>;
  displayedColumns = ['username', 'title', 'creationDate', 'description', 'action'];
  dataSource;

  @ViewChild(MatSort) sort: MatSort;

  constructor(
    private _reportsService: AdminReportingService,
    private _router: Router
  ) {
    this.reportedPosts = new Array<ReportedPostDto>();
  }

  ngOnInit() {
    this.dataSource = new MatTableDataSource(this.reportedPosts);
    this.fill()
    this.dataSource.sort = this.sort;
  }


  fill(){
    this._reportsService.getReportedPosts().subscribe(data =>{
      this.reportedPosts = data.reportedPosts;
      this.dataSource = this.reportedPosts;
    })
  }

  showPost(postId: number){
    this._router.navigate([`/user/post/${postId}`]);
  }

  showUser(username: string){
    this._router.navigate([`/user/author/${username}`]);
  }

  banUser(username: string) {
    // this._reportsService.banUser(username).subscribe(success => {
    //   this.
    // })
  }

  sortData(sort: Sort) {
    const data = this.reportedPosts.slice();
    if (!sort.active || sort.direction == '') {
      this.dataSource = data;
      return;
    }

    this.dataSource = data.sort((a, b) => {
      let isAsc = sort.direction == 'asc';
      switch (sort.active) {
        case 'postId': return this.compare(a.postId, b.postId, isAsc);
        case 'username': return this.compare(a.username, b.username, isAsc);
        case 'title': return this.compare(a.title, b.title, isAsc);
        case 'creationDate': return this.compare(a.creationDate, b.creationDate, isAsc);
        case 'description': return this.compare(a.description, b.description, isAsc);
        case 'action': return this.compare(a.postId, b.postId, isAsc);
        default: return 0;
      }
    });
  }

  compare(a, b, isAsc) {
    return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
  }

}
