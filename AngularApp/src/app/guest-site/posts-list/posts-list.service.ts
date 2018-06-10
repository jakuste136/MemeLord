import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IGetPostsResponse } from '../dto/get-posts-response';
import { IGetRandomPostResponse } from '../dto/get-random-post-response';
import { UpdatePostRequest } from '../dto/update-post-request';
import { environment } from '../../../environments/environment';
import { IPostDto } from '../dto/post-dto';

const apiUrl = environment.apiUrl;

@Injectable()
export class PostsListService {

  constructor(private _http: HttpClient) {
  }

  getPosts(lastId: number, count: number, authorName: string): Observable<IGetPostsResponse> {
    if (!authorName)
      return this._http.get<IGetPostsResponse>(`${apiUrl}/api/post?lastid=${lastId}&count=${count}&authorName=`);
    else
      return this._http.get<IGetPostsResponse>(`${apiUrl}/api/post?lastid=${lastId}&count=${count}&authorName=${authorName}`);
  }

  getRandomPost(): Observable<IGetRandomPostResponse> {
    return this._http.get<IGetRandomPostResponse>(`${apiUrl}/api/post/random`);
  }

  getPost(id): Observable<IPostDto> {
    return this._http.get<IPostDto>(`${apiUrl}/api/post/${id}`);
  }

  getTopPosts(lastId: number, count: number): Observable<IGetPostsResponse> {
    
    return this._http.get<IGetPostsResponse>(`${apiUrl}/api/post/top?lastid=${lastId}&count=${count}`);
  }

  updatePostRating(postId: number, rating: number): Promise<any> {
    return this._http.put(`${apiUrl}/api/post/update-rating`, new UpdatePostRequest(postId, rating), {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }).toPromise();
  }
}
