import { Component, AfterViewInit, ViewChild, OnInit } from '@angular/core'
import { MatPaginator } from '@angular/material/paginator'
import { MatTableDataSource } from '@angular/material/table'
import { InvoiceService } from '../../services/invoice.service'
import { Observable, of, switchMap } from 'rxjs'
import { Invoice } from '../../interfaces/invoice.interfaces'
import { MatSnackBar } from '@angular/material/snack-bar'
import { Router } from '@angular/router'
import { MatDialog } from '@angular/material/dialog'
import { ConfirmComponent } from '../../components/confirm/confirm.component';
import { Title } from '@angular/platform-browser'
import { ModalComponent } from '../../components/modal/modal.component';

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
export class HomeComponent implements AfterViewInit, OnInit {
  displayedColumns: string[] = []
  dataSource = new MatTableDataSource<Invoice>()
  @ViewChild(MatPaginator) paginator!: MatPaginator

  public invoices$!: Observable<Invoice[]>

  constructor (
    private readonly _invoiceService: InvoiceService,
    private readonly snackBar: MatSnackBar,
    private readonly router: Router,
    private readonly dialog: MatDialog,
    private readonly title: Title
  ) {}

  ngOnInit (): void {
    this.title.setTitle('Facturas | Inventory');
    this.loadData(true)
  }

  ngAfterViewInit (): void {
    this.dataSource.paginator = this.paginator
  }

  anularInvoice (invoice: Invoice) {
    if (!invoice.anulado) {
      const dialog = this.dialog.open(ConfirmComponent, {
        width: '400px',
        data: { ...invoice }
      })

      dialog
        .afterClosed()
        .pipe(
          switchMap(res =>
            res
              ? this._invoiceService.deleteInvoice(invoice.invoiceId)
              : of(false)
          )
        )
        .subscribe(() => this.loadData(true))
    }
  }

  loadData (refreshTable: boolean = false) {
    if (refreshTable) {
      this.invoices$ = this._invoiceService.getInvoices()
      this.invoices$.subscribe({
        next: invoice => {
          this.displayedColumns = Object.keys(invoice[0]).slice(0, 8)
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

  seeDetail(invoice: Invoice){
    const dialogRef = this.dialog.open(ModalComponent, {
      width: '800px',
       data: {...invoice},
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  showSnackBar (msj: string) {
    this.snackBar.open(msj, 'Ok!', {
      duration: 2500
    })
  }
}
