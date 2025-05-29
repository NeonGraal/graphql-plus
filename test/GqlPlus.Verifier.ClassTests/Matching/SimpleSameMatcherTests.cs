using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Matching;

public abstract class SimpleSameMatcherTests<TSimple>
  : MatcherTestsBase
  where TSimple : class, IGqlpSimple
{
  [Theory, RepeatData]
  public void Simple_Matches_SameName_ReturnsTrue(string name)
  {
    TSimple type = NFor<TSimple>(name);
    TSimple constraint = NFor<TSimple>(name);

    SimpleSameMatcher<TSimple> matcher = new();

    bool result = matcher.Matches(type, name, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Simple_Matches_Parent_ReturnsTrue(string name, string parent)
  {
    TSimple type = NFor<TSimple>(name);
    type.Parent.Returns(parent);
    TSimple constraint = NFor<TSimple>(parent);

    SimpleSameMatcher<TSimple> matcher = new();

    bool result = matcher.Matches(type, parent, Context);

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
