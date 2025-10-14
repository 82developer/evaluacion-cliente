import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators, FormGroup } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-clients-search',
standalone: true,
  imports: [
    CommonModule, ReactiveFormsModule,
    MatFormFieldModule, MatInputModule, MatButtonModule, MatCardModule
  ],
  templateUrl:'./search.html',
  styleUrl:'./search.scss'
})
export class Search{
  @Output() search = new EventEmitter<any>();
  form!: FormGroup;
  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      ruc: ['', [Validators.pattern(/^\d*$/)]],  // only digits if present
      razonSocial: ['']
    });
  }

  onSubmit() {
    const { ruc, razonSocial } = this.form.value;
    this.search.emit({
      ruc: (ruc || '').trim() || undefined,
      razonSocial: (razonSocial || '').trim() || undefined
    });
  }
  onClear() {
    this.form.reset({ ruc: '', razonSocial: '' });
    this.search.emit({});
  }
}
