import { Component, OnInit, EventEmitter } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthorUserProfileService } from './author-user-profile.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-author-user-profile',
  templateUrl: './author-user-profile.component.html',
  styleUrls: ['./author-user-profile.component.scss']
})
export class AuthorUserProfileComponent implements OnInit {

  authorName: string;
  show: Boolean;
  delayedShow: Boolean;
  userFollowed: Boolean;
  displayEvent: EventEmitter<any> = new EventEmitter();

  constructor(private _route: ActivatedRoute,
    private _authorUserProfileService: AuthorUserProfileService,
    private _toastr: ToastrService) {
    this.authorName = this._route.snapshot.paramMap.get('authorName');
    this.show = false;
    this.delayedShow = false;
    this._authorUserProfileService.getFollow(this.authorName).subscribe(data => {
      if (!data)
        this.userFollowed = false;
      else this.userFollowed = data.active;
    })
  }

  ngOnInit() {
  }

  hideUserProfile() {
    this.show = true;
    this.delayedShow = true;
    $("#profile-info").css("width", "0px");
    $("#grid-container").css("grid-gap", "0px");
  }

  showUserProfile() {
    this.show = false;
    $("#profile-info").css("width", "600px");
    $("#grid-container").css("grid-gap", "15px");
    setTimeout(() =>{
      this.delayedShow = false;
    }, 1000);
  }

  follow() {
    this.userFollowed = true;
    this._authorUserProfileService.follow(this.authorName, true).subscribe(response => {
      this._toastr.success("Obserwujesz tego użytkownika");
    }, error => {
      this._toastr.error(error.error);
    });
  }

  unfollow() {
    this.userFollowed = false;
    this._authorUserProfileService.follow(this.authorName, false).subscribe(response => {
      this._toastr.success("Nie obserwujesz już tego użytkownika");
    }, error => {
      this._toastr.error(error.error);
    });
  }
}
