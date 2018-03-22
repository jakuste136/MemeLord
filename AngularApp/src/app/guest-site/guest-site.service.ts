import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import { IGetPostsResponse } from './dto/get-posts-response';

@Injectable()
export class GuestSiteService {

  constructor(private _http: HttpClient) { }

  getPosts(lastId: number, count: number): Observable<IGetPostsResponse> {
    let params = new URLSearchParams();
    params.set('lastId', lastId.toString());
    params.set('count', count.toString());

    return this._http.get<IGetPostsResponse>(`http://192.168.0.108:3000/api/post/getposts?lastid=${lastId}&count=${count}`);
  }
}
