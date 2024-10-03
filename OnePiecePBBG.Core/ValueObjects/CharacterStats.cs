using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiecePBBG.Core.ValueObjects
{
    public class CharacterStats
    {
        //TODO: Each stat will have a modifier
        public int Health { get; private set; }
        public int Stamina { get; private set; }
        public int Strength { get; private set; }
        public int Agility { get; private set; }
        public int Constitution { get; private set; }
        public int Charisma { get; private set; }
        public int Intelligence { get; private set; }
        public int Wisdom { get; private set; }

        public CharacterStats(int health = 5, int stamina = 150, int strength = 8, int agility = 8, int constitution = 8, 
            int charisma = 8, int intelligence = 8, int wisdom = 8)
        {
            Health = health;
            Stamina = stamina;
            Strength = strength;
            Agility = agility;
            Constitution = constitution;
            Charisma = charisma;
            Intelligence = intelligence;
            Wisdom = wisdom;
        }

        public void IncreaseStats()
        {
            Health += 5;
            Stamina += 5;
            Strength += 1;
            Agility += 1;
            Constitution += 1;
            Charisma += 1;
            Intelligence += 1;
            Wisdom += 1;
        }

        public CharacterStats ApplyBonuses(Dictionary<string, int> bonuses)
        {
            return new CharacterStats(
                Health + Constitution, //TODO: replace with CON modifier
                Strength + (bonuses.ContainsKey("Strength") ? bonuses["Strength"] : 0),
                Agility + (bonuses.ContainsKey("Agility") ? bonuses["Agility"] : 0),
                Constitution + (bonuses.ContainsKey("Constitution") ? bonuses["Constitution"] : 0),
                Charisma + (bonuses.ContainsKey("Charisma") ? bonuses["Charisma"] : 0),
                Intelligence + (bonuses.ContainsKey("Intelligence") ? bonuses["Intelligence"] : 0),
                Wisdom + (bonuses.ContainsKey("Wisdom") ? bonuses["Wisdom"] : 0)
            );
        }
    }
}
