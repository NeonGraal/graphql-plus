using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Matching;

public class AlternateConstraintMatcherTests
  : MatchAnyTypesTestsBase
{
  private readonly AlternateConstraintMatcher _sut;

  public AlternateConstraintMatcherTests()
    => _sut = new(LoggerFactory, AnyTypeMatcher);

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingAlternateMember(string name, string constraint)
  {
    IGqlpObject objectType = A.DualObj(constraint)
      .WithAlternate(name)
      .AsObject;
    Types[constraint] = objectType;

    IGqlpType type = A.DualObj(name).AsObject;

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsExpected_WhenMatchingAlternateMemberParent(string constraint, string name, string parent, bool expected)
  {
    this.SkipEqual3(name, constraint, parent);

    IGqlpObject constraintType = A.DualObj(constraint)
      .WithAlternate(name)
      .AsObject;
    Types[constraint] = constraintType;

    IGqlpObject namedType = A.DualObj(name)
      .WithParent(parent)
      .AsObject;
    Types[name] = namedType;

    IGqlpType type = A.DualObj(parent).AsObject;
    Types[parent] = type;
    AnyTypeMatches(expected);

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBe(expected);
  }
}
