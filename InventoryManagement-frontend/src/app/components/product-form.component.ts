import { Component, EventEmitter, Input, Output, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Product } from '../../models/product.model';

@Component({
  selector: 'app-product-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './product-form.component.html'
})
export class ProductFormComponent {
  http = inject(HttpClient);
  fb = inject(FormBuilder);

  @Input() product?: Product; 
  @Output() saved = new EventEmitter<void>();

  form = this.fb.group({
    name: ['', Validators.required],
    price: [0, Validators.required],
    description: [''],
    category: ['']
  });

  ngOnChanges() {
    if (this.product) {
      this.form.patchValue(this.product);
    } else {
      this.form.reset();
    }
  }

  save() {
    if(this.form.invalid) return;

    const productData = this.form.value;

    if(this.product?.id){
      // Update
      this.http.put(`https://localhost:44324/api/Products/${this.product.id}`, productData)
        .subscribe(() => this.saved.emit());
    } else {
      // Create
      this.http.post('https://localhost:44324/api/Products', productData)
        .subscribe(() => this.saved.emit());
    }
  }
}
