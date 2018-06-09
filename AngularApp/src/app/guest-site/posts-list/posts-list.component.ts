import { Component, OnInit, Input } from '@angular/core';
import { IPostDto } from '../dto/post-dto';
import { PostsListService } from './posts-list.service';
import { AuthenticationService } from '../../core/services/authentication.service';
import { MatDialogRef, MatDialog } from '@angular/material';
import { AddPostModalComponent } from './add-post-modal/add-post-modal.component';
import { Router, ActivatedRoute } from '@angular/router';
import { ReportModalComponent } from '../report-modal/report-modal.component';

@Component({
  selector: 'app-posts-list',
  templateUrl: './posts-list.component.html',
  styleUrls: ['./posts-list.component.scss']
})
export class PostsListComponent implements OnInit {

  @Input() authorName: string;
  posts = new Array<IPostDto>();
  lastId: number;

  addPostModalRef: MatDialogRef<AddPostModalComponent>;

  constructor(private _postsListService: PostsListService,
    private _authenticationService: AuthenticationService,
    private _dialog: MatDialog,
    private _router: Router,
    private _route: ActivatedRoute) {
  }

  ngOnInit() {
    this.refreshPosts();
  }

  refreshPosts() {
    this.lastId = 0;

    this._postsListService.getPosts(this.lastId, 10, this.authorName).subscribe(data => {
      this.posts = data.postsList;
      this.lastId = data.lastId;

      // this.posts.forEach(element => {
      //   element.username = "kurwamac";
      // });
    });
  }

  appendPosts(newPosts: IPostDto[]) {
    this.posts = this.posts.concat(newPosts);
  }

  onScroll() {
    this._postsListService.getPosts(this.lastId, 10, this.authorName).subscribe(data => {
      this.appendPosts(data.postsList);
      this.lastId = data.lastId;
    });
  }

  openPostDetails(post) {
    this._router.navigate(['./post', post.id], { relativeTo: this._route })
  }

  openAddPostModal() {
    this.addPostModalRef = this._dialog.open(AddPostModalComponent, {
      width: "550px"
    });

    this.addPostModalRef.afterClosed().subscribe(result => {
      setTimeout(() => this.refreshPosts(), 1000);
    })
  }

  isAuthenticated() {
    return this._authenticationService.getToken() != null;
  }
}
