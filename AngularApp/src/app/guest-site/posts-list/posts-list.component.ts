import { Component, OnInit } from '@angular/core';
import { IPostDto } from '../dto/post-dto';
import { PostsListService } from './posts-list.service';

@Component({
  selector: 'app-posts-list',
  templateUrl: './posts-list.component.html',
  styleUrls: ['./posts-list.component.scss']
})
export class PostsListComponent implements OnInit {
  
  posts = new Array<IPostDto>();
  lastId: number;

  constructor(private _postsListService: PostsListService) {
    this.lastId = 0;

    this._postsListService.getPosts(this.lastId, 10).subscribe(data => {
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
    this._postsListService.getPosts(this.lastId, 10).subscribe(data => {
      this.appendPosts(data.postsList);
      this.lastId = data.lastId;
    });
  }

}
