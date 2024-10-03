using FluentAssertions;
using Moq;
using OnePiecePBBG.Core.Entities;
using OnePiecePBBG.Core.Enums;
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
        [Trait("CoreDomain","Entities - Character")]
        public void InstantiateValidCharacter()
        {
            //Arrange
            var name = _characterFixture.GetValidCharacterName();
            var stats = new CharacterStats();

            //Act
            var validCharacter = new Character(name, stats);

            //Assert
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

        [Fact(DisplayName = nameof(AddExperience_ShouldIncreaseExperienceAndLevel))]
        [Trait("CoreDomain", "Entities - Character")]
        public void AddExperience_ShouldIncreaseExperienceAndLevel()
        {
            // Arrange
            var name = _characterFixture.GetValidCharacterName();
            var stats = new CharacterStats();
            var character = new Character(name, stats);

            var experienceToAdd = 1000; // Enough to reach level 2

            // Act
            character.GainExperience(experienceToAdd);

            // Assert
            character.Experience.Should().Be(experienceToAdd);
            character.Level.Should().Be(2);
        }

        [Fact(DisplayName = nameof(AddExperience_ShouldRemainSameLevel))]
        [Trait("CoreDomain", "Entities - Character")]
        public void AddExperience_ShouldRemainSameLevel()
        {
            // Arrange
            var name = _characterFixture.GetValidCharacterName();
            var stats = new CharacterStats();
            var character = new Character(name, stats);

            var experienceToAdd = 500;

            // Act
            character.GainExperience(experienceToAdd);

            // Assert
            character.Experience.Should().Be(experienceToAdd);
            character.Level.Should().Be(1);
        }

        [Fact(DisplayName = nameof(ReachNextLevel_ShouldApplyStatBonuses))]
        [Trait("CoreDomain", "Entities - Character")]
        public void ReachNextLevel_ShouldApplyStatBonuses()
        {
            // Arrange
            var name = _characterFixture.GetValidCharacterName();
            var initialStats = _characterFixture.GetValidInitialStats();
            var initialHealth = initialStats.Health;
            var character = new Character(name, initialStats);

            var experienceToAdd = 10000; // Enough to reach at least level 5

            // Act
            character.GainExperience(experienceToAdd);

            // Assert
            character.Level.Should().Be(5);
            character.Stats.Health.Should().BeGreaterThan(initialHealth);
        }

        [Fact(DisplayName = nameof(AddExperience_ShouldCarryOverExperienceToNextLevel))]
        [Trait("CoreDomain", "Entities - Character")]
        public void AddExperience_ShouldCarryOverExperienceToNextLevel()
        {
            // Arrange
            var name = _characterFixture.GetValidCharacterName();
            var stats = new CharacterStats();
            var character = new Character(name, stats);

            var experienceToAdd = 1500; // 1000 for level-up + 500 extra

            // Act
            character.GainExperience(experienceToAdd);

            // Assert
            character.Level.Should().Be(2);
            character.Experience.Should().Be(1500); // Remaining experience carried over
        }

        [Fact(DisplayName = nameof(AddItemToInventory_ShouldIncreaseInventoryCount))]
        [Trait("CoreDomain", "Entities - Character")]
        public void AddItemToInventory_ShouldIncreaseInventoryCount()
        {
            // Arrange
            var name = _characterFixture.GetValidCharacterName();
            var stats = new CharacterStats();
            var character = new Character(name, stats);

            var item = new Item("Sword", ItemTier.B, 1);

            // Act
            character.AddItem(item);

            // Assert
            character.Inventory.Should().Contain(item);
            character.Inventory.Count.Should().Be(1);
        }
    }
}
