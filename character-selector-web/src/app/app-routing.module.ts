import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {CharacterDetailComponent} from './Components/character-detail/character-detail.component';
import {CharacterDashboardComponent} from './Components/character-dashboard/character-dashboard.component';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: CharacterDashboardComponent },
  { path: 'character/:id', component: CharacterDetailComponent },
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
