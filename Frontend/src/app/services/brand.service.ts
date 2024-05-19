import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import Brand from '../types/brand'


@Injectable({
  providedIn: 'root'
})
export class BrandService {

    httpClient = inject(HttpClient);
      
    constructor() { this.getBrands()
    } 
    getBrands(){
      
      return this.httpClient.get<Brand[]>("http://localhost:3000/brands");
      
    };

    addBrand(brand: Brand){
      return this.httpClient.post<Brand>("http://localhost:3000/brands", brand)
    };
}
