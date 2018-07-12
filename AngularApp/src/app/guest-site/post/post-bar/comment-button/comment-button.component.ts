import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-comment-button',
  templateUrl: './comment-button.component.html',
  styleUrls: ['./comment-button.component.scss']
})
export class CommentButtonComponent implements OnInit {

  @Input() index: number;
  @Input() postId: number;

  @Output() commentsToggled: EventEmitter<any> = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

  showComments() {
    this.commentsToggled.emit();
  }

}
