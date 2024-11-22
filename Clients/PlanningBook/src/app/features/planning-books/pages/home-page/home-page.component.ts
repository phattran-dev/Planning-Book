import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../../../shared/services/authentications.service';
import { PaymentService } from '../../../../shared/services/payment.service';
import { CheckoutCommand, ProductType } from '../../../../shared/models/payment.model';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.scss'
})
export class HomePageComponent implements OnInit {
  #router = inject(Router);
  #paymentService = inject(PaymentService);

  readonly themes = [
    {
      id: "835bc37f-8891-48da-9f01-4bfcbf50ab13",
      name: 'black',
      price: 150
    },
    {
      id: "27784869-292e-47e8-be5f-311d7a4aaf14",
      name: 'White',
      price: 250
    },
    {
      id: "eea6122c-c5d8-40f1-a44a-766008241255",
      name: 'Rain',
      price: 400
    },
  ]
  ngOnInit(): void {
  }

  onMembership() {
    this.#router.navigateByUrl('/memberships');
  }

  buyTheme(themeIndex: number) {
    const theme = this.themes[themeIndex];
    const command: CheckoutCommand = {
      originUrl: 'http://localhost:4200',
      productId: theme.id,
      productType: ProductType.Theme
    };
    this.#paymentService.checkout(command).subscribe(res => {
      if (!res.isSuccess)
        console.log('Failed');

      if (res.isSuccess && res.data) {
        // this.#router.navigateByUrl();
        console.log(res.data.urlCheckout);
        window.open(res.data.urlCheckout)
      }
    })
  }
}
