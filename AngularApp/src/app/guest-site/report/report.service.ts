import { Injectable } from "@angular/core";
import { AuthenticationService } from "../../core/services/authentication.service";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { IUserDto } from "../../core/register-page/dto/user-dto";
import { environment } from "../../../environments/environment";
import { UserReportForm } from "../dto/user-report-form";
import { Observable } from "rxjs/Rx";
import { UserReportResponse } from "../dto/user-report-response";

const apiUrl = environment.apiUrl;

@Injectable()
export class UserReportService {

    constructor(private _authenticationService: AuthenticationService,
        private _http: HttpClient) {
    }

    getUsersReport(userReportForm: UserReportForm): Observable<UserReportResponse> {
        return this._http.get<UserReportResponse>(
            `${apiUrl}/api/user/report?username=${userReportForm.username}&sex=${userReportForm.sex}&status=${userReportForm.status}`);
    }

}