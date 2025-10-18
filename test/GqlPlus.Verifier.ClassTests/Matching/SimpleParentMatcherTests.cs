namespace GqlPlus.Matching;

public abstract class SimpleParentMatcherTests<TSimple>
  : MatchTestsBase
  where TSimple : class, IGqlpSimple
{
  private readonly SimpleParentMatcher<TSimple> _sut;

  protected SimpleParentMatcherTests() => _sut = new(LoggerFactory);

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
    this.SkipEqual(name, constraint);

    TSimple type = A.Simple<TSimple>(name);
    A.SetParent(type, constraint);

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Simple_Matches_GrandParent_ReturnsTrue(string name, string parent, string constraint)
  {
    this.SkipEqual(name, constraint);

    TSimple type = A.Simple<TSimple>(name);
    A.SetParent(type, parent);

    TSimple parentType = A.Simple<TSimple>(parent);
    A.SetParent(parentType, constraint);
    Types[parent] = parentType;

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBeTrue();
  }
}

public class DomainParentMatcherTests
  : SimpleParentMatcherTests<IGqlpDomain>
{ }

public class EnumParentMatcherTests
  : SimpleParentMatcherTests<IGqlpEnum>
{ }

public class UnionParentMatcherTests
  : SimpleParentMatcherTests<IGqlpUnion>
{ }
