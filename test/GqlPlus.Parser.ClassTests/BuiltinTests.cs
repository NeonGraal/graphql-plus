using GqlPlus.Abstractions.Schema;

namespace GqlPlus;

public class BuiltinTests
{
  [Fact]
  public void SpecialType_MatchesType_AreMostlyFalseForNull()
  {
    // Act
    int count = BuiltIn.Special
      .Where(s => s.MatchesTypeSpecial(null!)).Count();

    // Assert
    count.ShouldBe(1);
  }

  [Fact]
  public void SpecialType_MatchesKind_AreMostlyFalseForEmptySet()
  {
    // Act
    int count = BuiltIn.Special
      .Where(s => s.MatchesKindSpecial([])).Count();

    // Assert
    count.ShouldBe(1);
  }

  [Theory, CombinatorialData]
  public void SpecialType_MatchesKind_ExpectedCount(TypeKind kind)
  {
    // Arrange
    int expected = kind switch {
      TypeKind.Internal => 3,
      TypeKind.Special => 1,
      _ => 2,
    };

    // Act
    int count = BuiltIn.Special
      .Where(s => s.MatchesKindSpecial([kind])).Count();

    // Assert
    count.ShouldBe(expected);
  }
}
