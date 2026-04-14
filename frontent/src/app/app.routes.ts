import { Routes } from '@angular/router';

import { DashboardComponent } from './dashboard-component/dashboard-component';
import { SingInComponent } from './sing-in-component/sing-in-component';
import { SingUpComponent } from './sing-up-component/sing-up-component';

export const routes: Routes = [
    { path: '', redirectTo: 'sign-in', pathMatch: 'full' },
    { path: 'sign-in', component: SingInComponent },
    { path: 'sign-up', component: SingUpComponent },
    { path: 'home', component: DashboardComponent },
    { path: '**', redirectTo: 'sign-in' },
];
