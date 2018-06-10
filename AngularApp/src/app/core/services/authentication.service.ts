import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { ToastrService } from 'ngx-toastr';
import { GetGoogleRedirectUriResponse } from '../../guest-site/dto/get-google-redirect-uri-respose';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/x-www-form-urlencoded'
  })
}

const apiUrl = environment.apiUrl;

@Injectable()
export class AuthenticationService {

  tokenKey: string = "currentUser"

  constructor(private router: Router,
    private _http: HttpClient,
    private _toastr: ToastrService) { }

  login(username, password) {
    this.getTokenFromBackend(username, password)
      .subscribe(response => {
        this.setToken(response);
        this.router.navigate(['user']);
        this.showSuccess('Zalogowano się'); 
      }, error => {
        console.log(error.error.error_description)
        this.showError("Błąd logowania");
      });
  }

  googleLogin() {
    this._http.get<GetGoogleRedirectUriResponse>(`${apiUrl}/api/externalLogin`)
    .subscribe(response => {
      document.location.href = response.uri;
    }, error => {
      console.log(error.error.error_description)
      this.showError("Błąd logowania");
    });
    
  }

  showSuccess(message) {
    this._toastr.success(message);
  }

  showError(message) {
    this._toastr.error(message);
  }

  logout() {
    this.removeToken();
    this.router.navigate(['']);
    this.showSuccess("Wylogowano się")
  }

  getToken() {
    return JSON.parse(localStorage.getItem(this.tokenKey));
  }

  setToken(token) {
    localStorage.setItem(this.tokenKey, JSON.stringify(token));
  }

  removeToken() {
    localStorage.removeItem(this.tokenKey);
  }
  
  private getTokenFromBackend(username: string, password: string) {
    var credentials = new HttpParams()
      .set('username', username)
      .set('password', password)
      .set('grant_type', 'password');

    const httpOptions = {
      headers: new HttpHeaders()
        .set('content-type', 'application/x-www-form-urlencoded')
    };

    return this._http.post(`${apiUrl}/token`, credentials, httpOptions);
  }

}
