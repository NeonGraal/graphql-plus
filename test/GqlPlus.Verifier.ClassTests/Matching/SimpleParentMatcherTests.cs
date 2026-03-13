using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Matching;

public abstract class SimpleParentMatcherTests<TSimple>
  : MatchTestsBase
  where TSimple : class, IGqlpSimple
{
  private readonly SimpleParentMatcher<TSimple> _sut;

  protected SimpleParentMatcherTests() => _sut = new(MatcherRepo);

  [Theory, RepeatData]
  public void Simple_Matches_SameName_ReturnsTrue(string constraint)
  {
    TSimple type = MakeSimple(constraint).AsSimple;

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Simple_Matches_Parent_ReturnsTrue(string name, string constraint)
  {
    this.SkipEqual(name, constraint);

    TSimple type = MakeSimple(name).WithParent(constraint).AsSimple;

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Simple_Matches_GrandParent_ReturnsTrue(string name, string parent, string constraint)
  {
    this.SkipEqual(name, constraint);

    TSimple type = MakeSimple(name).WithParent(parent).AsSimple;

    TSimple parentType = MakeSimple(parent).WithParent(constraint).AsSimple;
    Types[parent] = parentType;

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBeTrue();
  }

  protected abstract SimpleBuilder<TSimple> MakeSimple(string name);
}

public class DomainParentMatcherTests
  : SimpleParentMatcherTests<IGqlpDomain<IGqlpDomainLabel>>
{
  protected override SimpleBuilder<IGqlpDomain<IGqlpDomainLabel>> MakeSimple(string name)
    => new DomainBuilder<IGqlpDomainLabel>(name, DomainKind.Enum);
}

public class EnumParentMatcherTests
  : SimpleParentMatcherTests<IGqlpEnum>
{
  protected override SimpleBuilder<IGqlpEnum> MakeSimple(string name)
    => new EnumBuilder(name);
}

public class UnionParentMatcherTests
  : SimpleParentMatcherTests<IGqlpUnion>
{
  protected override SimpleBuilder<IGqlpUnion> MakeSimple(string name)
    => new UnionBuilder(name);
}
