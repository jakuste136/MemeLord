import { Component, OnInit, Input, AfterViewInit, AfterViewChecked, OnChanges, SimpleChanges, EventEmitter, Output } from '@angular/core';
import { PostService } from './post.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit, OnChanges {

  
  @Input() title: string;
  @Input() path: string;
  @Input() rating: number;
  @Input() index: number;
  @Input() postId: number;
  likeValue: number;
  storedPostId: number;

  @Output() onClicked: EventEmitter<any> = new EventEmitter();

  constructor(private _postService: PostService) {
    
  }

  ngOnInit() {
    if (this.postId !== undefined) {
      this.storedPostId = this.postId
      this._postService.getPostLikeForUser(this.storedPostId).subscribe(data => {
        this.likeValue = (data === null ? 0 : data.value);
      })
    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (this.postId !== undefined) {
      this.storedPostId = this.postId
      this._postService.getPostLikeForUser(this.storedPostId).subscribe(data => {
        this.likeValue = (data === null ? 0 : data.value);
      })
    }
  }

  postClicked() {
    this.onClicked.emit();
  }

}