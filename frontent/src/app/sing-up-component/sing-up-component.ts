import { CommonModule } from '@angular/common';
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

    protected form = this.fb.group(
        {
            username: ['', [Validators.required, Validators.minLength(3)]],
            email: ['', [Validators.required, Validators.email]],
            password: ['', [Validators.required, Validators.minLength(6)]],
            confirmPassword: ['', [Validators.required]],
        },
        { validators: this.passwordMatchValidator }
    );

    passwordMatchValidator(form: any) {
        const password = form.get('password')?.value;
        const confirm = form.get('confirmPassword')?.value;

        return password === confirm ? null : { passwordMismatch: true };
    }

    register() {
        if (this.form.invalid) {
            this.form.markAllAsTouched();
            return;
        }

        this.send();

        this.redirect();
    }

    send() {
        console.log(this.form.value);
    }

    redirect() {
        this.router.navigate(['/sign-in']);
    }
}
