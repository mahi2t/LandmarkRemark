import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';


@Injectable({
    providedIn: 'root'
})
export class UserService {

    constructor(private httpClient: HttpClient,
        private jwtHelperService: JwtHelperService) { }

    login(payload: any): Observable<any> {
        const url = 'api/authentication/login';
        return this.httpClient.post(url, payload);
    }

    logOut() {
        return localStorage.removeItem('authToken');
    }

    register(payload: any): Observable<any> {
        const url = 'api/user/register';
        return this.httpClient.post(url, payload);
    }

    isUserLoggedIn(): boolean {
        if (localStorage.getItem('authToken')) {
            return true;
        } else {
            return false;
        }
    }

    getAuthToken(): string {
        return localStorage.getItem('authToken') ? localStorage.getItem('authToken').toString() : undefined;
    }

    getUserDetails(): any {
        if (localStorage.getItem('authToken')) {

        }
    }
}
