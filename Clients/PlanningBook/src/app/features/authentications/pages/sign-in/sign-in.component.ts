import { Component, inject, OnInit, signal } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../../../shared/services/authentications.service';
import { FormControl, FormGroup } from '@angular/forms';
import { SignInRequest } from '../../../../shared/models/authentications.model';
import { catchError, of } from 'rxjs';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrl: './sign-in.component.scss',
})
export class SignInComponent implements OnInit {
  #router = inject(Router);
  #authenticationService = inject(AuthenticationService);

  signInForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl('')
  });

  ngOnInit(): void {
  }

  hidePassword = signal(true);
  togglePasswordVisibility() {
    this.hidePassword.set(!this.hidePassword());
  }

  onSignIn() {
    const signInRequest: SignInRequest = {
      userName: this.signInForm.controls.username.value ?? '',
      password: this.signInForm.controls.password.value ?? ''
    };

    this.#authenticationService.signIn(signInRequest).subscribe(res => {
      if (res.isSuccess && res.data) {
        localStorage.setItem('token', res.data?.token);
        localStorage.setItem('refresh-token', res.data?.refreshToken);
        localStorage.setItem('user-id', res.data?.userId);
        localStorage.setItem('username', signInRequest.userName);
        this.#router.navigateByUrl('/planning-books');
      } else {
        console.log('SignIn Error 1');
      }
    }, catchError(err => {
      console.log('SignIn Error 2');
      console.log(err);
      return of();
    }));

  }
}
