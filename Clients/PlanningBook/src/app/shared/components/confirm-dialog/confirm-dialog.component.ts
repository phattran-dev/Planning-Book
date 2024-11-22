import { Component, inject, Input, OnInit } from '@angular/core';
import { PaymentService } from '../../services/payment.service';
import { CheckoutCommand, ProductType } from '../../models/payment.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-confirm-dialog',
  templateUrl: './confirm-dialog.component.html',
  styleUrl: './confirm-dialog.component.scss',
  standalone: true,
})
export class ConfirmDialogComponent implements OnInit {
  data = inject(MAT_DIALOG_DATA);

  themeId = '';
  themeName = '';

  #paymentService = inject(PaymentService);
  #dialogRef = inject(MatDialogRef);

  ngOnInit(): void {
    if (this.data) {
      this.themeId = this.data?.themeId ?? '';
      this.themeName = this.data?.themeName ?? '';
    }
  }

  buyTheme() {
    const command: CheckoutCommand = {
      originUrl: 'http://localhost:4200',
      productId: this.themeId,
      productType: ProductType.Theme,
    };
    this.#paymentService.checkout(command).subscribe((res) => {
      if (!res.isSuccess) console.log('Failed');

      if (res.isSuccess && res.data) {
        console.log(res.data.urlCheckout);
        window.open(res.data.urlCheckout);
      }
    });
  }

  onClose() {
    this.#dialogRef.close();
  }
}
