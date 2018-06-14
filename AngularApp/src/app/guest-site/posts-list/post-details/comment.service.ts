import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { AuthenticationService } from '../../../core/services/authentication.service';
import { IGetCommentsResponse } from '../../dto/get-comments-response';
import { ILike } from '../../dto/like-dto';
import { UpdateCommentRequest } from '../../dto/update-comment-request';

const apiUrl = environment.apiUrl;

@Injectable()
export class CommentService {

    constructor(private _http: HttpClient, private _authenticationService: AuthenticationService) { }

    addComment(comment): Observable<any> {


        return this._http.post<any>(`${apiUrl}/api/comment`, comment);
    }

    getComments(postId, lastId, count): Observable<IGetCommentsResponse> {

        return this._http.get<IGetCommentsResponse>(`${apiUrl}/api/comment?postId=${postId}&lastId=${lastId}&count=${count}`);
    }
	
	getCommentLikeForUser(commentId: number): Observable<ILike>{

        return this._http.get<ILike>(`${apiUrl}/api/like/get-comment?commentId=${commentId}`);
	}
	
	updateCommentRating(commentId: number, rating: number): Promise<any> {
    return this._http.put(`${apiUrl}/api/comment/update-rating`, new UpdateCommentRequest(commentId, rating), {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }).toPromise();
	}
	
	addOrRemoveLike(commentLike: ILike): Promise<any>{

        const httpOptions = {
            headers: new HttpHeaders()
                .set('Content-Type', 'application/json')
        };
        
        return this._http.post(`${apiUrl}/api/like/add-comment`, JSON.stringify(commentLike), httpOptions).toPromise();
    }
}