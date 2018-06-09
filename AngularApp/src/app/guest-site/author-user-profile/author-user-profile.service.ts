import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaderResponse, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { IGetFollowResponse } from '../dto/get-follow-response';
import { AuthGuardService } from '../../core/services/auth-guard.service';

const apiUrl = environment.apiUrl;

@Injectable()
export class AuthorUserProfileService {

    constructor(private _http: HttpClient,
        private _authGuardService: AuthGuardService) {
    }

    getFollow(authorName: string): Observable<IGetFollowResponse> {
        //if (this._authGuardService.canActivate())
            return this._http.get<IGetFollowResponse>(`${apiUrl}/api/follow?authorName=${authorName}`);
    }

    follow(authorName: string, follow: Boolean): Observable<any> {
        // if (this._authGuardService.canActivate()) {
            let body = new FormData();
            body.append('authorName', authorName);
            body.append('follow', follow.valueOf.toString());

            return this._http.post(`${apiUrl}/api/follow`, body);
        //}
    }
}