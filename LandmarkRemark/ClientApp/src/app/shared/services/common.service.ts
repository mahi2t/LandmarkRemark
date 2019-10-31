import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class CommonService {
    private progressSubject: Subject<boolean> = new Subject<boolean>();
    progressState = this.progressSubject.asObservable();
    response: string;
    currentUrl: string;
    userTrainingDetails: any;
    searchText: string;

    setSearchText(searchText){
        this.searchText=searchText;
    }

    getSearchText():string    {
        return this.searchText;
    }

     show() {
        this.progressSubject.next(true);
    }

    hide() {
        this.progressSubject.next(false);
    }

    setResponse(url: string) {
        if (url && url.length > 10) {
            this.response = url.substring(url.lastIndexOf('/') + 1);
        }
    }

    getResponse(): string {
        return this.response;
    }

    scrollToError() {
        const firstElementWithError = document.querySelector('textarea.ng-invalid, input.ng-invalid, select.ng-invalid');

        if (firstElementWithError) {
            firstElementWithError.scrollIntoView({ behavior: 'smooth' });
        }
    }
}
