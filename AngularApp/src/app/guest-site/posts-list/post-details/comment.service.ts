import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { AuthenticationService } from '../../../core/services/authentication.service';

const apiUrl = environment.apiUrl;

@Injectable()
export class CommentService {

    constructor(private _http: HttpClient, private _authenticationService: AuthenticationService) { }

    addComment(comment): Observable<any> {

        var token = this._authenticationService.getToken().access_token;

        const httpOptions = {
            headers: new HttpHeaders()
                .set('Authorization', `bearer ${token}`)
        };

        return this._http.post<any>(`${apiUrl}/api/comment`, comment, httpOptions);
    }

    getComments(postId, lastId, count): Observable<any> {
        var token = this._authenticationService.getToken().access_token;

        const httpOptions = {
            headers: new HttpHeaders()
                .set('Authorization', `bearer ${token}`)
        };

        return this._http.get<any>(`${apiUrl}/api/comment?postId=${postId}&lastId=${lastId}&count=${count}`, httpOptions);
    }
}