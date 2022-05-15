import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { environment } from 'src/environments/environment'
import { Observable } from 'rxjs'
import { Invoice } from '../interfaces/invoice.interfaces'
import { Response } from '../../interfaces/inventory.interfaces'

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {
  private readonly apiUrl: string = environment.apiUrl

  constructor (private readonly _http: HttpClient) {}

  getInvoices (): Observable<Invoice[]> {
    return this._http.get<Invoice[]>(`${this.apiUrl}/Invoice`)
  }

  getInvoiceById (id: number): Observable<Invoice> {
    return this._http.get<Invoice>(`${this.apiUrl}/Invoice/${id}`)
  }

  addInvoice (invoice: Invoice): Observable<Response> {
    return this._http.post<Response>(`${this.apiUrl}/Invoice`, invoice)
  }

  deleteInvoice (id?: number) {
    return this._http.delete(`${this.apiUrl}/Invoice/${id}`)
  }
}
