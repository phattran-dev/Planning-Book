import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-paid-memberships',
  templateUrl: './paid-memberships.component.html',
  styleUrl: './paid-memberships.component.scss'
})
export class PaidMembershipsComponent implements OnInit {

  #router = inject(Router);

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  onBackHomePage() {
    this.#router.navigateByUrl('/planning-books');
  }
}
