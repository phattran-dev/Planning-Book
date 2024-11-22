import { Component, inject, signal } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../../../shared/services/authentications.service';
import { SignUpRequest } from '../../../../shared/models/authentications.model';
import { catchError, of } from 'rxjs';

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

  onSignUp() {
    if (this.signUpForm.controls.password.value !== this.signUpForm.controls.confirmPassword.value) {
      console.log('Sign Up Error 1');
      return;
    }

    const signUpRequest: SignUpRequest = {
      userName: this.signUpForm.controls.username.value ?? '',
      password: this.signUpForm.controls.password.value ?? ''
    };

    this.#authenticationService.signUp(signUpRequest).subscribe(res => {
      if (res.isSuccess && res.data) {
        this.#router.navigateByUrl('/sign-in');
      } else {
        console.log('SignIn Error 2');
      }
    }, catchError(err => {
      console.log('SignIn Error 3');
      console.log(err);
      return of();
    }));

  }
}
