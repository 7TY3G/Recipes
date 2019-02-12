import { Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export class recipeService {
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

  }
}
