import { CommonModule } from '@angular/common';
import { Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';

@Component({
    selector: 'app-sing-in-component',
    imports: [CommonModule, RouterLink, ReactiveFormsModule],
    // standalone: true,
    templateUrl: './sing-in-component.html',
    styleUrl: './sing-in-component.scss',
})
export class SingInComponent {
    protected readonly title = signal('Entrar');

    private fb = inject(FormBuilder);
    private router = inject(Router);

    protected form = this.fb.group({
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required, Validators.minLength(6)]],
    });

    login() {
        if (this.form.invalid) {
            this.form.markAllAsTouched();
            return;
        }

        const token = this.send();

        this.saveToken(token);
        this.redirect();
    }

    send() {
        console.log(this.form.value);

        const token = '1234';

        return token;
    }

    saveToken(token: string) {
        localStorage.setItem('token', token);
    }

    redirect() {
        this.router.navigate(['/home']);
    }
}
