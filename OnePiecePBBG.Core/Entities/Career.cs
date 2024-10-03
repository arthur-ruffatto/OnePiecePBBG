using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiecePBBG.Core.Entities
{
    public class Career
    {
        public string Name { get; private set; }
        public List<string> Prerequisites { get; private set; }

        public Career(string name, List<string> prerequisites)
        {
            Name = name;
            Prerequisites = prerequisites;
        }

        // Similar to class, implement logic related to career bonuses
    }
}
