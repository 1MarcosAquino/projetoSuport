import { Component, signal } from '@angular/core';
import { Router, RouterLink } from '@angular/router';

@Component({
    selector: 'app-dashboard-component',
    imports: [RouterLink],
    templateUrl: './dashboard-component.html',
    styleUrl: './dashboard-component.scss',
})
export class DashboardComponent {
    protected readonly title = signal('Dashboard');

    constructor(private router: Router) {
        this.onOnload();
    }

    onOnload() {
        const tokenIsvalid = this.validToken();

        if (!tokenIsvalid) {
            this.router.navigate(['']);
        }
    }

    validToken() {
        const token = localStorage.getItem('token') || '';

        return !token.trim() || token.trim() !== '1234';
    }
}
