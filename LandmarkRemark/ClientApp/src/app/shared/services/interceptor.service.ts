import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpEvent, HttpRequest, HttpHandler, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { CommonService } from './common.service';

@Injectable()
export class InterceptorService implements HttpInterceptor {
    totalRequests = 0;
    constructor(
        private commonService: CommonService
    ) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        this.totalRequests++;
        this.commonService.show();
        var token = localStorage.getItem('authToken');
        if (req.url.indexOf('account') === -1) {
            if (token) {
                req = req.clone({
                    setHeaders: {
                        'Authorization': 'Bearer ' + token,
                        'Content-Type': 'application/json'
                    }
                });
            }
        } else {
            req = req.clone({
                setHeaders: {
                    'content-type': 'application/json',
                }
            });
        }

        return next.handle(req)
            .pipe(finalize(() => {
                this.decreaseRequests();
            }));
    }

    private decreaseRequests() {
        this.totalRequests--;
        if (this.totalRequests === 0) {
            this.commonService.hide();
        }
    }

}
