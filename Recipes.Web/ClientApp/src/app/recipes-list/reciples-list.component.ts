import { Component } from '@angular/core';

import { Recipe } from '../shared/models/recipe';
import { RecipeService } from '../shared/services/recipe.service';

@Component({
  selector: 'app-recipes-list',
  templateUrl: './recipes-list.component.html'
})
export class RecipesListComponent {
  public recipes: Recipe[] = [];

  constructor(private recipeService: RecipeService) {
    this.recipeService.getRecipes()
      .subscribe((recipes: Recipe[]) => {
        this.recipes = recipes;
      },
      (error: any) => console.log(error),
      () => console.log('getRecipes called'));
  }
}
