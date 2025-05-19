import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ProductFormComponent } from './components/product-form.component';
import { Product } from '../models/product.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, ProductFormComponent],
  templateUrl: './app.component.html',
})
export class AppComponent {
  http = inject(HttpClient);

  products$: Observable<Product[]> = this.http.get<Product[]>('https://localhost:44324/api/Products');

  selectedProduct?: Product;
  showForm = false;

  onEdit(product: Product) {
    this.selectedProduct = product;
    this.showForm = true;
  }

  onAdd() {
    this.selectedProduct = undefined;
    this.showForm = true;
  }

  onFormSaved() {
    this.showForm = false;
    this.refreshProducts();
  }

  refreshProducts() {
    this.products$ = this.http.get<Product[]>('https://localhost:44324/api/Products');
  }
  onDelete(productId: number) {
  if (confirm('Are you sure you want to delete this product?')) {
    this.http.delete(`https://localhost:44324/api/Products/${productId}`).subscribe(() => {
      this.refreshProducts(); 
    });
  }
}
}
