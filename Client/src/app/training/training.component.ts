import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { TrainingService } from '../services/training.service';
import { Training } from '../models/training';
import { Title } from '@angular/platform-browser';

@Component({
  moduleId: module.id,
    templateUrl: './training.component.html'
})
export class TrainingComponent implements OnInit {
  public title = 'Training';
  public model = new Training();
  public error: String;
  public training: Training[];

  constructor(
   private titleService: Title,
   private trainingService: TrainingService,
   private location: Location
  ) { }

  ngOnInit() {
    
  }

  list(){
    this.trainingService.getTraining()
      .then(t => this.training = t);
  }

  register() {
     this.trainingService.postTraining(this.model)
      .then(() => this.reloadPage())
      .catch((e) =>  this.error = e.message)
  }

  goBack(): void {
   this.location.back();
  }

  reloadPage() {
   window.location.reload();
  }
}