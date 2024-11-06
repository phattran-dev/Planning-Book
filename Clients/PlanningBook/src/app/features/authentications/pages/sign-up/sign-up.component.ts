import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.scss'
})
export class SignUpComponent {
  hide = signal(true);
  togglePasswordVisibility() {
    this.hide.set(!this.hide());
  }

  onClick() {
    console.log('test');
  }
}
