import { Component, OnInit } from '@angular/core';
import { IPostDto } from '../dto/post-dto';
import { PostsListService } from '../posts-list/posts-list.service';

@Component({
  selector: 'app-top',
  templateUrl: './top.component.html',
  styleUrls: ['./top.component.scss']
})
export class TopComponent implements OnInit {

  posts = new Array<IPostDto>();
  lastId: number;

  ngOnInit(): void {
  }

  constructor(private _postsListService: PostsListService) {
    this.lastId = 0;

    this._postsListService.getTopPosts(this.lastId, 10).subscribe(data => {
      this.posts = data.postsList;
      this.lastId = data.lastId;
    });
  }

  appendPosts(newPosts: IPostDto[]) {
    this.posts = this.posts.concat(newPosts);
  }

  onScroll() {
    this._postsListService.getTopPosts(this.lastId, 10).subscribe(data => {
      this.appendPosts(data.postsList);
      this.lastId = data.lastId;
    });
  }

}
