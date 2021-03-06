import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, EmailValidator } from '@angular/forms';
import { AuthenticationService } from '../services/authentication.service';
import { ToastrService } from 'ngx-toastr';
import {
  AuthService,
  FacebookLoginProvider,
  GoogleLoginProvider
} from 'angular5-social-login';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  registryForm: FormGroup;

  constructor(
    private _fb: FormBuilder,
    private _authenticationService: AuthenticationService,
    private _toastr: ToastrService,
    private socialAuthService: AuthService) {
    this.registryForm = _fb.group({
      'login': [null, Validators.compose([
        Validators.required,
        Validators.maxLength(30)
      ])],
      'password': [null, Validators.compose([
        Validators.required
      ])],
    })
  }

  ngOnInit() {
    this._authenticationService.removeToken();
  }

  login() {
    if (this.registryForm.valid) {
      this._authenticationService.login(this.registryForm.get('login').value, this.registryForm.get('password').value);
    }
  }

  // googleLogin() {
  //   this._authenticationService.googleLogin();
  //   this._toastr.info("Logged with google");
  // }

  public googleLogin() {
    let socialPlatformProvider = GoogleLoginProvider.PROVIDER_ID;
    this.socialAuthService.signIn(socialPlatformProvider).then(
      (userData) => {
        // Now sign-in with userData
        this._authenticationService.login(userData.name, userData.id);
      }
      
    );
  }

  getLoginErrorMessage() {
    return this.registryForm.get('login').hasError('required') ? 'Pole jest wymagane' :
      this.registryForm.get('login').hasError('maxlength') ? 'Maksymalna długość nazwy użytkownika wynosi 30 znaków' : '';
  }

  getPasswordErrorMessage() {
    return this.registryForm.get('password').hasError('required') ? 'Pole jest wymagane' : '';
  }
}
