import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Training } from '../models/training';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

@Injectable()
export class TrainingService {

   constructor(private http: Http) {
  }

  getTraining(): Promise<Training[]> {
    var headers = new Headers();
    return this.http.get('training', { headers: headers })
      .toPromise()
      .then(res => res.json())
      .catch(this.error);
  }

  postTraining(training: Training): Promise<Training[]> {
   var headers = new Headers();
   return this.http.post('training/', training, { headers: headers })
     .toPromise()
     .then(res => res.json())
     .catch(this.error);
  }

  deleteTraining(id: String): Promise<any>{
    var headers = new Headers();
    return this.http.delete('training/' + id, { headers: headers })
      .toPromise()
      .then(() => null)
      .catch(this.error);
  }

  private error(error: any): Promise<any> {
   return Promise.reject(error.json());
  }
}
