export interface SignInRequest {
    userName: string;
    password: string;
}

export interface SignInResponse {
    userId: string;
    token: string;
    refreshToken: string;
}

export interface SignUpRequest {
    userName: string;
    password: string;
}
