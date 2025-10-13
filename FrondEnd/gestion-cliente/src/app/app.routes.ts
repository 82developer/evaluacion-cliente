import { Routes } from '@angular/router';
import { provideRouter } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: 'clients', pathMatch: 'full' },
  {
    path: 'clients',
    loadComponent: () =>
      import('./features/clients/bandeja/bandeja').then(m => m.Bandeja)
  },
  {
    path: 'clients/new',
    loadComponent: () =>
      import('./features/clients/edit/edit').then(m => m.Edit)
  },
  {
    path: 'clients/:id/edit',
    loadComponent: () =>
      import('./features/clients/edit/edit').then(m => m.Edit)
  },
  { path: '**', redirectTo: 'clients' }
];
