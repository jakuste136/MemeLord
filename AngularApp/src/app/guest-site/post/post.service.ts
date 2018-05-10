import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Rx";
import { HttpClient } from '@angular/common/http';
import { IPostLike } from "../dto/like-dto";
import { environment } from "../../../environments/environment";

const apiUrl = environment.apiUrl;

@Injectable()
export class PostService {

    constructor(private _http: HttpClient) { }

    getPostLikeForUser(postId: number): Observable<IPostLike>{
        return this._http.get<IPostLike>(`${apiUrl}/api/like?postId=${postId}`);
    }
}