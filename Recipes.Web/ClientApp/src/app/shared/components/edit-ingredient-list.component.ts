import { Component, Input } from '@angular/core';
import { ControlContainer, NgForm } from '@angular/forms';
import { Ingredient } from '../models/Ingredient';

@Component({
  selector: 'edit-ingredient-list',
  templateUrl: './edit-ingredient-list.component.html',
  styleUrls: ['./edit-ingredient-list.component.css'],
  viewProviders: [{ provide: ControlContainer, useExisting: NgForm }]
})
export class EditIngredientListComponent {
  @Input() parentForm: NgForm;
  @Input() ingredients: Ingredient[];

  addIngredient(): void {
    let ingredient = new Ingredient();
    this.ingredients.push(ingredient);

    this.formUpdated();
  }

  removeIngredient(indexToRemove: number): void {
    this.ingredients.splice(indexToRemove, 1);

    this.formUpdated();
  }

  formUpdated(): void {
    this.parentForm.form.controls.ingredients.markAsDirty();
    this.parentForm.form.controls.ingredients.markAsTouched();
  }
}
