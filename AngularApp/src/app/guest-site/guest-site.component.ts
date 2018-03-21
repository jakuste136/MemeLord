import { Component, OnInit } from '@angular/core';
import { GuestNavbarComponent } from '../guest-navbar/guest-navbar.component';
import { PostsListComponent } from './posts-list/posts-list.component'

@Component({
  selector: 'app-guest-site',
  templateUrl: './guest-site.component.html',
  styleUrls: ['./guest-site.component.scss']
})
export class GuestSiteComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
