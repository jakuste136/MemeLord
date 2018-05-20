import { Component, Input, AfterContentChecked, AfterViewInit, SimpleChanges, OnChanges } from '@angular/core';
import { RatingsService } from './ratings-bar.service';
import { Like } from '../../dto/like-dto';
import { AuthGuardService } from '../../../core/services/auth-guard.service';
import { PostsListService } from '../../posts-list/posts-list.service';

@Component({
  selector: 'app-ratings-bar',
  templateUrl: './ratings-bar.component.html',
  styleUrls: ['./ratings-bar.component.scss']
})
export class RatingsBarComponent implements AfterViewInit, OnChanges {

  ngAfterViewInit(): void {
    if (this.likeValue == 1 || this.likeValue == -1) {
      this.InitializeLikeButtonSyle(this.likeValue, this.index.toString());
    }
  }

  @Input() rating: number;
  @Input() likeValue: number;
  @Input() index: number;
  @Input() postId: number;

  constructor(private _ratingsService: RatingsService, 
    private _authGuardService: AuthGuardService,
    private _postsListService: PostsListService) { }

    ngOnChanges(changes: SimpleChanges) {
      if (this.likeValue == 1 || this.likeValue == -1) {
        this.InitializeLikeButtonSyle(this.likeValue, this.index.toString());
      }
    }

  addOrRemoveLike(event: Event, requestedLikeValue: number) {
    if(this._authGuardService.canActivate()){
      if (this.likeValue == 1 || this.likeValue == -1) {
        this.changeLikeButtonToDefaultStyle(this.likeValue, requestedLikeValue, this.index.toString());
      }
      else {
        this.changeLikeButtonToActiveStyle(requestedLikeValue, this.index.toString());
        this.likeValue = requestedLikeValue;
      }
      this._ratingsService.addOrRemoveLike(new Like(this.likeValue, this.postId, null))
      this._postsListService.updatePostRating(this.postId, this.rating);
    }
  }

  changeLikeButtonToDefaultStyle(likeValue: number, requestedLikeValue: number, id: string) {
    if (likeValue == 1 && requestedLikeValue == 1) {
      document.getElementById("plus-button-" + id).classList.remove('clicked-plus-icon');
      this.likeValue = 0;
      this.rating -= 1;
    }
    if (likeValue == -1 && requestedLikeValue == -1) {
      document.getElementById("minus-button-" + id).classList.remove('clicked-minus-icon');
      this.likeValue = 0;
      this.rating += 1;
    }
    if (likeValue == 1 && requestedLikeValue == -1) {
      document.getElementById("plus-button-" + id).classList.remove('clicked-plus-icon');
      document.getElementById("minus-button-" + id).classList.add('clicked-minus-icon');
      this.likeValue = -1;
      this.rating -= 2;
    }
    if (likeValue == -1 && requestedLikeValue == 1) {
      document.getElementById("plus-button-" + id).classList.add('clicked-plus-icon');
      document.getElementById("minus-button-" + id).classList.remove('clicked-minus-icon');
      this.likeValue = 1;
      this.rating += 2;
    }
  }

  changeLikeButtonToActiveStyle(likeValue: number, id: string) {
    if (likeValue == 1) {
      document.getElementById('plus-button-' + id).classList.add('clicked-plus-icon');
      this.rating += 1;
    }
    else {
      document.getElementById('minus-button-' + id).classList.add('clicked-minus-icon');
      this.rating -= 1;
    }
  }

  InitializeLikeButtonSyle(likeValue: number, id: string) {
    if (likeValue == 1) {
      document.getElementById('plus-button-' + id).classList.add('clicked-plus-icon');
    }
    else {
      document.getElementById('minus-button-' + id).classList.add('clicked-minus-icon');
    }
  }
}
