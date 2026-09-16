namespace GqlPlus.Models;

public class FilterModelTests
{
  [Fact]
  public void Matches_NoFilter_ReturnsTrue()
  {
    FilterModel filter = new([]);

    filter.Matches("AnyName", []).ShouldBeTrue();
  }

  [Fact]
  public void Matches_NoFilter_WithAliases_ReturnsTrue()
  {
    FilterModel filter = new([]);

    filter.Matches("AnyName", ["alias1", "alias2"]).ShouldBeTrue();
  }

  [Theory]
  [InlineData("Foo", "Foo")]
  [InlineData("*Dual*", "TypeDual")]
  [InlineData("*Input*", "InputField")]
  public void Matches_NamePatternMatchesName_ReturnsTrue(string pattern, string name)
  {
    FilterModel filter = new([pattern]);

    filter.Matches(name, []).ShouldBeTrue();
  }

  [Theory]
  [InlineData("Foo", "Bar")]
  [InlineData("*Dual*", "InputType")]
  public void Matches_NamePatternDoesNotMatchName_ReturnsFalse(string pattern, string name)
  {
    FilterModel filter = new([pattern]);

    filter.Matches(name, []).ShouldBeFalse();
  }

  [Theory]
  [InlineData("Foo", "Bar", "Foo")]
  [InlineData("*Dual*", "Input", "TypeDual")]
  public void Matches_NamePatternMatchesAlias_WhenMatchAliasesTrue_ReturnsTrue(string pattern, string name, string alias)
  {
    FilterModel filter = new([pattern]) { MatchAliases = true };

    filter.Matches(name, [alias]).ShouldBeTrue();
  }

  [Theory]
  [InlineData("Foo", "Bar", "Foo")]
  [InlineData("*Dual*", "Input", "TypeDual")]
  public void Matches_NamePatternDoesNotMatchAlias_WhenMatchAliasesFalse_ReturnsFalse(string pattern, string name, string alias)
  {
    FilterModel filter = new([pattern]) { MatchAliases = false };

    filter.Matches(name, [alias]).ShouldBeFalse();
  }

  [Theory]
  [InlineData("al*", "Bar", "alias1")]
  [InlineData("*Dual", "Input", "TypeDual")]
  public void Matches_AliasFilter_MatchesAlias_ReturnsTrue(string aliasPattern, string name, string alias)
  {
    FilterModel filter = new([]) { Aliases = [aliasPattern] };

    filter.Matches(name, [alias]).ShouldBeTrue();
  }

  [Theory]
  [InlineData("al*", "Bar", "other")]
  public void Matches_AliasFilter_NoMatchingAlias_ReturnsFalse(string aliasPattern, string name, string alias)
  {
    FilterModel filter = new([]) { Aliases = [aliasPattern] };

    filter.Matches(name, [alias]).ShouldBeFalse();
  }

  [Theory]
  [InlineData("Foo", "Bar", "Baz")]
  public void Matches_MultipleNames_MatchesIfAnyMatches(string name1, string name2, string name3)
  {
    FilterModel filter = new([name1, name2]);

    filter.Matches(name1, []).ShouldBeTrue();
    filter.Matches(name2, []).ShouldBeTrue();
    filter.Matches(name3, []).ShouldBeFalse();
  }
}
