import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { LandmarkFormService } from '../../services/landmark-form.service';
import { LandmarkService } from '../../services/landmark.service';

@Component({
    selector: 'app-add-note',
    templateUrl: './add-note.component.html',
    styleUrls: ['./add-note.component.css'],
    providers: [LandmarkFormService]
})
export class AddNoteComponent implements OnInit {

    addNoteForm: FormGroup;
    @Input() message: string;
    @Output() addClicked: EventEmitter<any> = new EventEmitter<any>();

    constructor(private landMarkFormService: LandmarkFormService,
        private landMarkService: LandmarkService) { }

    ngOnInit() {
        this.addNoteForm = this.landMarkFormService.getAddNoteFormGroup();
    }

    onSubmit() {
        this.message = '';
        if (this.addNoteForm.valid) {            
            this.addClicked.emit({ note: this.addNoteForm.controls.note.value });
            this.addNoteForm.controls['note'].reset('');
        }
        else {
            (this.addNoteForm.get('note') as FormControl).markAsTouched({ onlySelf: true });
        }
    }
}
