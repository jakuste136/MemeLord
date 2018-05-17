import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { AuthenticationService } from '../../../core/services/authentication.service';

const apiUrl = environment.apiUrl;

@Injectable()
export class AddPostService {


    constructor(private _http: HttpClient, private _authenticationService: AuthenticationService) { }

    addPost(post): Observable<any> {
        let body = new FormData();
        body.append('title', post.title);
        body.append('image', post.image);

        return this._http.post<any>(`${apiUrl}/api/post`, body);
    }
}