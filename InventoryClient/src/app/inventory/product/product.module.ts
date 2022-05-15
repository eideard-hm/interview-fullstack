import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'

import { ProductRoutingModule } from './product-routing.module';
import { HomeComponent } from './pages/home/home.component';
import { AddEditComponent } from './pages/add-edit/add-edit.component'

@NgModule({
  declarations: [
    HomeComponent,
    AddEditComponent
  ],
  imports: [CommonModule, ProductRoutingModule]
})
export class ProductModule {}
