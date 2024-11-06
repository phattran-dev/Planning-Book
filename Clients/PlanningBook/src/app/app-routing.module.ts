import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from './features/general/pages/page-not-found/page-not-found.component';
import { AccountModule } from './features/account/account.module';
import { AuthenticationsModule } from './features/authentications/authentications.module';
import { PlanningBooksModule } from './features/planning-books/planning-books.module';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./features/authentications/authentications.module').then(m => m.AuthenticationsModule),
  },
  {
    path: 'account',
    // canActivate: [AuthGuard], TODO: AuthGuard
    loadChildren: () => import('./features/account/account.module').then(m => m.AccountModule)
  },
  {
    path: 'planning-books',
    // canActivate: [AuthGuard], TODO: AuthGuard
    loadChildren: () => import('./features/planning-books/planning-books.module').then(m => m.PlanningBooksModule)
  },
  {
    path: '**',
    redirectTo: 'page-not-found',
    pathMatch: 'full'
  },
  {
    path: 'page-not-found',
    component: PageNotFoundComponent
  }
];

@NgModule({
  imports: [
    AuthenticationsModule,
    AccountModule,
    PlanningBooksModule,
    RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
