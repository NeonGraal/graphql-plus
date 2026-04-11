using GqlPlus.Ast.Schema;
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Matching;

public class AlternateConstraintMatcherTests
  : MatchAnyTypesTestsBase
{
  private readonly AlternateConstraintMatcher _sut;

  public AlternateConstraintMatcherTests()
    => _sut = new(MatcherRepo);

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingAlternateMember(string name, string constraint)
  {
    IAstObject objectType = A.DualObj(constraint)
      .WithAlternate(name)
      .AsObject;
    Types[constraint] = objectType;

    IAstType type = A.DualObj(name).AsObject;

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsExpected_WhenMatchingAlternateMemberParent(string constraint, string name, string parent, bool expected)
  {
    this.SkipEqualAny([name, constraint, parent]);

    IAstObject constraintType = A.DualObj(constraint)
      .WithAlternate(name)
      .AsObject;
    Types[constraint] = constraintType;

    IAstObject namedType = A.DualObj(name)
      .WithParent(parent)
      .AsObject;
    Types[name] = namedType;

    IAstType type = A.DualObj(parent).AsObject;
    Types[parent] = type;
    AnyTypeMatches(expected);

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBe(expected);
  }
}
