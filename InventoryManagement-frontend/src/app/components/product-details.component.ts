import { Component, inject, OnInit } from '@angular/core';
import { AsyncPipe, NgIf } from '@angular/common';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ProductService } from '../services/product.service';
import { Product } from '../../models/product.model';
import { switchMap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-product-details',
  standalone: true,
  imports: [AsyncPipe, NgIf, RouterLink, CurrencyPipe],
  template: `
    <div class="container mx-auto p-4" *ngIf="product$ | async as product; else loading">
      <div class="bg-white rounded-lg shadow-lg overflow-hidden">
        <div class="bg-gray-100 px-6 py-4 border-b">
          <div class="flex justify-between items-center">
            <h1 class="text-2xl font-bold">{{ product.name }}</h1>
            <div class="flex space-x-2">
              <button 
                class="bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded"
                [routerLink]="['/product/edit', product.id]">
                Edit
              </button>
              <button 
                class="bg-red-500 hover:bg-red-600 text-white px-4 py-2 rounded"
                (click)="deleteProduct(product.id)">
                Delete
              </button>
              <button 
                class="bg-gray-500 hover:bg-gray-600 text-white px-4 py-2 rounded"
                [routerLink]="['/products']">
                Back to List
              </button>
            </div>
          </div>
        </div>
        
        <div class="p-6">
          <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
            <div>
              <div class="mb-4">
                <h3 class="text-lg font-semibold text-gray-700">Price</h3>
                <p class="text-2xl text-blue-600">{{ product.price | currency }}</p>
              </div>
              
              <div class="mb-4">
                <h3 class="text-lg font-semibold text-gray-700">Category</h3>
                <p>{{ product.category || 'Uncategorized' }}</p>
              </div>
              
              <div class="mb-4">
                <h3 class="text-lg font-semibold text-gray-700">Quantity in Stock</h3>
                <p>{{ product.quantityInStock }}</p>
              </div>
            </div>
            
            <div>
              <div class="mb-4">
                <h3 class="text-lg font-semibold text-gray-700">Description</h3>
                <p class="text-gray-600">{{ product.description || 'No description available' }}</p>
              </div>
              
              <div *ngIf="product.imageBase64" class="mb-4">
                <h3 class="text-lg font-semibold text-gray-700">Product Image</h3>
                <img [src]="'data:image/jpeg;base64,' + product.imageBase64" alt="{{ product.name }}" class="mt-2 max-w-full h-auto rounded">
              </div>
              <div *ngIf="!product.imageBase64" class="mb-4">
                <div class="bg-gray-200 p-16 rounded flex items-center justify-center">
                  <p class="text-gray-500">No image available</p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    
    <ng-template #loading>
      <div class="container mx-auto p-4 text-center">
        <p>Loading product details...</p>
      </div>
    </ng-template>
  `
})
export class ProductDetailsComponent implements OnInit {
  private route = inject(ActivatedRoute);
  productService = inject(ProductService);
  product$!: Observable<Product>;
  
  ngOnInit(): void {
    this.product$ = this.route.paramMap.pipe(
      switchMap(params => {
        const id = Number(params.get('id'));
        return this.productService.getProduct(id);
      })
    );
  }
  
  deleteProduct(id: number): void {
    if (confirm('Are you sure you want to delete this product?')) {
      this.productService.deleteProduct(id).subscribe({
        next: () => {
          // Navigate back to the products list
          window.location.href = '/products';
        },
        error: (error) => {
          console.error('Error deleting product:', error);
          alert('Failed to delete product. Please try again.');
        }
      });
    }
  }
}