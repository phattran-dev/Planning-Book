import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountComponent } from './account.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { ChangePasswordComponent } from './pages/change-password/change-password.component';
import { PaymentMethodsComponent } from './pages/payment-methods/payment-methods.component';
import { PrivacySettingComponent } from './pages/privacy-setting/privacy-setting.component';
import { SiteSettingComponent } from './pages/site-setting/site-setting.component';

const routes: Routes = [
  {
    path: '', component: AccountComponent,
    children: [
      {
        path: '',
        redirectTo: 'profile',
        pathMatch: 'full'
      },
      {
        path: 'profile',
        component: ProfileComponent
      },
      {
        path: 'change-password',
        component: ChangePasswordComponent
      },
      {
        path: 'payment-methods',
        component: PaymentMethodsComponent
      },
      {
        path: 'privacy-setting',
        component: PrivacySettingComponent
      },
      {
        path: 'site-setting',
        component: SiteSettingComponent
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
