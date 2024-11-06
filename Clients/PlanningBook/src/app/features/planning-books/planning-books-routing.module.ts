import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PlanningBooksComponent } from './planning-books.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { PaidMembershipsComponent } from './pages/paid-memberships/paid-memberships.component';

const routes: Routes = [
  {
    path: '',
    component: PlanningBooksComponent,
    children: [
      {
        path: '',
        component: HomePageComponent
      },
      {
        path: 'memberships',
        component: PaidMembershipsComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PlanningBooksRoutingModule { }
