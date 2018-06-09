import { Injectable } from "@angular/core";
import { Observable } from 'rxjs/Observable';
import { HttpClient } from "@angular/common/http";
import { environment } from "../../../environments/environment";
import { IAuthorUserDto } from "../../core/register-page/dto/author-user-dto";

const apiUrl = environment.apiUrl;

@Injectable()
export class UserInformationService {

    constructor(private _http: HttpClient) {
    }

    getUserInfo(username: string): Observable<IAuthorUserDto> {
        return this._http.get<IAuthorUserDto>(`${apiUrl}/${username}`);
      }
}