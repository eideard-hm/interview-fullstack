import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { FormsModule } from '@angular/forms';

import { ProductRoutingModule } from './product-routing.module';
import { HomeComponent } from './pages/home/home.component';
import { AddEditComponent } from './pages/add-edit/add-edit.component'
import { MaterialModule } from '../../material/material.module';
import { ConfirmComponent } from './components/confirm/confirm.component';
import { InventoryModule } from '../inventory.module';

@NgModule({
  declarations: [
    HomeComponent,
    AddEditComponent,
    ConfirmComponent
  ],
  imports: [CommonModule, ProductRoutingModule, MaterialModule,
  FormsModule, InventoryModule]
})
export class ProductModule {}
