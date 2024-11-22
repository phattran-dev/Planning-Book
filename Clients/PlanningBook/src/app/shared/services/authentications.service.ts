import { HttpClient, HttpHeaders } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { catchError, Observable, of } from "rxjs";
import { BaseResult } from "../models/general.model";
import { SignInRequest, SignInResponse, SignUpRequest } from "../models/authentications.model";
import { API_ENDPOINTS } from "../constants/url.constant";

export const mainUrl = `${API_ENDPOINTS.AUTHENTICATION}/identity`
@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {
    #http = inject(HttpClient);

    signUp(request: SignUpRequest): Observable<BaseResult<string>> {
        return this.#http
            .post<BaseResult<string>>(`${mainUrl}/sign-up`, request)
            .pipe(catchError(err => {
                console.log(err);
                return of();
            }));
    }

    signIn(request: SignInRequest): Observable<BaseResult<SignInResponse>> {
        return this.#http
            .post<BaseResult<SignInResponse>>(`${mainUrl}/sign-in`, request)
            .pipe(catchError(err => {
                console.log(err);
                return of();
            }));
    }

    test(): Observable<any> {
        const token = localStorage.getItem('token');
        const headers = new HttpHeaders({
            Authorization: `Bearer ${token}`,
        });
        // return this.#http.get<any>(`${API_ENDPOINTS.AUTHENTICATION}/api/HealthCheck/NonAuth`);
        return this.#http.get<any>(`${API_ENDPOINTS.AUTHENTICATION}/api/HealthCheck/HasAuth`, { headers });
    }
}