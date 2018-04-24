import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IAddUserRequest } from './dto/add-user-request';
import { environment } from '../../../environments/environment';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

const apiUrl = environment.apiUrl;

@Injectable()
export class RegisterUserService {


  constructor(private _http: HttpClient) { }

  registerUser(user: IAddUserRequest): Observable<IAddUserRequest> {
    return this._http.post<IAddUserRequest>(`${apiUrl}/api/user`, user, httpOptions);
  }
}