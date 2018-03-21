import { Component, OnInit } from '@angular/core';
import { PostComponent } from '../post/post.component'

@Component({
  selector: 'app-posts-list',
  templateUrl: './posts-list.component.html',
  styleUrls: ['./posts-list.component.scss']
})
export class PostsListComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
