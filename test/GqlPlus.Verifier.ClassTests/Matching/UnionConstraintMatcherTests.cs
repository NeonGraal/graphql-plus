using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Matching;

public class UnionConstraintMatcherTests
  : MatchAnyTypesTestsBase
{
  private readonly UnionConstraintMatcher _sut;

  public UnionConstraintMatcherTests()
    => _sut = new(MatcherRepo);

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingUnionMember(string name, string constraint)
  {
    IGqlpUnion union = A.Union(constraint).WithMembers([name]).AsUnion;
    Types[constraint] = union;

    IAstType type = A.Named<IAstType>(name);

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsExpected_WhenMatchingUnionMemberParent(string constraint, string name, string parent, bool expected)
  {
    this.SkipEqualAny([constraint, name, parent]);

    IGqlpUnion union = A.Union(constraint).WithMembers([name]).AsUnion;
    Types[constraint] = union;

    IAstSimple simple = A.Union(name).WithParent(parent).AsSimple;
    Types[name] = simple;

    IAstType type = A.Named<IAstType>(parent);
    Types[parent] = type;
    AnyTypeMatches(expected);

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBe(expected);
  }
}
