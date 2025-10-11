import { Component } from '@angular/core';

@Component({
  selector: 'app-grilla',
  imports: [],
  templateUrl: './grilla.html',
  styleUrl: './grilla.css'
})
export class Grilla {
  onNuevo(): void {
    console.log('Nuevo clicked');
  }

  onEdit(id: string): void {
    // TODO: navigate to edit form or open modal
    console.log('Edit client', id);
  }

  onDelete(id: string): void {
    // TODO: call service + refresh; simple confirmation example:
    const ok = confirm(`Delete client ${id}? This action cannot be undone.`);
    if (ok) {
      console.log('Deleting client', id);
      // this.clientService.delete(id).subscribe(() => this.reload());
    }
  }
}
