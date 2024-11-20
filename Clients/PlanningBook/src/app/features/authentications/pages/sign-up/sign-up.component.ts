import { Component, inject, signal } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../../../shared/services/authentications.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.scss'
})
export class SignUpComponent {
  #router = inject(Router);
  #authenticationService = inject(AuthenticationService);

  signUpForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
    confirmPassword: new FormControl(''),
  });

  hide = signal(true);
  togglePasswordVisibility() {
    this.hide.set(!this.hide());
  }

  onClick() {
    console.log('test');
  }
}
