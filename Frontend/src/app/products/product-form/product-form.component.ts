import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInput, MatInputModule } from '@angular/material/input';
import { BrandService } from '../../services/brand.service';
import Brand from '../../types/brand';
import { MatSelectModule } from '@angular/material/select';
import Product from '../../types/product';
import { ProductService } from '../../services/product.service';
import { Router } from 'express';

@Component({
  selector: 'app-product-form',
  standalone: true,
  imports: [ReactiveFormsModule,MatInputModule,MatFormFieldModule,MatInput,MatSelectModule],
  templateUrl: './product-form.component.html',
  styleUrl: './product-form.component.css'
})
export class ProductFormComponent {
builder = inject(FormBuilder);
productForm: FormGroup = this.builder.group({
  
  name: ['',Validators.required], 
  brandname: ['',Validators.required], 
  purchasePrice: ['',Validators.required], 
  salePrice: ['',Validators.required], 
  availableQuantity: ['',Validators.required], 
}); 
brandService = inject(BrandService);
productService= inject(ProductService);
brands: Brand[] = [];
router = inject(Router);
ngOnInit(): void {
  this.brandService.getBrands().subscribe(result => (this.brands = result))
}
addProduct(){
  console.log(this.productForm.value);
  if(this.productForm.invalid) {
    alert("Please provide all the details");
    return; 
  }
  let product: Product = this.productForm.value; 
  this.productService.addProduct(product).subscribe(result => {
    alert("your products are added !!");
    this.router.navigateByUrl("/products");
  })
};
}
