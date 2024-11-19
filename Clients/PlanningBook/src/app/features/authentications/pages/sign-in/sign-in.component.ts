import { Component, inject, OnInit, signal } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../../../shared/services/authentications.service';
import { FormControl, FormGroup } from '@angular/forms';

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
    // console.log('Hit');
    // this.#authenticationService.signIn();
    console.log(this.signInForm.value);
    this.#router.navigateByUrl('/planning-books');
  }
}
