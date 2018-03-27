import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import { IAddUserRequest } from './dto/add-user-request';

@Injectable()
export class RegisterUserService {

  constructor(private _http: HttpClient) { }

  registerUser(user: IAddUserRequest): Observable<IAddUserRequest> {
    return this._http.post<IAddUserRequest>(`http://localhost:8080/api/user`, user);
  }
}