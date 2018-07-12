import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "../../../environments/environment";
import { Observable } from "rxjs/Rx";
import { UserReportForm } from "../../guest-site/dto/user-report-form";
import { UserReportResponse } from "../../guest-site/dto/user-report-response";

const apiUrl = environment.apiUrl;

@Injectable()
export class UserReportService {

    constructor(
        private _http: HttpClient
    ) {
    }

    getUsersReport(userReportForm: UserReportForm): Observable<UserReportResponse> {
        return this._http.get<UserReportResponse>(
            `${apiUrl}/api/user/report?username=${userReportForm.username}&sex=${userReportForm.sex}&status=${userReportForm.status}`);
    }

}