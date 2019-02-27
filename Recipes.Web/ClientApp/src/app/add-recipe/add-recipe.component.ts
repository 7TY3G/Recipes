import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { Recipe } from '../shared/models/recipe';
import { RecipeService } from '../shared/services/recipe.service';

@Component({
  selector: 'app-add-recipe',
  templateUrl: './add-recipe.component.html',
  styleUrls: ['./add-recipe.component.css']
})
export class AddRecipeComponent {
  recipe = new Recipe();

  constructor(private router: Router, private recipeService: RecipeService) {
  }

  saveRecipe({ value, valid }: { value: Recipe, valid: boolean }) {
    if (valid) {
      this.recipeService.addRecipe(this.recipe)
        .subscribe((recipe: Recipe) => {
          this.router.navigate(['recipes-list']);
        },
        (error: any) => console.log(error),
        () => console.log('register called'));
    }
  }
}
