import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import { IGetPostsResponse } from '../dto/get-posts-response';
import { IGetRandomPostResponse } from '../dto/get-random-post-response';

@Injectable()
export class PostsListService {

  constructor(private _http: HttpClient) { }

  getPosts(lastId: number, count: number): Observable<IGetPostsResponse> {
    return this._http.get<IGetPostsResponse>(`http://memelordapp.azurewebsites.net/api/post?lastid=${lastId}&count=${count}`);
  }

  getRandomPost(): Observable<IGetRandomPostResponse> {
    return this._http.get<IGetRandomPostResponse>(`http://localhost:8080/api/post/random`);
  }
}
