﻿using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class FoodElement
    {
        public FoodElement()
        {
            FoodStats = new HashSet<FoodStat>();
            SpeciesFoodElementFkNavigations = new HashSet<Species>();
            SpeciesOppFoodElementFkNavigations = new HashSet<Species>();
        }

        public int FoodElementId { get; set; }
        public string FoodElement1 { get; set; } = null!;

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<FoodStat> FoodStats { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Species> SpeciesFoodElementFkNavigations { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Species> SpeciesOppFoodElementFkNavigations { get; set; }
    }
}
