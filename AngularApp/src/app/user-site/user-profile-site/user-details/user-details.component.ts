import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RegisterUserService } from '../../../core/register-page/register-user.service';
import { IGetUserResponse } from '../dto/get-user-response';
import { UserDetailsService } from './user-details.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.scss']
})
export class UserDetailsComponent implements OnInit {

  user;

  registryForm: FormGroup;

  sexes = [
    {
      view: "Mężczyzna",
      value: "Male"
    },
    {
      view: "Kobieta",
      value: "Female"
    }
  ]

  constructor(
    private _fb: FormBuilder,
    private _userDetailsService: UserDetailsService,
    private _toastr: ToastrService) {

    this.user = {
      avatar: ""
    };

    _userDetailsService.getUserDetails().subscribe(response => {
      this.user = response;
    })

    this.registryForm = this.initializeFormGroup();
  }

  ngOnInit() {
  }

  updateUser() {
    this._userDetailsService.updateUserDetails(this.user).subscribe(response => {
      this._toastr.success("Zaktualizowano dane");
    });
  }

  getEmailErrorMessage() {
    return this.registryForm.get('email').hasError('required') ? 'Pole jest wymagane' :
      this.registryForm.get('email').hasError('maxlength') ? 'Maksymalna długość adresu email wynosi 100 znaków' :
        this.registryForm.get('email').hasError('email') ? 'Podano nieprawidłowy adres email' : '';
  }

  initializeFormGroup() {
    return this._fb.group(
      {
        "username": [null, Validators.compose([])],
        "sex": [null, Validators.compose([])],
        "dateOfBirth": [null, Validators.compose([])],
        "description": [null, Validators.compose([])],
        "avatar": [this.user.avatar, Validators.compose([])],
        'email': [null, Validators.compose([
          Validators.required,
          Validators.maxLength(100),
          Validators.email
        ])]
      }
    )
  }
}
