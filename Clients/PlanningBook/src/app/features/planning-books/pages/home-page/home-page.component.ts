import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.scss'
})
export class HomePageComponent implements OnInit {
  #router = inject(Router);

  ngOnInit(): void {
  }

  onMembership() {
    console.log('Hit');
    this.#router.navigateByUrl('/memberships');
  }
}
