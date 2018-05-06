import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-comment-button',
  templateUrl: './comment-button.component.html',
  styleUrls: ['./comment-button.component.scss']
})
export class CommentButtonComponent implements OnInit {

  @Input() index: number;
  @Input() postId: number;

  constructor() { }

  ngOnInit() {
  }

  showComments(){
    //TODO provide implementation
  }

}
