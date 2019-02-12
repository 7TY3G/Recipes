import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Recipe } from '../shared/model/recipe';

@Component({
  selector: 'app-add-recipe',
  templateUrl: './add-recipe.component.html'
})
export class AddRecipeComponent {
  public recipe: Recipe;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.recipe = new Recipe('', 0);
  }

  saveRecipe() {
    debugger;

    this.http.post<Recipe>(this.baseUrl + 'api/Recipe/Add', this.recipe).subscribe(result => {
    }, error => console.error(error));
  }
}
