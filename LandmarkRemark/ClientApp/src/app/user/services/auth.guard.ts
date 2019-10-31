import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from './user.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {
    constructor(
        private userService: UserService,
        private router: Router,
        private jwtHelperService: JwtHelperService
    ) { }

    canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
        const token = this.userService.getAuthToken();
        if (!token || this.jwtHelperService.isTokenExpired(token)) {
            this.router.navigate(['/'], { queryParams: { returnUrl: state.url } });
        }
        else {
        }
        return this.userService.isUserLoggedIn();
    }
}
