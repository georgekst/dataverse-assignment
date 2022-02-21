import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientListComponent } from './client-list/client-list.component';
import { CreateClientComponent } from './create-client/create-client.component';
import { EditClientComponent } from './edit-client/edit-client.component';
import { NotFoundComponent } from './not-found/not-found.component';

const routes: Routes = [
  { path: 'clients', component: ClientListComponent },
  { path: 'clients/create', component: CreateClientComponent },
  { path: 'clients/:id/edit', component: EditClientComponent },
  { path: '', redirectTo: '/clients', pathMatch: 'full' },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
