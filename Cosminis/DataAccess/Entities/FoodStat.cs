﻿using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class FoodStat
    {
        public FoodStat()
        {
            FoodInventories = new HashSet<FoodInventory>();
        }

        public int FoodStatsId { get; set; }
        public int FoodElementFk { get; set; }
        public string Description { get; set; } = null!;
        public string FoodName { get; set; } = null!;
        public int HungerRestore { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual FoodElement FoodElementFkNavigation { get; set; } = null!;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<FoodInventory> FoodInventories { get; set; }
    }
}
