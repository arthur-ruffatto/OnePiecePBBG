using OnePiecePBBG.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiecePBBG.Core.Entities
{
    public class Class
    {
        public string Name { get; private set; }
        public List<string> Prerequisites { get; private set; }

        public Class(string name, List<string> prerequisites)
        {
            Name = name;
            Prerequisites = prerequisites;
        }

        public CharacterStats ApplyLevelBonuses(int level, CharacterStats stats, List<Skill> skills)
        {
            // Logic to apply bonuses or modify skills per level for this class
            return new CharacterStats();
        }
    }
}
