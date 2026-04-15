import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';

@Component({
    selector: 'app-sing-up-component',
    imports: [CommonModule, RouterLink, ReactiveFormsModule],
    templateUrl: './sing-up-component.html',
    styleUrl: './sing-up-component.scss',
})
export class SingUpComponent {
    protected readonly title = signal('Registrar');

    private fb = inject(FormBuilder);
    private router = inject(Router);

    protected loading = false;

    protected form = this.fb.group(
        {
            username: ['', [Validators.required, Validators.minLength(3)]],
            // email: ['', [Validators.required, Validators.email]],
            password: ['', [Validators.required, Validators.minLength(6)]],
            confirmPassword: ['', [Validators.required]],
        },
        { validators: this.passwordMatchValidator }
    );

    constructor(private http: HttpClient) {}

    passwordMatchValidator(form: any) {
        const password = form.get('password')?.value;
        const confirm = form.get('confirmPassword')?.value;

        return password === confirm ? null : { passwordMismatch: true };
    }

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
            .post('http://localhost:5053/api/user/sing-up', this.form.value, {
                headers: { 'Content-Type': 'application/json' },
            })
            .subscribe({
                next: response => {
                    console.log({ response });

                    this.form.reset();
                    this.loading = false;
                    // this.redirect();
                },
                error: err => {
                    console.error('Erro ao enviar:', err);
                    this.loading = false;
                },
            });
    }

    redirect() {
        this.router.navigate(['/sign-in']);
    }
}
