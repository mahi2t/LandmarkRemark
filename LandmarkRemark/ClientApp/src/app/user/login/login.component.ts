import { Component, OnInit } from '@angular/core';
import { UserFormService } from '../services/user-form.service';
import { FormGroup, FormControl } from '@angular/forms';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
    providers: [UserFormService, UserService]
})
export class LoginComponent implements OnInit {

    submitting = false;
    errorMessage = '';
    loginForm: FormGroup;

    constructor(
        private userService: UserService,
        private userFormService: UserFormService,
        private router: Router) {
        this.loginForm = this.userFormService.getLoginFormGroup();
    }

    ngOnInit() {
    }

    onSubmit() {
        if (this.loginForm.valid) {
            this.submitting = true;
            this.errorMessage = '';
            const requestPayload = {
                userName: this.loginForm.controls.username.value,
                password: this.loginForm.controls.password.value,
            };
            this.userService.login(requestPayload).subscribe(response => {
                if (response && response.token) {
                    localStorage.setItem('authToken', response.token);
                    this.router.navigate(['/dashboard']);
                    return;
                }
                else {
                    this.submitting = false;
                    if (response && !response.isUserExists) {
                        this.errorMessage = 'User Not found, Please register';
                        return;
                    }
                    this.errorMessage = 'Invalid Username or Password';
                }
            }, error => {
                if (error) {
                    this.submitting = false;
                    this.errorMessage = 'Invalid Username or Password';
                    return;
                }
            });
        }
        else {
            Object.keys(this.loginForm.controls).forEach(control => {
                (this.loginForm.get(control) as FormControl).markAsTouched({ onlySelf: true });
            });
        }
    }
}
