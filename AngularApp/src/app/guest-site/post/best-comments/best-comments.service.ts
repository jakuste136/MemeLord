import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Rx";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from "../../../../environments/environment";
import { AuthenticationService } from "../../../core/services/authentication.service";

const apiUrl = environment.apiUrl;
const commentsCount = environment.bestCommentsCount;

@Injectable()
export class BestCommentsService {

    
    constructor(private _authenticationService: AuthenticationService, private _http: HttpClient) {
        
     }

    getBestComments(postId: number): Observable<any>{

        var token = this._authenticationService.getToken().access_token;

        const httpOptions = {
            headers: new HttpHeaders()
                .set('Authorization', `bearer ${token}`)
                .set('Content-Type', 'application/json')
        };

        return this._http.get<any>(`${apiUrl}/api/comment/best?postId=${postId}&count=${commentsCount}`, httpOptions);
    }
}