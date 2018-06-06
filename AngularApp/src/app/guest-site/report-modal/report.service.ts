import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { AuthenticationService } from '../../core/services/authentication.service';

const apiUrl = environment.apiUrl;

@Injectable()
export class ReportService {

    constructor(private _http: HttpClient, private _authenticationService: AuthenticationService) { }

    getReportTypes(): Observable<any> {

        var token = this._authenticationService.getToken().access_token;

        const httpOptions = {
            headers: new HttpHeaders()
                .set('Authorization', `bearer ${token}`)
        };

        return this._http.get<any>(`${apiUrl}/api/report/types`, httpOptions);
    }

    report(report) {
        var token = this._authenticationService.getToken().access_token;

        const httpOptions = {
            headers: new HttpHeaders()
                .set('Authorization', `bearer ${token}`)
        };

        return this._http.post<any>(`${apiUrl}/api/report`, report, httpOptions);
    }

    checkIfCommentAlreadyReported(commentId) {
        var token = this._authenticationService.getToken().access_token;

        const httpOptions = {
            headers: new HttpHeaders()
                .set('Authorization', `bearer ${token}`)
        };

        return this._http.get<any>(`${apiUrl}/api/report/check-comment?commentId=${commentId}`, httpOptions);
    }

    checkIfPostAlreadyReported(postId) {
        var token = this._authenticationService.getToken().access_token;

        const httpOptions = {
            headers: new HttpHeaders()
                .set('Authorization', `bearer ${token}`)
        };

        return this._http.get<any>(`${apiUrl}/api/report/check-post?postId=${postId}`, httpOptions);
    }
}