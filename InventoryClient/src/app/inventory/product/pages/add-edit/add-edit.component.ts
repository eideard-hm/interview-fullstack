import { Component, OnInit } from '@angular/core'
import { ActivatedRoute, Router } from '@angular/router'
import { MatSnackBar } from '@angular/material/snack-bar'
import { switchMap } from 'rxjs'
import { ProductService } from '../../services/product.service'
import { Product } from '../../interfaces/product.interfaces'
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-add-edit',
  templateUrl: './add-edit.component.html',
  styles: []
})
export class AddEditComponent implements OnInit {
  public title: string = 'Nuevo'

  public product: Product = {
    name: '',
    description: '',
    cost: 0,
    price: 0,
    stock: 0
  }

  constructor (
    private readonly activedRoute: ActivatedRoute,
    private readonly router: Router,
    private readonly _productService: ProductService,
    private readonly snackBar: MatSnackBar,
    private readonly _title: Title
  ) {}

  ngOnInit (): void {
    if (this.router.url.includes('edit')) {
      this.title = 'Editar'
      this._title.setTitle(`${this.title} Producto | Inventory`)
      this.activedRoute.params
        .pipe(switchMap(({ id }) => this._productService.getProductById(id)))
        .subscribe(product => (this.product = product))
    }
    this._title.setTitle(`${this.title} Producto | Inventory`)
  }

  save () {
    // some validation
    if (
      this.product.name.trim().length <= 0 ||
      this.product.description.trim().length <= 0 ||
      this.product.cost <= 0 ||
      this.product.price <= 0
    ) {
      this.showSnackBar('Todos los campos son obligatorios!')
      return
    }

    // editar
    if (this.product.productId) {
      this._productService
        .updateProduct(this.product.productId, this.product)
        .subscribe({
          next: ({ message }) => {
            this.router.navigate(['/product'])
            this.showSnackBar(message)
          },
          error: () => {
            this.router.navigate(['/product'])
            this.showSnackBar('Ocurrió un error al cargar los datos. 😥')
          }
        })
      return
    }

    // guardar
    this._productService.addProduct(this.product).subscribe({
      next: ({ message }) => {
        this.router.navigate(['/product'])
        this.showSnackBar(message)
      },
      error: () => {
        this.router.navigate(['/product'])
        this.showSnackBar('Ocurrió un error al cargar los datos. 😥')
      }
    })
  }

  showSnackBar (msj: string) {
    this.snackBar.open(msj, 'Ok!', {
      duration: 2500
    })
  }
}
