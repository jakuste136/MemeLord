import { Component, OnInit, Input, AfterViewInit, AfterViewChecked, OnChanges, SimpleChanges, EventEmitter, Output, ViewChild } from '@angular/core';
import { PostService } from './post.service';
import { BestCommentsService } from './best-comments/best-comments.service';
import { BestCommentsComponent } from './best-comments/best-comments.component';

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
  @Input() showBestComments = true;

  likeValue: number;
  storedPostId: number;

  @Output() onClicked: EventEmitter<any> = new EventEmitter();
  @Output() reportButtonClicked: EventEmitter<any> = new EventEmitter();

  @ViewChild(BestCommentsComponent)
  private bestComments: BestCommentsComponent;
  areBestCommentsVisible = false;

  constructor(private _postService: PostService,
    private _bestCommentsService: BestCommentsService) {

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

  onReportButtonClicked() {
    this.reportButtonClicked.emit(this.postId);
  }

  toggleComments() {
    if (this.showBestComments) {
      this.areBestCommentsVisible = !this.areBestCommentsVisible;
      if (this.areBestCommentsVisible)
        this.bestComments.getBestComments(this.postId);
    }
  }

}