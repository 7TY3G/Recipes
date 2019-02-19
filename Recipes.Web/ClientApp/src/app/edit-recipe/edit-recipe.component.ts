import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { EditIngredientListComponent } from '../shared/components/edit-ingredient-list.component';
import { Recipe } from '../shared/model/recipe';
import { Ingredient } from '../shared/model/Ingredient';

@Component({
  selector: 'app-edit-recipe',
  templateUrl: './edit-recipe.component.html'
})
export class EditRecipeComponent {
  recipe = new Recipe();
  id: string;
  saved: boolean = false;

  constructor(private router: Router, private currentRoute: ActivatedRoute, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.currentRoute.params.subscribe((queryParams: ParamMap) => {
      this.http.get<Recipe>(this.baseUrl + 'api/Recipe/GetById', { params: { id: queryParams['id'] } }).subscribe(result => {
        debugger;
        this.recipe = result;
      }, error => console.error(error));
    });
  }

  updateIngredients(updatedIngredients: Ingredient[]): void {
    this.recipe.ingredients = updatedIngredients;
  }

  saveRecipe({ value, valid }: { value: Recipe, valid: boolean }) {
    if (valid) {
      this.http.put<Recipe>(this.baseUrl + 'api/Recipe/Update', this.recipe).subscribe(result => {
        this.saved = true;
      }, error => console.error(error));
    }
  }

  backToRecipes() {
    this.router.navigate(['recipes-list']);
  }
}
