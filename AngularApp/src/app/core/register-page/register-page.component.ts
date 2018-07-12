import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, EmailValidator } from '@angular/forms';
import { IUserDto } from './dto/user-dto';
import { validateConfig } from '@angular/router/src/config';
import { PasswordValidator } from './password-validator';
import { RegisterUserService } from './register-user.service'
import { ToastrService } from 'ngx-toastr';
import { AuthenticationService } from '../services/authentication.service';
import {
  AuthService,
  FacebookLoginProvider,
  GoogleLoginProvider
} from 'angular5-social-login';


@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss']
})
export class RegisterPageComponent implements OnInit {

  registryForm: FormGroup;

  constructor(
    private _fb: FormBuilder,
    private _registerUserService: RegisterUserService,
    private _toastr: ToastrService,
    private _authenticationService: AuthenticationService,
    private socialAuthService: AuthService) {
    this.registryForm = _fb.group({
      'username': [null, Validators.compose([
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
      this._registerUserService.registerUser(user).subscribe(response => {
        this._toastr.success("Pomyślnie założono konto");
        this._authenticationService.login(user.username, user.password);
      });
      console.log("Adding user...");
    }
  }

  public googleRegister() {
    let socialPlatformProvider = GoogleLoginProvider.PROVIDER_ID;
    this.socialAuthService.signIn(socialPlatformProvider).then(
      (userData) => {
        this._toastr.info(`Google sign in data : ${userData.name}`);
        // Now sign-in with userData
        
        var useer: IUserDto = {
          username: userData.name, 
          email: userData.email, 
          password: userData.id, 
          repeatPassword: userData.id,
          sex: null,
          dateOfBirth: null,
          description: 'Google added',
          avatar: userData.image,
        };

        this._registerUserService.registerUser(useer).subscribe(response => {
          this._toastr.success("Pomyślnie założono konto");
          this._authenticationService.login(userData.name, userData.id);
        });
      }
      
    );
  }

  getUserNameErrorMessage() {
    return this.registryForm.get('username').hasError('required') ? 'Pole jest wymagane' :
      this.registryForm.get('username').hasError('maxlength') ? 'Maksymalna długość nazwy użytkownika wynosi 30 znaków' : '';
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
