import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';

@Component({
    selector: 'app-sing-in-component',
    imports: [CommonModule, RouterLink, ReactiveFormsModule],
    standalone: true,
    templateUrl: './sing-in-component.html',
    styleUrl: './sing-in-component.scss',
})
export class SingInComponent {
    protected readonly title = signal('Entrar');

    private fb = inject(FormBuilder);
    private router = inject(Router);

    protected loading = false;

    protected form = this.fb.group({
        username: ['', [Validators.required, Validators.minLength(3)]],
        password: ['', [Validators.required, Validators.minLength(6)]],
    });

    constructor(private http: HttpClient) {}

    onSubmit() {
        if (this.form.invalid) {
            this.form.markAllAsTouched();
            return;
        }

        if (this.form.invalid) {
            this.form.markAllAsTouched();
            return;
        }

        this.loading = true;

        this.http
            .post<{ token: string }>('http://localhost:5053/api/user/sing-in', this.form.value, {
                headers: { 'Content-Type': 'application/json' },
            })
            .subscribe({
                next: response => {
                    if (response.token) {
                        this.saveToken(response.token);
                        this.form.reset();
                        this.redirect();
                        this.loading = false;
                    }
                },
                error: err => {
                    console.error('Erro ao enviar:', err);
                    this.loading = false;
                },
            });
    }

    saveToken(token: string) {
        localStorage.setItem('app_support', token);
    }

    redirect() {
        console.log('redirect');
        this.router.navigate(['/dashboard']);
    }
}
