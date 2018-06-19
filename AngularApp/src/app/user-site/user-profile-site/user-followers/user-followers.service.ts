import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IGetUserResponse } from '../dto/get-user-response';
import { environment } from '../../../../environments/environment';
import { AuthenticationService } from '../../../core/services/authentication.service';

const apiUrl = environment.apiUrl;

@Injectable()
export class UserFollowersService {

  constructor(private _http: HttpClient, private _authenticationService: AuthenticationService) { }

  getFollowers(): Observable<Array<IGetUserResponse>> {
    return this._http.get<Array<IGetUserResponse>>(`${apiUrl}/api/following/users`);
  }
}
