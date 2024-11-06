import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountRoutingModule } from './account-routing.module';
import { AccountComponent } from './account.component';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    AccountComponent
  ],
  exports: [
    AccountComponent
  ],
  imports: [
    CommonModule,
    AccountRoutingModule,
    RouterModule
  ]
})
export class AccountModule { }
