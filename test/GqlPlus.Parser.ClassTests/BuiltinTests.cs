namespace GqlPlus;

public class BuiltinTests
{
  [Fact]
  public void SpecialType_Checks_AreMostlyFalseForNull()
  {
    int count = BuiltIn.Special
      .Where(s => s.MatchesTypeSpecial(null!)).Count();

    count.ShouldBe(1);
  }
}
