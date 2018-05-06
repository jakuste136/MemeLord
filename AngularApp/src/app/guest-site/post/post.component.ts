import { Component, OnInit, Input } from '@angular/core';
import { PostService } from './post.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {

  @Input() title: string;
  @Input() path: string;
  @Input() rating: number;
  @Input() index: number;
  @Input() postId: number;
  likeValue: number;

  constructor(_postService: PostService) {
    _postService.getPostLikeForUser(this.postId).subscribe(data => {
      this.likeValue = data === null? 0: data.value;
    })
  }

  ngOnInit() {
  }

}