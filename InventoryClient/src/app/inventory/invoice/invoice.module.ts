import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { FormsModule } from '@angular/forms'

import { InvoiceRoutingModule } from './invoice-routing.module'
import { HomeComponent } from './pages/home/home.component'
import { AddEditComponent } from './pages/add-edit/add-edit.component'
import { MaterialModule } from '../../material/material.module'
import { ConfirmComponent } from './components/confirm/confirm.component';
import { ModalComponent } from './components/modal/modal.component'

@NgModule({
  declarations: [HomeComponent, AddEditComponent, ConfirmComponent, ModalComponent],
  imports: [CommonModule, InvoiceRoutingModule, FormsModule, MaterialModule]
})
export class InvoiceModule {}
