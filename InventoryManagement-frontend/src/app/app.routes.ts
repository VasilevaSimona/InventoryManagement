import { Routes } from '@angular/router';
import { ProductDetailsComponent } from './components/product-details.component';
import { ProductFormComponent } from './components/product-form.component';

export const routes: Routes = [
  { path: '', redirectTo: '/products', pathMatch: 'full' },

  { path: 'product/new', component: ProductFormComponent },
  { path: 'product/edit/:id', component: ProductFormComponent },
  { path: 'product/:id', component: ProductDetailsComponent },
  { path: '**', redirectTo: '/products' } 
];