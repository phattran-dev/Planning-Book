import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PlanningBooksRoutingModule } from './planning-books-routing.module';
import { PlanningBooksComponent } from './planning-books.component';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    PlanningBooksComponent
  ],
  imports: [
    CommonModule,
    PlanningBooksRoutingModule,
    RouterModule
  ]
})
export class PlanningBooksModule { }
