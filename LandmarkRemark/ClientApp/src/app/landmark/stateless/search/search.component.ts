import { Component, OnInit, EventEmitter, Output } from '@angular/core';

@Component({
    selector: 'app-search',
    templateUrl: './search.component.html',
    styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

    searchText: string;
    @Output() searchClicked: EventEmitter<any> = new EventEmitter<any>();

    constructor() { }

    ngOnInit() {
    }

    onSearch(searchText: any) {
        this.searchClicked.emit(searchText);
        this.searchText='';
    }
}
