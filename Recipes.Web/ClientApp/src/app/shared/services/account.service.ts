import { Inject, Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { User } from '../models/User';

@Injectable()
export class AccountService {
  constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
  }

  register(user: User): Observable<User> {
    return this.http.post(this.baseUrl + 'api/Account/Register', user)
      .map((resp: Response) => {
        // TODO: Handle response
      })
      .catch(this.handleError);
  }

  login(user: User): Observable<any> {
    return this.http.post(this.baseUrl + 'api/Account/Login', user)
      .map((resp: Response) => {
        // TODO: Handle response
      })
      .catch(this.handleError);
  }

  logout(): Observable<any> {
    return this.http.get(this.baseUrl + 'api/Account/Logout')
      .map((resp: Response) => {
        // TODO: Handle response
      })
      .catch(this.handleError);
  }

  private handleError(error: any) {
    console.error('server error:', error);

    if (error instanceof Response) {
      let errMessage = '';

      try {
        errMessage = error.json().error;
      }
      catch (err) {
        errMessage = error.statusText;
      }

      return Observable.throw(errMessage);
    }

    return Observable.throw(error || 'Server error');
  }
}
