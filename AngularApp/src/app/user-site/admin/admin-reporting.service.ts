import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GetReportedPostsResponse } from '../../guest-site/dto/get-reported-posts-response';
import { environment } from '../../../environments/environment';
import { GetReportedCommentsResponse } from '../../guest-site/dto/get-reported-comments-response';

const apiUrl = environment.apiUrl;

@Injectable()
export class AdminReportingService {

  constructor(private _http: HttpClient) { }

  getReportedPosts(): Observable<GetReportedPostsResponse> {
    return this._http.get<GetReportedPostsResponse>(
      `${apiUrl}/api/report/posts?lastId=${0}&count=${100}`);
  }

  getReportedComments(): Observable<GetReportedCommentsResponse> {
    return this._http.get<GetReportedCommentsResponse>(
      `${apiUrl}/api/report/comments?lastId=${0}&count=${100}`);
  }

}
