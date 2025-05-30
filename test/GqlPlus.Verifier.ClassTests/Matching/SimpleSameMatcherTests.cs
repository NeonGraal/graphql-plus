namespace GqlPlus.Matching;

public abstract class SimpleSameMatcherTests<TSimple>
  : MatcherTestsBase
  where TSimple : class, IGqlpSimple
{
  private readonly SimpleSameMatcher<TSimple> _sut = new();

  [Theory, RepeatData]
  public void Simple_Matches_SameName_ReturnsTrue(string name)
  {
    TSimple type = NFor<TSimple>(name);

    bool result = _sut.Matches(type, name, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Simple_Matches_Parent_ReturnsTrue(string name, string parent)
  {
    TSimple type = NFor<TSimple>(name);
    type.Parent.Returns(parent);

    bool result = _sut.Matches(type, parent, Context);

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
