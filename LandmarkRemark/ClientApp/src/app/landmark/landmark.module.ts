import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { LandmarkComponent } from '../landmark/stateful/landmark/landmark.component';
import { MapComponent } from '../landmark/stateless/map/map.component';
import { RemarkListComponent } from '../landmark/stateless/remark-list/remark-list.component';
import { AgmCoreModule } from '@agm/core';
import { AuthGuard } from '../user/services/auth.guard';
import { SharedModule } from '../shared/shared.module';
import { AddNoteComponent } from './stateless/add-note/add-note.component';
import { SearchComponent } from './stateless/search/search.component';

const routes: Routes = [
    {
        path: '', canActivate: [AuthGuard],
        children: [
            { path: '', redirectTo: 'landmark', pathMatch: 'full' },
            { path: 'landmark', component: LandmarkComponent },
            { path: 'remark', component: RemarkListComponent }
        ]
    }
];

@NgModule({
    declarations: [LandmarkComponent, MapComponent, RemarkListComponent, AddNoteComponent, SearchComponent],
    imports: [
        CommonModule,
        FormsModule,
        SharedModule,
        RouterModule.forChild(routes),
        ReactiveFormsModule,
        AgmCoreModule.forRoot({
            apiKey: 'Api-key'
        })
    ]
})
export class LandmarkModule { }
