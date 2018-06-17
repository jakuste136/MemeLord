import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { UserReportForm } from '../dto/user-report-form';
import { UserReportService } from './report.service';
import { SingleUserReportResponse } from '../dto/single-user-report';
import { MatTableDataSource, MatSort, Sort } from '@angular/material';
import { DataSource } from '@angular/cdk/table';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.scss']
})
export class ReportComponent implements OnInit {

  model: UserReportForm;
  users: Array<SingleUserReportResponse>;
  displayedColumns = ['username', 'dateOfBirth', 'sex', 'email', 'postsCount', 'postRating'];
  dataSource;
  
  
  @ViewChild(MatSort) sort: MatSort;

  constructor(private _userReportService: UserReportService) { 
    this.model = new UserReportForm("", 0, 0);
    this.users = new Array<SingleUserReportResponse>();
  }

  ngOnInit() {
    this.dataSource = new MatTableDataSource(this.users);
    this.dataSource.sort = this.sort;
  }

  clear(){
    this.model.username = "";
    this.model.sex = 0;
    this.model.status = 0;
  }

  filter(){
    this._userReportService.getUsersReport(this.model).subscribe(data =>{
      this.users = data.users;
    })

    var examplaryUser = new SingleUserReportResponse();
    examplaryUser.username = "filmus";
    examplaryUser.sex = "male";
    examplaryUser.email = "filmus@lol.gg";
    examplaryUser.dateOfBirth = new Date(1996, 5, 31);
    examplaryUser.postRating = 56;
    examplaryUser.postsCount = 11;
    this.users.push(examplaryUser);
    var examplaryUser2 = new SingleUserReportResponse();
    examplaryUser2.username = "bae";
    examplaryUser2.sex = "female";
    examplaryUser2.email = "zzz@lollolololololol.gg";
    examplaryUser2.dateOfBirth = new Date(2000, 5, 31);
    examplaryUser2.postRating = 20;
    examplaryUser2.postsCount = 60;
    this.users.push(examplaryUser2);
    this.users.push(examplaryUser);
    this.users.push(examplaryUser);
  }

  sortData(sort: Sort) {
    const data = this.users.slice();
    if (!sort.active || sort.direction == '') {
      this.dataSource = data;
      return;
    }

    this.dataSource = data.sort((a, b) => {
      let isAsc = sort.direction == 'asc';
      switch (sort.active) {
        case 'username': return this.compare(a.username, b.username, isAsc);
        case 'dateOfBirth': return this.compare(a.dateOfBirth, b.dateOfBirth, isAsc);
        case 'sex': return this.compare(a.sex, b.sex, isAsc);
        case 'email': return this.compare(a.email, b.email, isAsc);
        case 'postsCount': return this.compare(a.postsCount, b.postsCount, isAsc);
        case 'postRating': return this.compare(a.postRating, b.postRating, isAsc);
        default: return 0;
      }
    });
  }

  compare(a, b, isAsc) {
    return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
  }
}
