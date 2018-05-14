import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-post-bar',
  templateUrl: './post-bar.component.html',
  styleUrls: ['./post-bar.component.scss']
})
export class PostBarComponent implements OnInit {


  @Input() rating: number;
  @Input() likeValue: number;
  @Input() index: number;
  @Input() postId: number;

  @Output() commentsToggled: EventEmitter<any> = new EventEmitter();
  
  constructor() { }

  ngOnInit() {
  }

  onCommentsToggled() {
    this.commentsToggled.emit();
  }

}
