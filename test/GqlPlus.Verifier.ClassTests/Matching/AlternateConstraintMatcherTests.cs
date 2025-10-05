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
    IGqlpObject objectType = A.Named<IGqlpObject>(constraint);
    IGqlpObjAlt alternate = A.Named<IGqlpObjAlt>(name);
    objectType.Alternates.Returns([alternate]);
    Types[constraint] = objectType;

    IGqlpType type = A.Named<IGqlpType>(name);

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsExpected_WhenMatchingAlternateMemberParent(string constraint, string name, string parent, bool expected)
  {
    this.SkipEqual3(name, constraint, parent);

    IGqlpObject constraintType = A.Obj<IGqlpObject>(TypeKind.Dual, constraint);
    IGqlpObjAlt alternate = A.Named<IGqlpObjAlt>(name);
    constraintType.Alternates.Returns([alternate]);
    Types[constraint] = constraintType;

    IGqlpObject namedType = A.Obj<IGqlpObject>(TypeKind.Dual, name, parent);
    Types[name] = namedType;

    IGqlpType type = A.Named<IGqlpType>(parent);
    Types[parent] = type;
    AnyTypeMatches(expected);

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBe(expected);
  }
}
