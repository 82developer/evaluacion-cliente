import { Component, EventEmitter, Output} from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormControl } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-clients-search',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatIconModule],
  template: `
  <mat-form-field appearance="outline" class="w-full">
    <mat-label>Search clients</mat-label>
    <input matInput [formControl]="term" placeholder="RUC, Company, Email, etc.">
    <button *ngIf="term.value" matSuffix mat-icon-button aria-label="Clear" (click)="clear()">
      <mat-icon>close</mat-icon>
    </button>
  </mat-form-field>
  `,
  styles: [`.w-full { width: 100%; margin-bottom: 1rem; }`]
})
export class Search{
  @Output() search = new EventEmitter<string>();
  term = new FormControl<string>('', { nonNullable: true });

  constructor() {
    this.term.valueChanges
      .pipe(debounceTime(300), distinctUntilChanged())
      .subscribe(v => this.search.emit(v));
  }

  clear() {
    this.term.setValue('');
    this.search.emit('');
  }
}
