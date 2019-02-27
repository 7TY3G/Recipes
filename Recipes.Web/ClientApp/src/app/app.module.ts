import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { RegistrationComponent } from './account/registration/registration.component';
import { LoginComponent } from './account/login/login.component';
import { RecipesListComponent } from './recipes-list/reciples-list.component';
import { AddRecipeComponent } from './add-recipe/add-recipe.component';
import { EditRecipeComponent } from './edit-recipe/edit-recipe.component';
import { EditIngredientListComponent } from './shared/components/edit-ingredient-list.component';

import { RecipeService } from './shared/services/recipe.service';
import { AccountService } from './shared/services/account.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    RegistrationComponent,
    LoginComponent,
    RecipesListComponent,
    AddRecipeComponent,
    EditRecipeComponent,
    EditIngredientListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'registration', component: RegistrationComponent },
      { path: 'login', component: LoginComponent },
      { path: 'recipes-list', component: RecipesListComponent },
      { path: 'add-recipe', component: AddRecipeComponent },
      { path: 'edit-recipe/:id', component: EditRecipeComponent }
    ])
  ],
  providers: [
    AccountService,
    RecipeService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
