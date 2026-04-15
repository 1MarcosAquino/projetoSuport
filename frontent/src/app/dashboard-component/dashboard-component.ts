import { HttpClient } from '@angular/common/http';
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

    constructor(
        private http: HttpClient,
        private router: Router
    ) {
        this.onOnload();
    }

    onOnload() {
        const token = this.getToken();

        this.http
            .get('http://localhost:5053/api/user/auth', {
                headers: {
                    'Content-Type': 'application/json',
                    Authorization: `Bearer ${token}`,
                },
            })
            .subscribe({
                next: response => {
                    console.log(response);
                },
                error: err => {
                    console.error('Erro ao enviar:', err);
                    this.redirect();
                },
            });
    }

    getToken() {
        return localStorage.getItem('app_support') || '';
    }

    redirect() {
        this.router.navigate(['']);
    }
}
