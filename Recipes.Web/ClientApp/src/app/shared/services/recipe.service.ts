import { Inject, Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { Recipe } from '../models/Recipe';

@Injectable()
export class RecipeService {
  constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
  }

  getRecipes(): Observable<Recipe[]> {
    return this.http.get(this.baseUrl + 'api/RecipesList/Get')
      .map((resp: Response) => {
        return resp.json();
      })
      .catch(this.handleError);
  }

  getFavouriteRecipes(): Observable<Recipe[]> {
    return this.http.get(this.baseUrl + 'api/RecipesList/Favourites')
      .map((resp: Response) => {
        return resp.json();
      })
      .catch(this.handleError);
  }

  getRecipe(id: any): Observable<Recipe> {
    return this.http.get(this.baseUrl + 'api/Recipe/GetById', id)
      .map((resp: Response) => {
        return resp.json();
      })
      .catch(this.handleError);
  }

  addRecipe(recipe: Recipe): Observable<Recipe> {
    return this.http.post(this.baseUrl + 'api/Recipe/Add', recipe)
      .map((resp: Response) => {
        return resp.json();
      })
      .catch(this.handleError);
  }

  saveRecipe(recipe: Recipe): Observable<Recipe> {
    return this.http.put(this.baseUrl + 'api/Recipe/Update', recipe)
      .map((resp: Response) => {
        return resp.json();
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
