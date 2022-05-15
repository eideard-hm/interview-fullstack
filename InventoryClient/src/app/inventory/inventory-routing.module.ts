import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        loadChildren: () => import('./invoice-detail/invoice-detail.module').then(m => m.InvoiceDetailModule)
      },
      {
        path: 'invoice',
        loadChildren: () =>
          import('./invoice/invoice.module').then(m => m.InvoiceModule)
      },
      {
        path: 'product',
        loadChildren: () => import('./product/product.module').then(m => m.ProductModule)
      },
      {
        path: 'user',
        loadChildren: () => import('./user/user.module').then(m => m.UserModule)
      }
    ]
  },
  {
    path: '**',
    redirectTo: '/',
    pathMatch: 'full'
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InventoryRoutingModule {}
