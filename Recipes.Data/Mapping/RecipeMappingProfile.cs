using AutoMapper;
using Recipes.Data.DataModels;
using Recipes.Domain.Entities;

namespace Recipes.Data.Mapping
{
    public class RecipeMappingProfile : Profile
    {
        public RecipeMappingProfile()
        {
            CreateMap<RecipeEntity, Recipe>()
                .ReverseMap();
            CreateMap<RecipeIngredientEntity, Ingredient>()
                .ForMember(r => r.Name, i => i.MapFrom(src => src.Ingredient.Name))
                .ReverseMap();
        }
    }
}
