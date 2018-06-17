import { Component, OnInit, Input, AfterViewInit, AfterViewChecked, OnChanges, SimpleChanges, EventEmitter, Output, ViewChild } from '@angular/core';
import { PostService } from './post.service';
import { BestCommentsService } from './best-comments/best-comments.service';
import { BestCommentsComponent } from './best-comments/best-comments.component';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthGuardService } from '../../core/services/auth-guard.service';
import { environment } from '../../../environments/environment';
import { MatDialogRef, MatDialog } from '@angular/material';
import { ReportModalComponent } from '../report-modal/report-modal.component';

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
  @Input() username: string;
  @Input() showBestComments = true;

  apiurl = environment.apiUrl;

  likeValue: number;
  storedPostId: number;

  reportModalRef: MatDialogRef<ReportModalComponent>;

  @Output() onClicked: EventEmitter<any> = new EventEmitter();

  @ViewChild(BestCommentsComponent)
  private bestComments: BestCommentsComponent;
  areBestCommentsVisible = false;

  constructor(private _authGuardService: AuthGuardService,
    private _bestCommentsService: BestCommentsService,
    private _postService: PostService,
    private _router: Router,
    private _dialog: MatDialog,
    private _route: ActivatedRoute) {

  }

  ngOnInit() {
    if (this.postId !== undefined && this._authGuardService.canActivate(false)) {
      this.storedPostId = this.postId
      this._postService.getPostLikeForUser(this.storedPostId).subscribe(data => {
        this.likeValue = (data === null ? 0 : data.value);
      })
    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (this.postId !== undefined && this._authGuardService.canActivate(false)) {
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
    this.reportModalRef = this._dialog.open(ReportModalComponent, {
      width: "550px",
      data: {
        postId: this.postId
      }
    });
  }

  toggleComments() {
    if (this.showBestComments) {
      this.areBestCommentsVisible = !this.areBestCommentsVisible;
      if (this.areBestCommentsVisible)
        this.bestComments.getBestComments(this.postId);
    }
  }

  goToAuthorUser() {
    if (this._authGuardService.canActivate(true)) {
      if (this._router.url.includes("/guest"))
        this._router.navigate(['./guest/author', this.username]);
      else
        this._router.navigate(['./user/author', this.username]);
    }

  }

}