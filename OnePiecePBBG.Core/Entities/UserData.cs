using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiecePBBG.Core.Entities
{
    public class UserData
    {
        public Guid Id { get; set; }
        public List<Character> Characters { get; set; }
    }
}
