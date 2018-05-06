import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Rx";
import { HttpClient } from '@angular/common/http';
import { IPostLike } from "../dto/like-dto";

@Injectable()
export class PostService {

    constructor(private _http: HttpClient) { }

    getPostLikeForUser(postId: number): Observable<IPostLike>{
        return this._http.get<IPostLike>(`http://localhost:8080/api/like?postId=${postId}`);
    }
}