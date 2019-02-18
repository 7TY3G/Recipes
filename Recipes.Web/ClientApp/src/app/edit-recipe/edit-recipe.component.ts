import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Recipe } from '../shared/interface/recipe';

@Component({
  selector: 'app-edit-recipe',
  templateUrl: './edit-recipe.component.html'
})
export class EditRecipeComponent implements OnInit {
  recipeForm: FormGroup;
  recipe: Recipe = {
    id: 0,
    name: '',
    rating: 0
  };
  id: string;
  saved: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private currentRoute: ActivatedRoute,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {
    this.currentRoute.params.subscribe((queryParams: ParamMap) => {
      this.http.get<Recipe>(this.baseUrl + 'api/Recipe/GetById', { params: { id: queryParams['id'] } }).subscribe(result => {
        this.populateForm(result);
        this.recipe = result;
      }, error => console.error(error));
    });
  }

  ngOnInit() {
    this.recipeForm = this.formBuilder.group({
      name: '',
      rating: ''
    });
  }

  saveRecipe(): void {
    if (this.recipeForm.valid) {
      this.populateRecipeResult();

      this.http.put<Recipe>(this.baseUrl + 'api/Recipe/Update', this.recipe).subscribe(result => {
        this.saved = true;
      }, error => console.error(error));
    }
  }

  backToRecipes(): void {
    this.router.navigate(['recipes-list']);
  }

  populateForm(recipe: Recipe): void {
    this.recipeForm.setValue({
      name: recipe.name,
      rating: recipe.rating
    })
  }

  populateRecipeResult(): void {
    this.recipe.name = this.recipeForm.get('name').value;
    this.recipe.rating = this.recipeForm.get('rating').value;
  }
}
