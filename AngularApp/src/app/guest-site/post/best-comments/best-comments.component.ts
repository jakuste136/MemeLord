import { Component, OnInit, Input } from '@angular/core';
import { BestCommentsService } from './best-comments.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-best-comments',
  templateUrl: './best-comments.component.html',
  styleUrls: ['./best-comments.component.scss']
})
export class BestCommentsComponent implements OnInit {

  comments;
  postId;

  constructor(private _bestCommentsService: BestCommentsService,
    private _router: Router,
    private _route: ActivatedRoute) { }

  ngOnInit() {
  }

  getBestComments(postId) {
    this.postId = postId;
    if (!this.comments) {
      this._bestCommentsService.getBestComments(postId).subscribe(response => {
        this.comments = response.commentsList;
      });
    }
  }

  showPostDetails() {
    this._router.navigate(['./post', this.postId], { relativeTo: this._route });
  }
}
