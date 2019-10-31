import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Injectable()
export class LandmarkFormService {

    constructor(private formBuilder: FormBuilder) { }

    getAddNoteFormGroup(): FormGroup {
        return this.formBuilder.group({
            note: ['', Validators.compose([Validators.required])]
        });
    }
}
