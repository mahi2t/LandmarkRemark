import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'app-map',
    templateUrl: './map.component.html',
    styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {

    selectedMarker: any;
    zoom: number = 15;

    @Input() latitude: number;
    @Input() longitude: number;
    @Input() markersList: any;
    @Input() email: string;
    @Output() markedAdded: EventEmitter<any> = new EventEmitter<any>();
    @Output() searchClicked: EventEmitter<any> = new EventEmitter<any>();

    constructor() { }

    ngOnInit() {
    }

    selectMarker(event) {
        this.selectedMarker = {
            lat: event.latitude,
            lng: event.longitude
        };
    }

    addMarker(event) {
        const coordinates = {
            latitude: event.coords.lat,
            longitude: event.coords.lng,
            email: this.email
        }
        this.markedAdded.emit(coordinates);
    }

    onSearchClicked(event: any) {
        this.searchClicked.emit(event)
    }
}
