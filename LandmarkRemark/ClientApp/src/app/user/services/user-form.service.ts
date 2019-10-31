import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Injectable()
export class UserFormService {

  constructor(private formBuilder: FormBuilder) { }

  getLoginFormGroup(): FormGroup {
    return this.formBuilder.group({
      username: ['', Validators.compose([Validators.required,
          Validators.pattern('^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$')])],
      password: ['', Validators.compose([Validators.required])]
    });
  }

  getRegisterFormGroup(): FormGroup {
    return this.formBuilder.group({
      firstName: ['', Validators.compose([Validators.required, Validators.pattern('^[a-zA-Z ]+$')])],
      lastName: ['', Validators.compose([Validators.required, Validators.pattern('^[a-zA-Z]+$')])],
      password: ['', Validators.compose([Validators.required])],
      confirmPassword: ['', Validators.compose([Validators.required])],
      email: ['', Validators.compose([
        Validators.required,
        Validators.pattern('^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$')])]
    });
  }

}
