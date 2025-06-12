namespace GqlPlus.Matching;

public class EnumConstraintMatcherTests
  : MatcherTestsBase
{
  private readonly EnumConstraintMatcher _sut;
  private readonly Matcher<IGqlpEnum>.I _enumMatcher;

  public EnumConstraintMatcherTests()
  {
    Matcher<IGqlpEnum>.D enumMatcher = MatcherFor(out _enumMatcher);

    _sut = new(LoggerFactory, enumMatcher);
  }

  [Theory, RepeatData]
  public void Matches_ReturnsExpected_WhenMatchingEnumLabelParent(string constraint, string name, bool expected)
  {
    IGqlpEnum enumType = A.Enum(constraint, []);
    Types[constraint] = enumType;

    IGqlpType type = A.Named<IGqlpType>(name);
    _enumMatcher.Matches(enumType, name, Context).Returns(expected);

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBe(expected);
  }
}
