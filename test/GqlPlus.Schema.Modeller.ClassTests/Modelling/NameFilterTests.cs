namespace GqlPlus.Models;

public class NameFilterTests
{
  [Theory]
  [InlineData("abc", "abc")]
  [InlineData("_foo", "_foo")]
  public void Matches_ExactPattern_MatchesIdenticalName(string pattern, string name)
    => NameFilter.Matches(pattern, name).ShouldBeTrue();

  [Theory]
  [InlineData("abc", "abcd")]
  [InlineData("abc", "ab")]
  [InlineData("abc", "ABC")]
  public void Matches_ExactPattern_DoesNotMatchDifferentName(string pattern, string name)
    => NameFilter.Matches(pattern, name).ShouldBeFalse();

  [Theory]
  [InlineData("a.c", "abc")]
  [InlineData("a.c", "a_c")]
  [InlineData("T.pe", "Type")]
  public void Matches_DotPattern_MatchesAnyChar(string pattern, string name)
    => NameFilter.Matches(pattern, name).ShouldBeTrue();

  [Theory]
  [InlineData("a.c", "ac")]
  [InlineData("a.c", "abbc")]
  public void Matches_DotPattern_DoesNotMatchWrongLength(string pattern, string name)
    => NameFilter.Matches(pattern, name).ShouldBeFalse();

  [Theory]
  [InlineData("a*", "a")]
  [InlineData("a*", "abc")]
  [InlineData("a*", "a_long_name")]
  [InlineData("*", "anything")]
  [InlineData("*Dual*", "TypeDual")]
  [InlineData("*Dual*", "DualBase")]
  [InlineData("*Dual*", "DualType")]
  [InlineData("*Input*", "InputField")]
  public void Matches_StarPattern_MatchesZeroOrMoreChars(string pattern, string name)
    => NameFilter.Matches(pattern, name).ShouldBeTrue();

  [Theory]
  [InlineData("a*b", "ab")]
  [InlineData("a*b", "axyzb")]
  public void Matches_StarInMiddle_Matches(string pattern, string name)
    => NameFilter.Matches(pattern, name).ShouldBeTrue();

  [Theory]
  [InlineData("a*", "b")]
  [InlineData("*Dual*", "Input")]
  public void Matches_StarPattern_DoesNotMatchMismatch(string pattern, string name)
    => NameFilter.Matches(pattern, name).ShouldBeFalse();
}
