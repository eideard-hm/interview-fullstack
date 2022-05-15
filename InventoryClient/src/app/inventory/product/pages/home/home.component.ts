import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core'
import { Router } from '@angular/router';
import { Observable, of, switchMap } from 'rxjs';
import { MatPaginator } from '@angular/material/paginator'
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table'
import { Product } from '../../interfaces/product.interfaces'
import { ProductService } from '../../services/product.service';
import { ConfirmComponent } from '../../components/confirm/confirm.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: [
    `
      table {
        width: 100%;
      }
    `
  ]
})
export class HomeComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = []
  dataSource = new MatTableDataSource<Product>()
  @ViewChild(MatPaginator) paginator!: MatPaginator

  public product$!: Observable<Product[]>;

  constructor (private readonly _productService: ProductService,
              private readonly router: Router,
              private readonly snackBar: MatSnackBar,
              private readonly dialog: MatDialog) {}

  ngOnInit (): void {
    this.loadData(true);
  }

  ngAfterViewInit (): void {
    this.dataSource.paginator = this.paginator
  }

  deleteProduct (product: Product) {
    const dialog = this.dialog.open(ConfirmComponent, {
      width: '400px',
      data: { ...product }
    })

    dialog
        .afterClosed()
        .pipe(
          switchMap(res =>
            res
              ? this._productService.deleteProduct(product.productId)
              : of(false)
          )
        )
        .subscribe(() => this.loadData(true))
  }

  loadData (refreshTable: boolean = false) {
    if (refreshTable) {
      this.product$ = this._productService.getProducts()
      this.product$.subscribe({
        next: invoice => {
          this.displayedColumns = Object.keys(invoice[0]).slice(0, 6)
          this.displayedColumns.push('actions')
          this.dataSource.data = invoice
        },
        error: () => {
          this.router.navigate(['/'])
          this.showSnackBar('Error al recuperar los datos.')
        }
      })
    }
  }

  showSnackBar (msj: string) {
    this.snackBar.open(msj, 'Ok!', {
      duration: 2500
    })
  }
}
