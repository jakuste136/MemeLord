import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostsListService } from '../posts-list.service';
import { UserDetailsService } from '../../../user-site/user-profile-site/user-details/user-details.service';
import { CommentService } from './comment.service';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { AuthenticationService } from '../../../core/services/authentication.service';
import { AuthGuardService } from '../../../core/services/auth-guard.service';

@Component({
  selector: 'app-post-details',
  templateUrl: './post-details.component.html',
  styleUrls: ['./post-details.component.scss']
})
export class PostDetailsComponent implements OnInit {

  post;
  user;
  comment;

  comments;
  lastCommentId;

  constructor(private _route: ActivatedRoute,
    private _postService: PostsListService,
    private _userDetailsService: UserDetailsService,
    private _commentService: CommentService,
    private _toastr: ToastrService,
    private _authGuardService: AuthGuardService) {

    var id = _route.snapshot.params.id;
    this.comment = {
      postId: id
    };

    this.comments = [];

    _postService.getPost(id).subscribe(response => {
      this.post = response;
      this.initializeComments();
    })

    if (_authGuardService.canActivate(true))
      _userDetailsService.getUserDetails().subscribe(response => {
        this.user = response;
      })
  }

  private initializeComments() {
    this.lastCommentId = 0;
    this.getComments();
  }

  private onScroll() {
    this.getComments();
  }

  private getComments() {
    this._commentService.getComments(this.post.id, this.lastCommentId, 10).subscribe(response => {
      this.appendComments(response.commentsList);
      this.lastCommentId = response.lastId;
    })
  }

  private appendComments(comments) {
    this.comments = this.comments.concat(comments);
  }

  private addComment() {
    if (!this.comment.text) {
      this._toastr.error("Nie można dodać pustego komentarza")
      return;
    }
    this._commentService.addComment(this.comment).subscribe(response => {
      this.appendNewComment(response.comment);
      this._toastr.success("Dodano komentarz");
    }, error => {
      this._toastr.error("Dodawanie komentarza nie powiodło się");
    });

    this.comment.text = '';
  }

  private appendNewComment(comment) {
    this.comments.unshift(comment);
  }

  ngOnInit(): void {
  }
}
