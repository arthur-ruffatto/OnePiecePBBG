using Moq;
using OnePiecePBBG.Core.Entities;
using OnePiecePBBG.Core.ValueObjects;

namespace OnePiecePBBG.Tests.Common.Fixtures
{
    public class CharacterFixture : BaseFixture
    {
        public CharacterFixture() : base()
        { }

        public Mock<Race> GetRaceMock() => new();

        public Mock<Class> GetClassMock() => new();

        public Mock<Career> GetCareerMock() => new();

        public string GetValidCharacterName() => Faker.Name.FullName();

        public CharacterStats GetValidInitialStats() => new CharacterStats();
    }

    [CollectionDefinition(nameof(CharacterFixture))]
    public class CharacterFixtureCollection
    : ICollectionFixture<CharacterFixture>
    { }
}
