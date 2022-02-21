import { Component, OnInit } from '@angular/core';
import { Client } from '../models/client';
import { ClientsService } from '../clients.service';

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.css'],
})
export class ClientListComponent implements OnInit {
  clients: Client[] = [];

  constructor(private clientsService: ClientsService) {}

  ngOnInit(): void {
    this.retrieveClients();
  }

  retrieveClients(): void {
    this.clientsService.getAll().subscribe({
      next: (response) => {
        this.clients = response.data;
      },
      error: (e) => console.error(e),
    });
  }

  deleteClient(id: number): void {
    if (window.confirm('Are you sure you want to delete this client?')) {
      this.clientsService.delete(id).subscribe({
        next: () => {
          this.retrieveClients();
        },
        error: (e) => console.error(e),
      });
    }
  }
}
