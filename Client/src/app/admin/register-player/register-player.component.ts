import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { UserService } from '../../services/admin/user.service';
import { User } from '../../models/admin/user';
import { Title } from '@angular/platform-browser';

@Component({
  moduleId: module.id,
  templateUrl: './register-player.component.html'
})
export class RegisterPlayerComponent {
  public title = 'Register Player';
  public model = new User();
  public error: String;

  constructor(
   private userService: UserService,
   private location: Location
  ) { }

  register() {
     this.userService.postUser(this.model)
     .then(() => alert('Player cadastrado com sucesso!'))
     .then(() => this.reloadPage())
     .catch((e) =>  this.error = e.message);
  }

  goBack(): void {
   this.location.back();
  }

  reloadPage() {
   window.location.reload();
  }
}