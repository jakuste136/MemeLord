import { Component } from '@angular/core';
import { GuestNavbarComponent } from './guest-navbar/guest-navbar.component'
import { PostsListComponent } from './posts/posts-list/posts-list.component'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'app';
}
