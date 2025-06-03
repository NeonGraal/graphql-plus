﻿namespace GqlPlus.Matching;

public class SpecialConstraintMatcherTests
  : MatcherTestsBase
{
  private readonly SpecialConstraintMatcher _sut;

  public SpecialConstraintMatcherTests()
    => _sut = new(LoggerFactory);

  [Theory, RepeatData]
  public void Matches_ReturnsExpected_WhenMatchingSpecialMember(string name, string constraint)
  {
    IGqlpTypeSpecial special = NFor<IGqlpTypeSpecial>(constraint);
    Types[constraint] = special;

    IGqlpType type = NFor<IGqlpType>(name);
    bool expected = false;
    special.MatchesTypeSpecial(type).Returns(expected);

    bool result = _sut.Matches(type, constraint, Context);

    result.ShouldBe(expected);
  }
}
