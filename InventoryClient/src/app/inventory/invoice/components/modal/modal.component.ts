import { Component, Inject } from '@angular/core'
import { MAT_DIALOG_DATA } from '@angular/material/dialog'
import { Invoice } from '../../interfaces/invoice.interfaces'
import { Product } from '../../../product/interfaces/product.interfaces';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styles: [
    `
      table {
        width: 100%;
      }
    `
  ]
})
export class ModalComponent {

  public product:Product = {
    productId: this.data.invoiceDetails[0]!.product.productId,
    name: this.data.invoiceDetails[0]!.product.name,
    description: this.data.invoiceDetails[0]!.product.description,
    cost: this.data.invoiceDetails[0]!.product.cost,
    price: this.data.invoiceDetails[0]!.product.price,
    stock: this.data.invoiceDetails[0]!.product.stock
  }

  constructor (@Inject(MAT_DIALOG_DATA) public data: any) {
  }
}
