import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Rx";
import { Headers, RequestOptions, Http, Response } from "@angular/http";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "../../../../../environments/environment";
import { AuthenticationService } from "../../../../core/services/authentication.service";
import { ILike } from "../../../dto/like-dto";

const apiUrl = environment.apiUrl;

@Injectable()
export class RatingsService{

    constructor(private _http: HttpClient, private _authenticationService: AuthenticationService){ }

    addOrRemoveLike(postLike: ILike): Promise<any>{

        const httpOptions = {
            headers: new HttpHeaders()
                .set('Content-Type', 'application/json')
        };

        //let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        //let options = { headers: headers };
        
        return this._http.post(`${apiUrl}/api/like/add-post`, JSON.stringify(postLike), httpOptions).toPromise();
    }
}