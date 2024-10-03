using OnePiecePBBG.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiecePBBG.Core.Entities
{
    public class Character
    {
        public Guid Id { get; private set; }
        public string CharacterName {  get; private set; }
        public int Level { get; private set; }
        public int Experience { get; private set; }
        public List<Item> Inventory { get; private set; }
        public Island CurrentIsland { get; private set; }
        public CharacterStats Stats { get; private set; }
        public Race? Race { get; private set; }
        public Class? CharacterClass { get; private set; }
        public Career? CharacterCareer { get; private set; }
        public List<Skill> Skills { get; private set; }

        private static readonly int[] ExperienceRequired = {
            0, 1000, 3000, 6000, 10000, 15000, 21000, 28000, 36000, 45000,
            55000, 66000, 78000, 91000, 105000, 120000, 136000, 153000, 171000, 190000
        };

        public Character(string characterName, CharacterStats allocatedStats, Race? race = null, Class? characterClass = null, 
            Career? characterCareer = null)
        {
            Id = Guid.NewGuid();
            CharacterName = characterName;
            Level = 1;
            Experience = 0;
            Inventory = new List<Item>();
            CurrentIsland = new Island();
            /*Race = race;
            CharacterClass = characterClass;
            CharacterCareer = characterCareer;*/
            Stats = allocatedStats; //TODO: ApplyRaceBonuses(allocatedStats, race);
            Skills = new List<Skill>();
        }

        public void GainExperience(int amount)
        {
            Experience += amount;
            while (Experience >= ExperienceToLevelUp())
                LevelUp();
        }

        private int ExperienceToLevelUp()
        {
            //TODO: Create static class LevelingSystem
            if (Level < 20)
            {
                return ExperienceRequired[Level - 1]; 
            }
            return ExperienceRequired[ExperienceRequired.Length - 1] + 1000 * (Level - 20); // Formula for levels beyond 20
        }

        private CharacterStats ApplyRaceBonuses(CharacterStats allocatedStats, Race race)
        {
            return allocatedStats.ApplyBonuses(race.Bonuses);
        }

        public void LevelUp()
        {
            Level++;
            Experience = 0;
            Stats.IncreaseStats();
        }

        public void AddItem(Item item)
        {
            Inventory.Add(item);
        }

        public void RemoveItem(Item item)
        {
            Inventory.Remove(item);
        }
    }
}
