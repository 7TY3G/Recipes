import { Component } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { Recipe } from '../shared/models/recipe';
import { RecipeService } from '../shared/services/recipe.service';

@Component({
  selector: 'app-edit-recipe',
  templateUrl: './edit-recipe.component.html',
  styleUrls: ['./add-recipe.component.css']
})
export class EditRecipeComponent {
  recipe = new Recipe();
  id: string;
  saved: boolean = false;

  constructor(private router: Router, private currentRoute: ActivatedRoute, private recipeService: RecipeService) {
    this.currentRoute.params.subscribe((queryParams: ParamMap) => {
      let recipeParams = { params: { id: queryParams['id'] } };

      this.recipeService.getRecipe(recipeParams)
        .subscribe((recipe: Recipe) => {
          this.recipe = recipe
        },
        (error: any) => console.log(error),
        () => console.log('register called'));
    });
  }

  saveRecipe({ value, valid }: { value: Recipe, valid: boolean }) {
    if (valid) {
      this.recipeService.saveRecipe(this.recipe)
        .subscribe((recipe: Recipe) => {
          this.saved = true;

          // TODO: Route to saved recipe
        },
        (error: any) => console.log(error),
        () => console.log('register called'));
    }
  }

  backToRecipes() {
    this.router.navigate(['recipes-list']);
  }
}
