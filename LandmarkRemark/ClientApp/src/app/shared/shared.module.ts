import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

// Components
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { ProgressComponent } from './progress/progress.component';

@NgModule({
    declarations: [
        HeaderComponent,
        FooterComponent,
        ProgressComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
        FormsModule
    ],
    exports: [
        HeaderComponent,
        FooterComponent,
        ProgressComponent
    ]
})
export class SharedModule { }
