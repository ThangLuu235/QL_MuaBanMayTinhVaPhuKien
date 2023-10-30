import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/model/product.model';
import { ProductsService } from '../../services/products.service';
@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  products: Product[] = [];

  constructor(private productService: ProductsService, private router: Router) { }

  ngOnInit(): void {
    this.productService.GetProducts()
      .subscribe(
        {
          next: (products) => { this.products = products; }, error: (response) => { console.log(response) }
        }
      );
  }
}
