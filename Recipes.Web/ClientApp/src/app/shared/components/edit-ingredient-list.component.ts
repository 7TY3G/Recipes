import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Ingredient } from '../model/Ingredient';

@Component({
  selector: 'edit-ingredient-list',
  templateUrl: './edit-ingredient-list.component.html'
})
export class EditIngredientListComponent {
  @Input() ingredients: Ingredient[];
  @Output() updateIngredients = new EventEmitter();

  addIngredient(): void {
    let ingredient = new Ingredient();
    this.ingredients.push(ingredient);
    this.updateIngredients.emit(this.ingredients);
  }

  removeIngredient(indexToRemove: number): void {
    this.ingredients.splice(indexToRemove, 1);
    this.updateIngredients.emit(this.ingredients);
  }
}
