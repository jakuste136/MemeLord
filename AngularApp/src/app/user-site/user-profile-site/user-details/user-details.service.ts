import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IGetUserResponse } from '../dto/get-user-response';
import { IUpdateUserRequest } from '../dto/update-user-request';
import { environment } from '../../../../environments/environment';
import { AuthenticationService } from '../../../core/services/authentication.service';

const apiUrl = environment.apiUrl;

@Injectable()
export class UserDetailsService {

  constructor(private _http: HttpClient, private _authenticationService: AuthenticationService) { }

  getUserDetails(): Observable<IGetUserResponse> {
    var token = this._authenticationService.getToken().access_token;

    const httpOptions = {
      headers: new HttpHeaders()
        .set('Authorization', `bearer ${token}`)
    };

    return this._http.get<IGetUserResponse>(`${apiUrl}/api/user`, httpOptions);
  }

  updateUserDetails(user: IUpdateUserRequest){
    var token = this._authenticationService.getToken().access_token;

    const httpOptions = {
      headers: new HttpHeaders()
        .set('Authorization', `bearer ${token}`)
    };
    
    return this._http.put<IUpdateUserRequest>(`${apiUrl}/api/user`, user, httpOptions);
  }
}
