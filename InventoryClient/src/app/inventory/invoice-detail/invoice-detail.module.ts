import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InvoiceDetailRoutingModule } from './invoice-detail-routing.module';
import { HomeComponent } from './pages/home/home.component';
import { MaterialModule } from '../../material/material.module';


@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    InvoiceDetailRoutingModule,
    MaterialModule
  ]
})
export class InvoiceDetailModule { }
