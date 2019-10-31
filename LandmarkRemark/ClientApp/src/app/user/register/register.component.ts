import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { UserFormService } from '../services/user-form.service';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';


@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css'],
    providers: [UserFormService, UserService]
})
export class RegisterComponent implements OnInit {

    registerForm: FormGroup;
    errorMessage: string;
    constructor(private userFormService: UserFormService,
        private userService: UserService,
        private router: Router) {


        this.registerForm = this.userFormService.getRegisterFormGroup();
    }

    ngOnInit() {

    }

    onSubmit() {
        if (this.registerForm.valid) {
            const requestPayload = {
                firstName: this.registerForm.controls.firstName.value,
                lastName: this.registerForm.controls.lastName.value,
                email: this.registerForm.controls.email.value,
                password: this.registerForm.controls.password.value,
            };
            this.userService.register(requestPayload).subscribe(response => {
                if (response === 0) {
                    this.errorMessage = "Email already registered";
                    return;
                }
                if (response && parseInt(response) > 0) {
                    this.errorMessage = '';
                    this.router.navigate(['/account/login']);
                    return;
                }
                this.errorMessage = 'Sorry, something went wrong, Please try agian.';

            }, error => {
                if (error) {
                    this.errorMessage = 'Sorry, something went wrong, Please try agian.';
                    return;
                }
            });
        }
        else {
            Object.keys(this.registerForm.controls).forEach(control => {
                (this.registerForm.get(control) as FormControl).markAsTouched({ onlySelf: true });
            });
        }
    }

}
