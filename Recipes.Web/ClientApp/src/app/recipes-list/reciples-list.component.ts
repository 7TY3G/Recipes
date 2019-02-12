import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IRecipe } from '../shared/interface/recipe';

@Component({
  selector: 'app-recipes-list',
  templateUrl: './recipes-list.component.html'
})
export class RecipesListComponent {
  public recipes: IRecipe[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<IRecipe[]>(baseUrl + 'api/RecipesList/Get').subscribe(result => {
      this.recipes = result;

    }, error => console.error(error));
  }
}
