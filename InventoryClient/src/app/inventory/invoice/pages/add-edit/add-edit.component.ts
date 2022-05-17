import { Component, OnInit } from '@angular/core'
import { Router } from '@angular/router'

import { MatSnackBar } from '@angular/material/snack-bar'
import { environment } from 'src/environments/environment'

import { InvoiceService } from '../../services/invoice.service'
import { ProductService } from '../../../product/services/product.service'
import { Product } from '../../../product/interfaces/product.interfaces'
import { Invoice } from '../../interfaces/invoice.interfaces'

@Component({
  selector: 'app-add-edit',
  templateUrl: './add-edit.component.html',
  styles: []
})
export class AddEditComponent implements OnInit {
  public title: string = 'Nueva'

  public products: Product[] = []

  public invoice: Invoice = {
    invoiceNumber: 0,
    invoiceDate: '',
    concept: '',
    invoiceDetails: [
      {
        productId!: 0,
        quantitySold: 0
      }
    ],
    userId: environment.userId
  }

  constructor (
    private readonly router: Router,
    private readonly _invoiceService: InvoiceService,
    private readonly _productService: ProductService,
    private readonly snackBar: MatSnackBar
  ) {}

  ngOnInit () {
    this.loadProducts()
  }

  save () {
    if (
      this.invoice.invoiceNumber <= 0 ||
      this.invoice.invoiceDate === '' ||
      this.invoice.concept.length <= 3 ||
      this.invoice.invoiceDetails[0]!.productId <= 0
    ) {
      this.showSnackBar('Todos los campos son obligatorios!')
      return
    }

    this._invoiceService.addInvoice(this.invoice).subscribe({
      next: invoice => {
        this.router.navigate(['/invoice'])
        this.showSnackBar(invoice?.message);
      },
      error: () => {
        this.router.navigate(['/invoice'])
      }
    })
  }

  loadProducts () {
    this._productService.getProducts().subscribe({
      next: products => (this.products = products),
      error: () => this.router.navigate(['/invoice'])
    })
  }

  showSnackBar (msj: string) {
    this.snackBar.open(msj, 'Ok!', {
      duration: 2500
    })
  }
}
