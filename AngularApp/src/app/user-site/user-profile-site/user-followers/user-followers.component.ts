import { Component, OnInit } from '@angular/core';
import { IGetUserResponse } from '../dto/get-user-response';
import { Router } from '@angular/router';
import { MatTableDataSource } from '@angular/material';
import { UserFollowersService } from './user-followers.service';

@Component({
  selector: 'app-user-followers',
  templateUrl: './user-followers.component.html',
  styleUrls: ['./user-followers.component.scss']
})
export class UserFollowersComponent implements OnInit {
  followers: Array<IGetUserResponse>;
  displayedColumns = ['avatar', 'username'];
  dataSource;

  constructor(
    private _userFollowersService: UserFollowersService,
    private _router: Router,
  ) {
    this.followers = new Array<IGetUserResponse>();
  }

  ngOnInit() {
    this.dataSource = new MatTableDataSource(this.followers);
    this.fill()
  }


  fill(){
    this._userFollowersService.getFollowers().subscribe(data =>{
      this.followers = data;
      this.dataSource = this.followers;
    })
  }

  showUser(username: string){
    this._router.navigate([`/user/author/${username}`]);
  }
}
