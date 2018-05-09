import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostsListService } from '../posts-list.service';
import { UserDetailsService } from '../../../user-site/user-profile-site/user-details/user-details.service';
import { CommentService } from './comment.service';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { AuthenticationService } from '../../../core/services/authentication.service';

@Component({
  selector: 'app-post-details',
  templateUrl: './post-details.component.html',
  styleUrls: ['./post-details.component.scss']
})
export class PostDetailsComponent implements OnInit {

  post;
  user;
  comment;

  constructor(private _route: ActivatedRoute,
    private _postService: PostsListService,
    private _userDetailsService: UserDetailsService,
    private _commentService: CommentService,
    private _toastr: ToastrService,
    private _authenticationService: AuthenticationService) {

    var id = _route.snapshot.params.id;
    this.comment = {
      postId: id
    };

    _postService.getPost(id).subscribe(response => {
      this.post = response;
    })

    if (_authenticationService.getToken())
      _userDetailsService.getUserDetails().subscribe(response => {
        this.user = response;
      })
  }

  addComment() {
    if (!this.comment.text) {
      this._toastr.error("Nie można dodać pustego komentarza")
      return;
    }
    this._commentService.addComment(this.comment).subscribe(response => {
      this._toastr.success("Dodano komentarz");
      // refresh
    }, error => {
      this._toastr.error("Dodawanie komentarza nie powiodło się");
    });

    this.comment.text = '';
  }

  ngOnInit() {
  }

}
