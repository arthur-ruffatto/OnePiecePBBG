using FluentAssertions;
using Moq;
using OnePiecePBBG.Core.Entities;
using OnePiecePBBG.Core.ValueObjects;
using OnePiecePBBG.Tests.Common.Fixtures;

namespace OnePiecePBBG.Tests.CoreDomain.Entities
{
    [Collection(nameof(CharacterFixture))]
    public class CharacterTest
    {
        private readonly CharacterFixture _characterFixture;

        public CharacterTest(CharacterFixture characterFixture)
        {
            _characterFixture = characterFixture;
        }

        [Fact(DisplayName = nameof(InstantiateValidCharacter))]
        [Trait("CoreDomain"," Entities - Character")]
        public void InstantiateValidCharacter()
        {
            var name = _characterFixture.GetValidCharacterName();
            var stats = new CharacterStats();

            var validCharacter = new Character(name, stats);

            validCharacter.Should().NotBeNull();
            validCharacter.CharacterName.Should().Be(name);
            validCharacter.CurrentIsland.Should().NotBeNull();
            validCharacter.Experience.Should().Be(0);
            validCharacter.Id.Should().NotBeEmpty();
            validCharacter.Inventory.Should().NotBeNull();
            validCharacter.Level.Should().Be(1);
            validCharacter.Stats.Should().NotBeNull();
            validCharacter.Skills.Should().NotBeNull();
        }
    }
}
