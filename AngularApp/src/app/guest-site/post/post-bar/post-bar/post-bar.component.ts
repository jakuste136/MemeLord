import { Component, OnInit, Input } from '@angular/core';

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
  
  constructor() { }

  ngOnInit() {
  }

}
