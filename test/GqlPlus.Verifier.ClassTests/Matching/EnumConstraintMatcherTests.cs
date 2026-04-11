namespace GqlPlus.Matching;

public class EnumConstraintMatcherTests
  : MatchTestsBase
{
  private readonly EnumConstraintMatcher _sut;
  private readonly Matcher<IAstEnum>.I _enumMatcher;

  public EnumConstraintMatcherTests()
  {
    Matcher<IAstEnum>.D enumMatcher = MatcherFor(out _enumMatcher);
    MatcherRepo.MatcherFor<IAstEnum>().Returns(enumMatcher);
    _sut = new(MatcherRepo);
  }

  [Theory, RepeatData]
  public void Matches_ReturnsExpected_WhenMatchingEnumLabelParent(string constraint, string name, bool expected)
  {
    IAstEnum enumType = A.Enum(constraint).AsEnum;
    Types[constraint] = enumType;

    IAstType type = A.Named<IAstType>(name);
    _enumMatcher.Matches(enumType, name, Context).Returns(expected);

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBe(expected);
  }
}
