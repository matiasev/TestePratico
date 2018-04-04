import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { TrainingComponent } from './training/training.component';
import { RegisterCoachComponent } from './admin/register-coach/register-coach.component';
import { RegisterPlayerComponent } from './admin/register-player/register-player.component';

const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'training', component: TrainingComponent },
  { path: 'registercoach', component: RegisterCoachComponent },
  { path: 'registerplayer', component: RegisterPlayerComponent },
  { path: '**', redirectTo: '' }
]

export const Routing = RouterModule.forRoot(appRoutes);