import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'account', loadChildren: () => import('./user/user.module').then(m => m.UserModule) },
  { path: 'dashboard', loadChildren: () => import('./landmark/landmark.module').then(m => m.LandmarkModule) },
  { path: '**', redirectTo: 'account', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
