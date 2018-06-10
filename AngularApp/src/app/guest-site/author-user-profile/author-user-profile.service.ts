import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaderResponse, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { IGetFollowResponse } from '../dto/get-follow-response';
import { AuthGuardService } from '../../core/services/auth-guard.service';
import { AuthenticationService } from '../../core/services/authentication.service';
import { AddFollowingRequest } from '../dto/add-following-request';

const apiUrl = environment.apiUrl;

@Injectable()
export class AuthorUserProfileService {

    constructor(private _http: HttpClient,
        private _authGuardService: AuthGuardService,
        private _authenticationService: AuthenticationService) {
    }

    getFollow(authorName: string): Observable<any> {
        if (this._authGuardService.canActivate(false))
        {
            var token = this._authenticationService.getToken().access_token;

            const httpOptions = {
                headers: new HttpHeaders()
                    .set('Authorization', `bearer ${token}`)
            };

            return this._http.get<IGetFollowResponse>(`${apiUrl}/api/following?authorName=${authorName}`, httpOptions);
        }
        return null
    }

    follow(authorName: string, follow: Boolean): Observable<any> {
        if (this._authGuardService.canActivate(true)) {

            
            var token = this._authenticationService.getToken().access_token;

            const httpOptions = {
                headers: new HttpHeaders()
                    .set('Authorization', `bearer ${token}`)
            };

            let body = new AddFollowingRequest;
            body.authorName = authorName;
            body.follow = follow;

            return this._http.post(`${apiUrl}/api/following`, body, httpOptions);
        }
    }
}