import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs'
import { Product } from '../interfaces/product.interfaces'
import { environment } from 'src/environments/environment'
import { Response } from '../../interfaces/inventory.interfaces';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private readonly apiUrl: string = environment.apiUrl
  constructor (private readonly _http: HttpClient) {}

  getProducts (): Observable<Product[]> {
    return this._http.get<Product[]>(`${this.apiUrl}/Product`)
  }

  getProductById(id?: number): Observable<Product>{
    return this._http.get<Product>(`${this.apiUrl}/Product/${id}`);
  }

  addProduct(product: Product): Observable<Response>{
    return this._http.post<Response>(`${this.apiUrl}/Product`, product);
  }

  updateProduct(id:number, product: Product): Observable<Response>{
    return this._http.put<Response>(`${this.apiUrl}/Product/${id}`, product);
  }

  deleteProduct(id?: number): Observable<Response>{
    return this._http.delete<Response>(`${this.apiUrl}/Product/${id}`)
  }
}
