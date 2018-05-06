import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Rx";
import { Headers, RequestOptions, Http, Response } from "@angular/http";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { IPostLike } from "../../dto/like-dto";

@Injectable()
export class RatingsService{

    constructor(private _http: HttpClient){ }

    addOrRemoveLike(postLike: IPostLike): Observable<IPostLike>{
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        let options = { headers: headers };
        
        return this._http.post('http://localhost:8080/api/like/add-like', JSON.stringify(postLike), options)
            .map((response: Response) => { return response.json(); });
    }
}