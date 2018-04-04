import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, EmailValidator } from '@angular/forms';
import { IUserDto } from './dto/user-dto';
import { validateConfig } from '@angular/router/src/config';
import { PasswordValidator } from './password-validator';
import { RegisterUserService } from './register-user.service'

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss']
})
export class RegisterPageComponent implements OnInit {

  registryForm: FormGroup;

  constructor(
    private _fb: FormBuilder,
    private _registerUserService: RegisterUserService) {
    this.registryForm = _fb.group({
      'userName': [null, Validators.compose([
        Validators.required,
        Validators.maxLength(30)
      ])],
      'email': [null, Validators.compose([
        Validators.required,
        Validators.maxLength(100),
        Validators.email
      ])],
      'password': [null, Validators.compose([
        Validators.required
      ])],
      'repeatPassword': [null, Validators.compose([
        Validators.required
      ])]
    }, {
        validator: PasswordValidator.MatchPassword
      })
  }

  ngOnInit() {
  }

  addUser(user: IUserDto) {
    if (this.registryForm.valid) {
      this._registerUserService.registerUser(user).subscribe();
      console.log("Adding user...");
    }
  }

  getUserNameErrorMessage() {
    return this.registryForm.get('userName').hasError('required') ? 'Pole jest wymagane' :
      this.registryForm.get('userName').hasError('maxlength') ? 'Maksymalna długość nazwy użytkownika wynosi 30 znaków' : '';
  }

  getEmailErrorMessage() {
    return this.registryForm.get('email').hasError('required') ? 'Pole jest wymagane' :
      this.registryForm.get('email').hasError('maxlength') ? 'Maksymalna długość adresu email wynosi 100 znaków' :
        this.registryForm.get('email').hasError('email') ? 'Podano nieprawidłowy adres email' : '';
  }

  getPasswordErrorMessage() {
    return this.registryForm.get('password').hasError('required') ? 'Pole jest wymagane' : '';
  }

  getRepeatPasswordErrorMessage() {
    return this.registryForm.get('repeatPassword').hasError('required') ? 'Pole jest wymagane' :
      this.registryForm.get('repeatPassword').hasError('matchpassword') ? 'Podane hasła nie są takie same' : '';
  }
}
