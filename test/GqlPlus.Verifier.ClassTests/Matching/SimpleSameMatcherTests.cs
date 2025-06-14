namespace GqlPlus.Matching;

public abstract class SimpleSameMatcherTests<TSimple>
  : MatcherTestsBase
  where TSimple : class, IGqlpSimple
{
  private readonly SimpleSameMatcher<TSimple> _sut;

  protected SimpleSameMatcherTests() => _sut = new(LoggerFactory);

  [Theory, RepeatData]
  public void Simple_Matches_SameName_ReturnsTrue(string constraint)
  {
    TSimple type = A.Named<TSimple>(constraint);

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Simple_Matches_Parent_ReturnsTrue(string name, string constraint)
  {
    this.SkipIf(name == constraint);

    TSimple type = A.Simple<TSimple>(name, constraint);

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Simple_Matches_GrandParent_ReturnsTrue(string name, string parent, string constraint)
  {
    this.SkipIf(name == constraint);

    TSimple type = A.Simple<TSimple>(name, parent);

    TSimple parentType = A.Simple<TSimple>(parent, constraint);
    Types[parent] = parentType;

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBeTrue();
  }
}

public class DomainSimpleSameMatcherTests
  : SimpleSameMatcherTests<IGqlpDomain>
{ }

public class EnumSimpleSameMatcherTests
  : SimpleSameMatcherTests<IGqlpEnum>
{ }

public class UnionSimpleSameMatcherTests
  : SimpleSameMatcherTests<IGqlpUnion>
{ }
