import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';

// Common module
import { SharedModule } from './shared/shared.module';

// Services
import { InterceptorService } from './shared/services/interceptor.service';


export function tokenGetter() {
    return localStorage.getItem("authToken");
}


@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        SharedModule,
        JwtModule.forRoot({
            config: {
                tokenGetter: tokenGetter,
                skipWhenExpired: true
            }
        })
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: InterceptorService, multi: true }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
