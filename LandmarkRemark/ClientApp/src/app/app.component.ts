import { Component, OnInit, OnDestroy } from '@angular/core';
import { UserService } from '../app/user/services/user.service';
import { CommonService } from './shared/services/common.service';
import { Router, NavigationEnd, NavigationStart } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { tokenGetter } from './app.module';


@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy {
    routerEvents: any;

    title = 'Landmark Remark';
    userName: any;
    showProgress = false;

    constructor(private userService: UserService,
        private commonService: CommonService,
        private jwtHelperService: JwtHelperService,
        private router: Router) {
        this.commonService.progressState.subscribe((value: boolean) => {
            this.showProgress = value;
        });
        this.routerEvents = this.router.events.subscribe(event => {
            if (event instanceof NavigationEnd) {
                if (event.url.indexOf('account') == -1) {
                    const token = tokenGetter();
                    const response = this.jwtHelperService.decodeToken(token);
                    if (response) {
                        this.userName = response["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"] + ','
                            + response["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname"];
                    }
                }
                else {
                    localStorage.removeItem('authToken');
                    this.userName = undefined;
                }
            }
        });
    }

    ngOnInit() {
    }

    ngOnDestroy() {
        this.routerEvents.unsubscribe();
    }

    onSearchClicked(event: any) {
        this.commonService.setSearchText(event);
    }
}

