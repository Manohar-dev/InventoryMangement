import { Component } from '@angular/core';
import { MatCardModule} from '@angular/material/card';
import { inject } from '@angular/core';
import { BrandService } from '../../services/brand.service';
@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatCardModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  totalOrders: number = 100;
  totalProducts: number = 100;
  totalBrands?: number; 
  brandservice = inject(BrandService);
  ngOnInit(): void {
         this.brandservice.getBrands().subscribe(result => this.totalBrands = result.length,);
  }
}
