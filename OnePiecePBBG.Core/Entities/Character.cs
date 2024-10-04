using OnePiecePBBG.Core.Exceptions;
using OnePiecePBBG.Core.Validations;
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

            Validate();
        }

        private void Validate()
        {
            DomainValidation.EnsureNotNullOrEmpty(CharacterName, nameof(CharacterName));
            DomainValidation.EnsureGreaterThan(Level, 0, nameof(Level));
            DomainValidation.EnsureNotNegative(Experience, nameof(Experience));
            DomainValidation.EnsureNotNull(Stats, nameof(Stats));
            DomainValidation.EnsureNotNull(Inventory, nameof(Inventory));
        }

        public void GainExperience(int amount)
        {
            Experience += amount;
            while (Experience >= ExperienceToLevelUp())
                LevelUp();

            Validate();
        }

        private int ExperienceToLevelUp()
        {
            return Level switch
            {
                1 => 1000,
                2 => 3000,
                3 => 6000,
                4 => 10000,
                5 => 15000,
                6 => 21000,
                7 => 28000,
                8 => 36000,
                9 => 45000,
                10 => 55000,
                11 => 66000,
                12 => 78000,
                13 => 91000,
                14 => 105000,
                15 => 120000,
                16 => 136000,
                17 => 153000,
                18 => 171000,
                19 => 190000,
                _ => 1000 * (Level - 1) // Formula after level 20
            };
        }

        private CharacterStats ApplyRaceBonuses(CharacterStats allocatedStats, Race race)
        {
            return allocatedStats.ApplyBonuses(race.Bonuses);
        }

        private void LevelUp()
        {
            Level++;
            Stats.IncreaseStats();
        }

        public void AddItem(Item item)
        {
            Inventory.Add(item);
            Validate();
        }

        public void RemoveItem(Item item)
        {
            Inventory.Remove(item);
            Validate();
        }
    }
}
