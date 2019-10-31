import { Component, OnInit } from '@angular/core';
import { LandmarkService } from '../../services/landmark.service';
import { UserService } from '../../../user/services/user.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { tokenGetter } from '../../../app.module';

@Component({
    selector: 'app-landmark',
    templateUrl: './landmark.component.html',
    styleUrls: ['./landmark.component.css']
})
export class LandmarkComponent implements OnInit {

    noteList: Array<any>;
    longitude: number = -33.885544;
    latitude: number = 151.211900;
    email: string;
    message: string;

    constructor(private landmarkService: LandmarkService,
        private userService: UserService,
        private jwtHelperSerivce: JwtHelperService) {
        if (navigator && !!navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(position => {
                this.latitude = +position.coords.latitude;
                this.longitude = +position.coords.longitude;
            });
        } else {
            // browser does not support.
        }
    }

    ngOnInit() {
        this.getAllNotes();
        this.email = this.getEmailFromToken();
      
    }

    onSearchClicked(event: any) {
        this.landmarkService.getSearchResults(event).subscribe(response => {
            if (response) {
                this.noteList = response;
            }
        });
    }

    getAllNotes() {
        this.landmarkService.getAllNotes().subscribe(response => {
            if (response) {
                this.noteList = response;
            }
        });
    }

    onMarkerAdded(event: any) {
        if (event) {
            this.latitude = event.latitude;
            this.longitude = event.longitude;
        }
    }

    onAddClicked(event: any) {
        if (event) {
            const requestPayload = {
                remark: event.note,
                latitude: this.latitude,
                longitude: this.longitude,
                email: this.email ? this.email : this.getEmailFromToken()
            }
            this.landmarkService.addNote(requestPayload)
                .subscribe(response => {
                    if (response) {
                        this.noteList = response;
                        this.message = "Added successfully."
                    }
                    error => {
                        if (error) {
                            this.message = 'Sorry!, something went wrong, please try again';
                            return;
                        }
                    }
                });
        }
    }

    getEmailFromToken(): string{
        var response = this.jwtHelperSerivce.decodeToken(tokenGetter());
        if (response) {
            return response["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"]
        }
    }
}
