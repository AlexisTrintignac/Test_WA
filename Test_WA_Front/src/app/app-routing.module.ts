import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonneComponent } from './components/personne/personne.component';
import { EmploiComponent } from './components/emploi/emploi.component';

const routes: Routes = [
  { path: 'personne', component: PersonneComponent },
  { path: 'emploi', component: EmploiComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
