using OnePiecePBBG.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiecePBBG.Core.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ItemTier Tier { get; set; }
        public double DropChance { get; set; }

        public Item(string name, ItemTier tier, double dropChance)
        {
            Id = Guid.NewGuid();
            Name = name;
            Tier = tier;
            DropChance = dropChance;
        }
    }
}
