import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { User } from '../../models/admin/user';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

@Injectable()
export class UserService {

   private currentUser;

   constructor(private http: Http) {
       this.currentUser = JSON.parse(localStorage.getItem('x-access-token'));
  }

  postUser(user: User): Promise<User[]> {
   var headers = new Headers();
     headers.append('x-access-token', this.currentUser.token);

   return this.http.post('user/', user, { headers: headers })
     .toPromise()
     .then(res => res.json())
     .catch(this.error);
  }

  private error(error: any): Promise<any> {
   return Promise.reject(error.json());
  }
}
