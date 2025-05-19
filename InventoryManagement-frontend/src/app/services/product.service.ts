import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Product } from '../../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private http = inject(HttpClient);
  private apiUrl = 'https://localhost:44324/api/Products';
  
  
  private productsSubject = new BehaviorSubject<Product[]>([]);
  products$ = this.productsSubject.asObservable();
  
  loadProducts(): void {
    this.http.get<Product[]>(this.apiUrl)
      .subscribe({
        next: (products) => {
          this.productsSubject.next(products);
        },
        error: (error) => {
          console.error('Error loading products:', error);
          this.productsSubject.next([]);
        }
      });
  }
  
  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.apiUrl}/${id}`);
  }
  
  createProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(this.apiUrl, product)
      .pipe(
        tap(() => this.loadProducts())
      );
  }
  
  updateProduct(product: Product): Observable<Product> {
    return this.http.put<Product>(`${this.apiUrl}/${product.id}`, product)
      .pipe(
        tap(() => this.loadProducts())
      );
  }
  
  deleteProduct(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`)
      .pipe(
        tap(() => this.loadProducts())
      );
  }
}