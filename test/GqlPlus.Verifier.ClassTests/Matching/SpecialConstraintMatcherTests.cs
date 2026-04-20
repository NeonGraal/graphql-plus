using GqlPlus.Ast.Schema;

namespace GqlPlus.Matching;

public class SpecialConstraintMatcherTests
  : MatchTestsBase
{
  private readonly SpecialConstraintMatcher _sut;

  public SpecialConstraintMatcherTests()
    => _sut = new(MatcherRepo);

  [Theory, RepeatData]
  public void Matches_ReturnsExpected_WhenMatchingSpecialMember(string name, string constraint)
  {
    IAstTypeSpecial special = A.Named<IAstTypeSpecial>(constraint);
    Types[constraint] = special;

    IAstType type = A.Named<IAstType>(name);
    bool expected = false;
    special.MatchesTypeSpecial(type).Returns(expected);

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBe(expected);
  }
}
