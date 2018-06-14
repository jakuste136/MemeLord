import { Component, Input, AfterContentChecked, AfterViewInit, SimpleChanges, OnChanges } from '@angular/core';
import { AuthGuardService } from '../../../../../core/services/auth-guard.service';
import { CommentService } from '../../comment.service';
import { ILike } from '../../../../dto/like-dto';

@Component({
  selector: 'app-comment-rating-bar',
  templateUrl: './comment-rating-bar.component.html',
  styleUrls: ['./comment-rating-bar.component.scss']
})
export class CommentRatingBarComponent implements AfterViewInit, OnChanges {

  ngAfterViewInit(): void {
    if (this.likeValue == 1 || this.likeValue == -1) {
      this.InitializeLikeButtonSyle(this.likeValue, this.commentId.toString());
    }
  }

  likeValue: number;

  @Input() rating: number;
  @Input() commentId: number;

  constructor(private _authGuardService: AuthGuardService,
    private _commentService: CommentService) {
      this._commentService.getCommentLikeForUser(this.commentId).subscribe(result => this.likeValue = result.value == null ? 0 : result.value);
     }

    ngOnChanges(changes: SimpleChanges) {
      if (this.likeValue == 1 || this.likeValue == -1) {
        this.InitializeLikeButtonSyle(this.likeValue, this.commentId.toString());
      }
    }

  addOrRemoveLike(event: Event, requestedLikeValue: number) {
    if(this._authGuardService.canActivate(true)){
      if (this.likeValue == 1 || this.likeValue == -1) {
        this.changeLikeButtonToDefaultStyle(this.likeValue, requestedLikeValue, this.commentId.toString());
      }
      else {
        this.changeLikeButtonToActiveStyle(requestedLikeValue, this.commentId.toString());
        this.likeValue = requestedLikeValue;
      }
      this._commentService.addOrRemoveLike(new ILike(this.likeValue, this.commentId, null))
      this._commentService.updateCommentRating(this.commentId, this.rating);
    }
  }

  changeLikeButtonToDefaultStyle(likeValue: number, requestedLikeValue: number, id: string) {
    if (likeValue == 1 && requestedLikeValue == 1) {
      document.getElementById("comment-plus-button-" + id).classList.remove('clicked-plus-icon');
      this.likeValue = 0;
      this.rating -= 1;
    }
    if (likeValue == -1 && requestedLikeValue == -1) {
      document.getElementById("comment-minus-button-" + id).classList.remove('clicked-minus-icon');
      this.likeValue = 0;
      this.rating += 1;
    }
    if (likeValue == 1 && requestedLikeValue == -1) {
      document.getElementById("comment-plus-button-" + id).classList.remove('clicked-plus-icon');
      document.getElementById("comment-minus-button-" + id).classList.add('clicked-minus-icon');
      this.likeValue = -1;
      this.rating -= 2;
    }
    if (likeValue == -1 && requestedLikeValue == 1) {
      document.getElementById("comment-plus-button-" + id).classList.add('clicked-plus-icon');
      document.getElementById("comment-minus-button-" + id).classList.remove('clicked-minus-icon');
      this.likeValue = 1;
      this.rating += 2;
    }
  }

  changeLikeButtonToActiveStyle(likeValue: number, id: string) {
    if (likeValue == 1) {
      document.getElementById('comment-plus-button-' + id).classList.add('clicked-plus-icon');
      this.rating += 1;
    }
    else {
      document.getElementById('comment-minus-button-' + id).classList.add('clicked-minus-icon');
      this.rating -= 1;
    }
  }

  InitializeLikeButtonSyle(likeValue: number, id: string) {
    if (likeValue == 1) {
      document.getElementById('comment-plus-button-' + id).classList.add('clicked-plus-icon');
    }
    else {
      document.getElementById('comment-minus-button-' + id).classList.add('clicked-minus-icon');
    }
  }
}
