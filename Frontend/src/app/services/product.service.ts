import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import Product from '../types/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor() { }
  httpClient = inject(HttpClient);

  getBrands(){
    return this.httpClient.get<Product[]>("http://localhost:3000/brands");
  };

  addProduct(product: Product){
    return this.httpClient.post<Product>("http://localhost:3000/brands", product)
  };
}
