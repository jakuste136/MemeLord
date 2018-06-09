import { Component, OnInit } from '@angular/core';
import { PostsListService } from '../posts-list/posts-list.service';
import { IPostDto } from '../dto/post-dto';

@Component({
  selector: 'app-random-post',
  templateUrl: './random-post.component.html',
  styleUrls: ['./random-post.component.scss']
})
export class RandomPostComponent implements OnInit {

  post;

  constructor(private _postService: PostsListService) {
    this.post = {
      title:"Image not loaded yet",
      image:""
    };

    this.getRandomPost();
  }

  ngOnInit() {
  }

  getRandomPost() {
    this._postService.getRandomPost().subscribe(response => {
      this.post = response.post;

      //this.post.username = "kurwamac";
    });
  }

}
