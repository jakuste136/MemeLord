import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, EmailValidator } from '@angular/forms';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  registryForm: FormGroup;

  constructor(
    private _fb: FormBuilder,
    private _authenticationService: AuthenticationService) {
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
  }

  login() {
    if (this.registryForm.valid) {
      this._authenticationService.login(this.registryForm.get('login').value, this.registryForm.get('password').value);
    }
  }

  getLoginErrorMessage() {
    return this.registryForm.get('login').hasError('required') ? 'Pole jest wymagane' :
      this.registryForm.get('login').hasError('maxlength') ? 'Maksymalna długość nazwy użytkownika wynosi 30 znaków' : '';
  }

  getPasswordErrorMessage() {
    return this.registryForm.get('password').hasError('required') ? 'Pole jest wymagane' : '';
  }
}
