import { Component, ViewChild, inject } from '@angular/core';
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
  styleUrl:'bandeja.scss',
  templateUrl:'./bandeja.html',
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

  load(query?: any) {
    this.api.getAll(query).subscribe({
      next: list => {
        this.dataSource.data = list.items
      },
      error: () => this.snack.open('Error loading clients','Close',{ duration: 3000 })
    });
  }

  onSearch(filter: any) {
    this.load(filter);
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
