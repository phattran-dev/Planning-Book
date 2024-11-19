import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { catchError, Observable, of } from "rxjs";
import { BaseResult } from "../models/general.model";
import { SignInRequest, SignInResponse, SignUpRequest } from "../models/authentications.model";
import { API_ENDPOINTS } from "../constants/url.constant";

export const mainUrl = `${API_ENDPOINTS.AUTHENTICATION}/identity`
@Injectable()
export class AuthenticationService {
    #http = inject(HttpClient);

    signUp(request: SignUpRequest): Observable<BaseResult<string>> {
        return this.#http
            .post<BaseResult<string>>(`${API_ENDPOINTS.AUTHENTICATION}/sign-up`, request)
            .pipe(catchError(err => {
                console.log(err);
                return of();
            }));
    }

    signIn(request: SignInRequest): Observable<BaseResult<SignInResponse>> {
        return this.#http
            .post<BaseResult<SignInResponse>>(`${API_ENDPOINTS.AUTHENTICATION}/sign-in`, request)
            .pipe(catchError(err => {
                console.log(err);
                return of();
            }));
    }
}