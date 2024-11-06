import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrl: './sign-in.component.scss',
})
export class SignInComponent {
  hide = signal(true);
  togglePasswordVisibility() {
    this.hide.set(!this.hide());
  }

  onClick() {
    console.log('test');
  }
}
