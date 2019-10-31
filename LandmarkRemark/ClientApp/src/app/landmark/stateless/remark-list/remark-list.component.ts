import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'app-remark-list',
    templateUrl: './remark-list.component.html',
    styleUrls: ['./remark-list.component.css']
})
export class RemarkListComponent implements OnInit {

    @Input() noteList: any;
    constructor() { }

    ngOnInit() {
    }

}
