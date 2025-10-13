import { Component, ViewChild, inject, signal, computed, effect } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { ClientsService } from '../../../core/services/clients.service';
import { Client } from '../../../core/models/client';
import { Search} from '../search/search';

@Component({
  selector: 'app-bandeja',
  standalone: true,
  imports: [
    CommonModule, RouterModule,
    MatTableModule, MatPaginatorModule, MatSortModule,
    MatButtonModule, MatIconModule, MatCardModule, MatSnackBarModule,
    Search
  ],
  template: `
  <mat-card>
    <div class="toolbar">
      <h2>Clients</h2>
      <button mat-raised-button color="primary" (click)="newClient()">
        <mat-icon>add</mat-icon> New Client
      </button>
    </div>

    <!-- Search bar above the table -->
    <app-clients-search (search)="onSearch($event)"></app-clients-search>

    <div class="table-wrapper">
      <table mat-table [dataSource]="dataSource" matSort class="mat-elevation-z2">
        <ng-container matColumnDef="ruc">
          <th mat-header-cell *matHeaderCellDef mat-sort-header>RUC</th>
          <td mat-cell *matCellDef="let row">{{ row.ruc }}</td>
        </ng-container>

        <ng-container matColumnDef="razonSocial">
          <th mat-header-cell *matHeaderCellDef mat-sort-header>Razón Social</th>
          <td mat-cell *matCellDef="let row">{{ row.razonSocial }}</td>
        </ng-container>

        <ng-container matColumnDef="telefonoContacto">
          <th mat-header-cell *matHeaderCellDef mat-sort-header>Teléfono</th>
          <td mat-cell *matCellDef="let row">{{ row.telefonoContacto }}</td>
        </ng-container>

        <ng-container matColumnDef="correoContacto">
          <th mat-header-cell *matHeaderCellDef mat-sort-header>Correo</th>
          <td mat-cell *matCellDef="let row">{{ row.correoContacto }}</td>
        </ng-container>

        <ng-container matColumnDef="direccion">
          <th mat-header-cell *matHeaderCellDef>Dirección</th>
          <td mat-cell *matCellDef="let row">{{ row.direccion }}</td>
        </ng-container>

        <ng-container matColumnDef="actions">
          <th mat-header-cell *matHeaderCellDef>Actions</th>
          <td mat-cell *matCellDef="let row">
            <button mat-icon-button color="primary" (click)="edit(row)">
              <mat-icon>edit</mat-icon>
            </button>
            <button mat-icon-button color="warn" (click)="remove(row)">
              <mat-icon>delete</mat-icon>
            </button>
          </td>
        </ng-container>

        <tr mat-header-row *matHeaderRowDef="displayed"></tr>
        <tr mat-row *matRowDef="let row; columns: displayed;"></tr>
      </table>

      <mat-paginator [pageSize]="10" [pageSizeOptions]="[5,10,20]"></mat-paginator>
    </div>
  </mat-card>
  `,
  styles: [`
    .toolbar {
      display: flex; align-items: center; justify-content: space-between;
      margin-bottom: .5rem;
    }
    .table-wrapper { overflow: auto; }
    table { width: 100%; }
  `]
})
export class Bandeja{
  private router = inject(Router);
  private api    = inject(ClientsService);
  private snack  = inject(MatSnackBar);

  displayed = ['ruc','razonSocial','telefonoContacto','correoContacto','direccion','actions'];
  dataSource = new MatTableDataSource<Client>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    this.load();
  }

  load(query?: string) {
    this.api.getAll(query).subscribe({
      next: list => {
        this.dataSource.data = list.items
      },
      error: () => this.snack.open('Error loading clients','Close',{ duration: 3000 })
    });
  }

  onSearch(q: string) {
    this.load(q);
  }

  newClient() {
    this.router.navigateByUrl('/clients/new');
  }

  edit(row: Client) {
    this.router.navigate(['/clients', row.id, 'edit']);
  }

  remove(row: Client) {
    if (!row.id) return;
    if (confirm(`Delete ${row.razonSocial}?`)) {
      this.api.delete(row.id).subscribe({
        next: () => {
          this.snack.open('Client deleted','Close',{ duration: 2500 });
          this.load();
        },
        error: () => this.snack.open('Delete failed','Close',{ duration: 3000 })
      });
    }
  }
}
