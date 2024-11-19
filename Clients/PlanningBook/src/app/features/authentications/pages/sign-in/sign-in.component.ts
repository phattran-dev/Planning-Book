import { Component, inject, OnInit, signal } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrl: './sign-in.component.scss',
})
export class SignInComponent implements OnInit {
  #router = inject(Router);
  #

  ngOnInit(): void {
  }

  hidePassword = signal(true);
  togglePasswordVisibility() {
    this.hidePassword.set(!this.hidePassword());
  }

  onSignIn() {
    console.log('Hit');
    this.#router.navigateByUrl('/planning-books');
  }
}
