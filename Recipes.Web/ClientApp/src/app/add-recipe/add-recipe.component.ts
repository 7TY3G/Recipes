import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Recipe } from '../shared/model/recipe';

@Component({
  selector: 'app-add-recipe',
  templateUrl: './add-recipe.component.html',
  styleUrls: ['./add-recipe.component.css']
})
export class AddRecipeComponent {
  recipe = new Recipe();

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  saveRecipe({ value, valid }: { value: Recipe, valid: boolean }) {
    if (valid) {
      this.http.post<Recipe>(this.baseUrl + 'api/Recipe/Add', this.recipe).subscribe(result => {
        this.router.navigate(['recipes-list']);
      }, error => console.error(error));
    }
  }
}
