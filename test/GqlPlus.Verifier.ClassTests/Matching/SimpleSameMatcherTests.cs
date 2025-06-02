namespace GqlPlus.Matching;

public abstract class SimpleSameMatcherTests<TSimple>
  : MatcherTestsBase
  where TSimple : class, IGqlpSimple
{
  private readonly SimpleSameMatcher<TSimple> _sut;

  protected SimpleSameMatcherTests()
  {
    _sut = new(LoggerFactory);
  }

  [Theory, RepeatData]
  public void Simple_Matches_SameName_ReturnsTrue(string constraint)
  {
    TSimple type = NFor<TSimple>(constraint);

    bool result = _sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Simple_Matches_Parent_ReturnsTrue(string name, string constraint)
  {
    TSimple type = NFor<TSimple>(name);
    type.Parent.Returns(constraint);

    bool result = _sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Simple_Matches_GrandParent_ReturnsTrue(string name, string parent, string constraint)
  {
    TSimple type = NFor<TSimple>(name);
    type.Parent.Returns(parent);

    TSimple parentType = NFor<TSimple>(parent);
    parentType.Parent.Returns(constraint);
    Types[parent] = parentType;

    bool result = _sut.Matches(type, constraint, Context);

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
