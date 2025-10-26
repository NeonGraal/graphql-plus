using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Matching;

public class UnionConstraintMatcherTests
  : MatchAnyTypesTestsBase
{
  private readonly UnionConstraintMatcher _sut;

  public UnionConstraintMatcherTests()
    => _sut = new(LoggerFactory, AnyTypeMatcher);

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingUnionMember(string name, string constraint)
  {
    IGqlpUnion union = A.Union(constraint).WithMembers([name]).AsUnion;
    Types[constraint] = union;

    IGqlpType type = A.Named<IGqlpType>(name);

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsExpected_WhenMatchingUnionMemberParent(string constraint, string name, string parent, bool expected)
  {
    this.SkipEqual3(constraint, name, parent);

    IGqlpUnion union = A.Union(constraint).WithMembers([name]).AsUnion;
    Types[constraint] = union;

    IGqlpSimple simple = A.Simple<IGqlpSimple>(name).WithParent(parent).AsSimple;
    Types[name] = simple;

    IGqlpType type = A.Named<IGqlpType>(parent);
    Types[parent] = type;
    AnyTypeMatches(expected);

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBe(expected);
  }
}
