import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Recipe } from '../shared/interface/recipe';

@Component({
  selector: 'app-add-recipe',
  templateUrl: './add-recipe.component.html'
})
export class AddRecipeComponent {
  recipe: Recipe = {
    name: '',
    rating: 0
  };

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  saveRecipe({ value, valid }: { value: Recipe, valid: boolean }) {
    debugger;
    if (valid) {
      this.recipe = value;

      this.http.post<Recipe>(this.baseUrl + 'api/Recipe/Add', this.recipe).subscribe(result => {
        this.router.navigate(['recipes-list']);
      }, error => console.error(error));
    }
  }
}
