import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { UserService } from '../../services/admin/user.service';
import { User } from '../../models/admin/user';
import { Title } from '@angular/platform-browser';

@Component({
  moduleId: module.id,
  templateUrl: './register-coach.component.html'
})
export class RegisterCoachComponent implements OnInit {
  public title = 'Register Coach';
  public model = new User();
  public error: String;

  constructor(
   private userService: UserService,
   private location: Location
  ) { }

  ngOnInit() {
  }

  register() {
     this.userService.postUser(this.model)
     .then(() => alert('Coach cadastrado com sucesso!'))
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
