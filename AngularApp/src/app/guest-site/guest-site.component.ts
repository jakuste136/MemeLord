import { Component, OnInit } from '@angular/core';
import { GuestNavbarComponent } from '../guest-navbar/guest-navbar.component';
import { LoginPageComponent } from '../login-page/login-page.component'
import { IPostDto } from './dto/post-dto';
import { GuestSiteService } from './guest-site.service'
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-guest-site',
  templateUrl: './guest-site.component.html',
  styleUrls: ['./guest-site.component.scss']
})
export class GuestSiteComponent implements OnInit {
  posts = new Array<IPostDto>();
  lastId: number;

  constructor(private _guestSiteService: GuestSiteService) {
    this.lastId = 0;

    this._guestSiteService.getPosts(this.lastId, 10).subscribe(data => {
      this.posts = data.postsList;
      this.lastId = data.lastId;
    });
  }

  ngOnInit() {
  }

  appendPosts(newPosts: IPostDto[]) {
    this.posts = this.posts.concat(newPosts);
  }

  onScroll() {
    this._guestSiteService.getPosts(this.lastId, 10).subscribe(data => {
      this.appendPosts(data.postsList);
      this.lastId = data.lastId;
    });
  }
}
