import { Component, OnInit, Input,  SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

    userLoggedIn = false;
    @Input() userName: string;

    ngOnInit() {
    }
    ngOnChanges(changes: SimpleChanges) {
        if (changes && changes.userName && changes.userName.currentValue) {
            this.userLoggedIn = true;
        }
    }

    constructor(private router: Router) { }

    logOut() {
        localStorage.removeItem('authToken');
        this.userName = undefined;
        this.userLoggedIn = false;
        this.router.navigate(['/account/login']);
        return false;
    }
}
