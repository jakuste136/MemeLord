import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import { IGetPostsResponse } from './dto/get-posts-response';

@Injectable()
export class GuestSiteService {

  constructor(private _http: HttpClient) { }

  getPosts(lastId: number, count: number): Observable<IGetPostsResponse> {
    return this._http.get<IGetPostsResponse>(`http://localhost:8080/api/post/get-posts?lastid=${lastId}&count=${count}`);
  }
}
