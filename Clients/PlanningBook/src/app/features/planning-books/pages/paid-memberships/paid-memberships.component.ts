import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-paid-memberships',
  templateUrl: './paid-memberships.component.html',
  styleUrl: './paid-memberships.component.scss'
})
export class PaidMembershipsComponent implements OnInit {
  #router = inject(Router);

  username = '';
  ngOnInit(): void {
    this.username = localStorage.getItem('username') ?? '';
  }

  onBackHomePage() {
    this.#router.navigateByUrl('/planning-books');
  }
}
