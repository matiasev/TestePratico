import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { Routing } from './app.routing';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { TrainingComponent } from './training/training.component';
import { RegisterCoachComponent } from './admin/register-coach/register-coach.component';
import { RegisterPlayerComponent } from './admin/register-player/register-player.component';
import { UserService } from './services/admin/user.service';
import { TrainingService } from './services/training.service';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    TrainingComponent,
    RegisterCoachComponent,
    RegisterPlayerComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    Routing
  ],
  providers: [
    UserService,
    TrainingService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
