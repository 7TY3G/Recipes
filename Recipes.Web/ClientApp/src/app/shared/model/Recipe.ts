import { Ingredient } from "./Ingredient";

export class Recipe {
  constructor(
    public id = 0,
    public name = '',
    public ingredients = [] as Ingredient[],
    public rating = 0
  ) {}
}
