import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Product } from '../../interfaces/product.interfaces';

@Component({
  selector: 'app-confirm',
  templateUrl: './confirm.component.html',
  styleUrls: []
})
export class ConfirmComponent implements OnInit {

  constructor (
    private readonly dialogRef: MatDialogRef<ConfirmComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Product
  ) {}

  ngOnInit (): void {}

  borrar () {
    this.dialogRef.close(true)
  }

  cerrar () {
    this.dialogRef.close()
  }

}
