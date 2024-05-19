import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatInput, MatInputModule } from '@angular/material/input';
import { BrandService } from '../../../services/brand.service';
import { Router } from 'express';
import Brand from '../../../types/brand';

@Component({
  selector: 'app-brand-form',
  standalone: true,
  imports: [MatFormField,MatInput,MatInputModule,MatLabel,FormsModule,MatButtonModule],
  templateUrl: './brand-form.component.html',
  styleUrl: './brand-form.component.css'
})
export class BrandFormComponent {
  name!: string; 
  brandservice = inject(BrandService);
  router = inject(Router);
   generateRandomId(length: number): string {
    let result = '';
    const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    const charactersLength = characters.length;
    for (let i = 0; i < length; i++) {
      result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    return result;
  }
  

  addBrand(){
    console.log(this.name)
    if(!this.name){
      alert("Brand name Needed!!");
      return;
    }
  // const randomId: string = this.generateRandomId(4);

  //   let brand: Brand = {
  //     id: randomId,
  //     name :this.name
  //   }
   
  //   this.brandservice.addBrand(brand).subscribe(result => {
  //     alert("Brand Added!!")
  //     this.router.navigateByUrl('/brands')
  //   });
  };
}
