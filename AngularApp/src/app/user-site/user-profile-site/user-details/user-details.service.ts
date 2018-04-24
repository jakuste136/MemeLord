import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IGetUserResponse } from '../dto/get-user-response';
import { IUpdateUserRequest } from '../dto/update-user-request';
import { environment } from '../../../../environments/environment';

const apiUrl = environment.apiUrl;

@Injectable()
export class UserDetailsService {

  constructor(private _http: HttpClient) { }

  getUserDetails(): Observable<IGetUserResponse> {
    return this._http.get<IGetUserResponse>(`${apiUrl}/api/user/1`);
  }

  updateUserDetails(user: IUpdateUserRequest){
    return this._http.put<IUpdateUserRequest>(`${apiUrl}/api/user`, user);
  }
}
