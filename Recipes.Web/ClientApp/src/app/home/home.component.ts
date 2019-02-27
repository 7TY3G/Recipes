import { Component } from '@angular/core';

import { Recipe } from '../shared/models/recipe';
import { RecipeService } from '../shared/services/recipe.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public recipes: Recipe[];

  constructor(private recipeService: RecipeService) {
    this.recipeService.getFavouriteRecipes()
      .subscribe((recipes: Recipe[]) => {
        this.recipes = recipes;
      },
      (error: any) => console.log(error),
      () => console.log('getFavouriteRecipes called'));
  }
}
