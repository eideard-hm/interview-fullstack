import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { HomeComponent } from './pages/home/home.component';
import { AddEditComponent } from './pages/add-edit/add-edit.component';


@NgModule({
  declarations: [
    HomeComponent,
    AddEditComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule
  ]
})
export class UserModule { }
