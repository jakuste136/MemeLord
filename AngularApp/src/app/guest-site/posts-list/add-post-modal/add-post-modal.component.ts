import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AddPostService } from './add-post.service';
import { ToastrService } from 'ngx-toastr';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-add-post-modal',
  templateUrl: './add-post-modal.component.html',
  styleUrls: ['./add-post-modal.component.scss']
})
export class AddPostModalComponent implements OnInit {

  post;
  display;

  constructor(private _addPostService: AddPostService,
    private _toastr: ToastrService,
    private _dialogRef: MatDialogRef<AddPostModalComponent>) {

    this.post = {
      image: "",
      title: ""
    }
    this.display = "";
  }

  ngOnInit() {
  }

  choosePicture(files: FileList) {
    this.post.image = files.item(0);

    let reader = new FileReader();

    reader.onload = (e: any) => {
      this.display = e.target.result;
    }

    reader.readAsDataURL(files.item(0));
  }

  addPost() {
    this._addPostService.addPost(this.post).subscribe(response => {
      this._toastr.success("Dodano post");
    });

    this._dialogRef.close();
    this._toastr.info("Dodawanie postu...");
  }

  closeModal() {
    this._dialogRef.close();
  }
}
