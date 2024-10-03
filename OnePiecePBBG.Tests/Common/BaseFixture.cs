using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiecePBBG.Tests.Common
{
    public class BaseFixture
    {
        public Faker Faker {  get; set; }

        public BaseFixture() => Faker = new Faker();
    }
}
