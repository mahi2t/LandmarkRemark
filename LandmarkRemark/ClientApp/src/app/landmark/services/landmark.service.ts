import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
    providedIn: 'root'
})
export class LandmarkService {

    constructor(private httpClient: HttpClient) { }

    getAllNotes(): Observable<any> {
        const url = 'api/note/all';
        return this.httpClient.get(url);
    }

    getSearchResults(searchText: string): Observable<any> {
        const url =  `api/note/search?text=${searchText}`;
        return this.httpClient.get(url);
    }

    addNote(payload: any): Observable<any> {
        const url = 'api/note/add';
        return this.httpClient.post(url, payload);
    }
}
