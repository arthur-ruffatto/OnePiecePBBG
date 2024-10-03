using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiecePBBG.Core.Entities
{
    public class Quest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsMainQuest { get; set; }
        public bool IsCompleted { get; set; }
        public int RewardExperience { get; set; }
        public int RewardCoins { get; set; }
        public List<Item> Items { get; set; }
    }
}
