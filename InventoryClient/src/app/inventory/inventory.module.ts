import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'

import { InventoryRoutingModule } from './inventory-routing.module'
import { InputSearchComponent } from './components/input-search/input-search.component'
import { MaterialModule } from '../material/material.module'
import { FormsModule } from '@angular/forms'

@NgModule({
  declarations: [InputSearchComponent],
  imports: [CommonModule, InventoryRoutingModule, FormsModule, MaterialModule],
  exports: [InputSearchComponent]
})
export class InventoryModule {}
