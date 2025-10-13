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
  templateUrl:'./edit.html',
  styleUrl:'./edit.scss'
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
