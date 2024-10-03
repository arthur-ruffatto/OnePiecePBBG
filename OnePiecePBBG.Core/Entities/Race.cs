using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiecePBBG.Core.Entities
{
    public class Race
    {
        public string Name { get; private set; }
        public Dictionary<string, int> Bonuses { get; private set; }

        public Race(string name, Dictionary<string, int> bonuses)
        {
            Name = name;
            Bonuses = bonuses;
        }

        public static Race Human = new Race("Human", new Dictionary<string, int> {
            { "Strength", 1 },
            { "Agility", 1 },
            { "Constitution", 1 },
            { "Charisma", 1 },
            { "Intelligence", 1 },
            { "Wisdom", 1 }
        });

        public static Race Merfolk = new Race("Merfolk", new Dictionary<string, int> {
            { "Agility", 2 },
            { "Constitution", -2 },
            { "Intelligence", 2 },
        });

        public static Race Fishman = new Race("Fishmen", new Dictionary<string, int> {
            { "Strength", 2 },
            { "Constitution", 2 },
            { "Intelligence", -2 },
        });

        public static Race Giant = new Race("Giant", new Dictionary<string, int> {
            { "Strength", 4 },
            { "Agility", -2 },
            { "Constitution", 4 },
            { "Intelligence", -2 },
            { "Wisdom", -2 }
        });
    }
}
