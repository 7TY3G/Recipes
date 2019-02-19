import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Recipe } from '../shared/model/recipe';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public recipes: Recipe[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Recipe[]>(baseUrl + 'api/RecipesList/Favourites').subscribe(result => {
      this.recipes = result;

    }, error => console.error(error));
  }
}
