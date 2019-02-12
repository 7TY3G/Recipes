using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Domain.Entities
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }

        public double Rating { get; set; }
    }
}
