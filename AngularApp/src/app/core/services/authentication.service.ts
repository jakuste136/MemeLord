import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/x-www-form-urlencoded'
  })
}

@Injectable()
export class AuthenticationService {

  tokenKey: string = "a5smm_utoken"

  constructor(private router: Router,
    private _http: HttpClient) { }

  login(username, password) {
    this.getTokenFromBackend(username, password)
      .subscribe(response => {
        this.setToken(response);
        this.router.navigate(['user']);
      }, error => {
        console.log(error.error.error_description)
      });
  }

  logout() {
    this.removeToken();
    this.router.navigate(['']);
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

    return this._http.post('http://localhost:8080/token', credentials, httpOptions);
  }

}
