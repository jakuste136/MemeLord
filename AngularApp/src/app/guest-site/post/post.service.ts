import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Rx";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IPostLike } from "../dto/like-dto";
import { environment } from "../../../environments/environment";
import { AuthenticationService } from "../../core/services/authentication.service";

const apiUrl = environment.apiUrl;

@Injectable()
export class PostService {

    
    constructor(private _authenticationService: AuthenticationService, private _http: HttpClient) {
        
     }

    getPostLikeForUser(postId: number): Observable<IPostLike>{

        var token = this._authenticationService.getToken().access_token;

        const httpOptions = {
            headers: new HttpHeaders()
                .set('Authorization', `bearer ${token}`)
                .set('Content-Type', 'application/json')
        };

        return this._http.get<IPostLike>(`${apiUrl}/api/like?postId=${postId}`, httpOptions);
    }
}