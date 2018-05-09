import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import { IGetPostsResponse } from '../dto/get-posts-response';
import { IGetRandomPostResponse } from '../dto/get-random-post-response';
import { environment } from '../../../environments/environment';
import { IPostDto } from '../dto/post-dto';

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

  getPost(id): Observable<IPostDto> {
    return this._http.get<IPostDto>(`${apiUrl}/api/post/${id}`);
  }
}
