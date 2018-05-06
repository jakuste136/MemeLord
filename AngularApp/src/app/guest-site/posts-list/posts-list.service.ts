import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaderResponse, HttpHeaders } from '@angular/common/http';
import { IGetPostsResponse } from '../dto/get-posts-response';
import { IGetRandomPostResponse } from '../dto/get-random-post-response';
import { UpdatePostRequest } from '../dto/update-post-request';
import { environment } from '../../../environments/environment';

const apiUrl = environment.apiUrl;

@Injectable()
export class PostsListService {  

  constructor(private _http: HttpClient) {
  }

  getPosts(lastId: number, count: number): Observable<IGetPostsResponse> {
    return this._http.get<IGetPostsResponse>(`${apiUrl}/api/post?lastid=${lastId}&count=${count}`);
  }

  getRandomPost(): Observable<IGetRandomPostResponse> {
    return this._http.get<IGetRandomPostResponse>(`${apiUrl}/api/post/random`);
  }

  getTopPosts(lastId: number, count: number): Observable<IGetPostsResponse>{
    return this._http.get<IGetPostsResponse>(`http://localhost:8080/api/post/top?lastid=${lastId}&count=${count}`);
  }

  updatePostRating(postId: number, rating: number): Observable<any>{
    return this._http.put(`http://localhost:8080/api/post/update-rating`, new UpdatePostRequest(postId, rating), {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }
}
