import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs'
import { Product } from '../interfaces/product.interfaces'
import { environment } from 'src/environments/environment'

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private readonly apiUrl: string = environment.apiUrl
  constructor (private readonly _http: HttpClient) {}

  getProducts (): Observable<Product[]> {
    return this._http.get<Product[]>(`${this.apiUrl}/Product`)
  }
}
