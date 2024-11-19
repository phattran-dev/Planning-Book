export interface BaseResult<T> {
    data?: T;
    isSuccess: boolean;
    errorCode?: string;
    errorMessage: string;
}