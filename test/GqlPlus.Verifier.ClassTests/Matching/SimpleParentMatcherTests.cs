using GqlPlus.Ast.Schema;
using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Matching;

public abstract class SimpleParentMatcherTests<TSimple>
  : MatchTestsBase
  where TSimple : class, IAstSimple
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
  : SimpleParentMatcherTests<IAstDomain<IAstDomainLabel>>
{
  protected override SimpleBuilder<IAstDomain<IAstDomainLabel>> MakeSimple(string name)
    => new DomainBuilder<IAstDomainLabel>(name, DomainKind.Enum);
}

public class EnumParentMatcherTests
  : SimpleParentMatcherTests<IAstEnum>
{
  protected override SimpleBuilder<IAstEnum> MakeSimple(string name)
    => new EnumBuilder(name);
}

public class UnionParentMatcherTests
  : SimpleParentMatcherTests<IAstUnion>
{
  protected override SimpleBuilder<IAstUnion> MakeSimple(string name)
    => new UnionBuilder(name);
}
