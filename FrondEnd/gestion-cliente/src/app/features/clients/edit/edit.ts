import { Component, inject, signal, computed } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { ClientsService } from '../../../core/services/clients.service';
import { Client } from '../../../core/models/client';

@Component({
  selector: 'app-edit-client',
  standalone: true,
  imports: [
    CommonModule, ReactiveFormsModule, RouterModule,
    MatCardModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatSnackBarModule
  ],
  template: `
  <mat-card>
    <h2>{{ isEdit() ? 'Edit client' : 'New client' }}</h2>

    <form [formGroup]="form" class="grid">
      <mat-form-field appearance="outline">
        <mat-label>RUC</mat-label>
        <input matInput formControlName="ruc" maxlength="11">
        <mat-error *ngIf="form.controls.ruc.hasError('required')">Required</mat-error>
        <mat-error *ngIf="form.controls.ruc.hasError('pattern')">RUC must be 11 digits</mat-error>
      </mat-form-field>

      <mat-form-field appearance="outline">
        <mat-label>Razón Social</mat-label>
        <input matInput formControlName="razonSocial">
        <mat-error *ngIf="form.controls.razonSocial.hasError('required')">Required</mat-error>
      </mat-form-field>

      <mat-form-field appearance="outline">
        <mat-label>Teléfono de contacto</mat-label>
        <input matInput formControlName="telefonoContacto">
        <mat-error *ngIf="form.controls.telefonoContacto.hasError('required')">Required</mat-error>
        <mat-error *ngIf="form.controls.telefonoContacto.hasError('pattern')">Invalid phone</mat-error>
      </mat-form-field>

      <mat-form-field appearance="outline">
        <mat-label>Correo de contacto</mat-label>
        <input matInput formControlName="correoContacto">
        <mat-error *ngIf="form.controls.correoContacto.hasError('required')">Required</mat-error>
        <mat-error *ngIf="form.controls.correoContacto.hasError('email')">Invalid email</mat-error>
      </mat-form-field>

      <mat-form-field appearance="outline" class="col-2">
        <mat-label>Dirección</mat-label>
        <input matInput formControlName="direccion">
        <mat-error *ngIf="form.controls.direccion.hasError('required')">Required</mat-error>
      </mat-form-field>
    </form>

    <div class="actions">
      <button mat-raised-button color="primary" (click)="save()" [disabled]="form.invalid">
        {{ isEdit() ? 'Update' : 'Create' }}
      </button>
      <button mat-button (click)="cancel()">Cancel</button>
    </div>
  </mat-card>
  `,
  styles: [`
    .grid {
      display: grid;
      grid-template-columns: repeat(2, minmax(0, 1fr));
      gap: 1rem;
    }
    .col-2 { grid-column: span 2 / span 2; }
    .actions { margin-top: 1rem; display: flex; gap: .5rem; }
  `]
})
export class Edit {
  private fb = inject(FormBuilder);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private api = inject(ClientsService);
  private snack = inject(MatSnackBar);

  idParam: number | null = null;

  form = this.fb.group({
    ruc: ['', [Validators.required, Validators.pattern(/^\d{11}$/)]],
    razonSocial: ['', Validators.required],
    telefonoContacto: ['', [Validators.required, Validators.pattern(/^[\d +()-]{6,15}$/)]],
    correoContacto: ['', [Validators.required, Validators.email]],
    direccion: ['', null],
  });

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.idParam = id ? +id : null;

    if (this.idParam) {
      this.api.getById(this.idParam).subscribe({
        next: (c) => this.form.patchValue(c),
        error: () => this.snack.open('Error loading client','Close',{ duration: 3000 })
      });
    }
  }

  isEdit() { return !!this.idParam; }

  save() {
    const payload = this.form.value as Client;
    if (this.isEdit() && this.idParam) {
      this.api.update(this.idParam, payload).subscribe({
        next: () => {
          this.snack.open('Client updated','Close',{ duration: 2500 });
          this.router.navigateByUrl('/clients');
        },
        error: () => this.snack.open('Update failed','Close',{ duration: 3000 })
      });
    } else {
      this.api.create(payload).subscribe({
        next: () => {
          this.snack.open('Client created','Close',{ duration: 2500 });
          this.router.navigateByUrl('/clients');
        },
        error: () => this.snack.open('Create failed','Close',{ duration: 3000 })
      });
    }
  }

  cancel() {
    this.router.navigateByUrl('/clients');
  }
}
