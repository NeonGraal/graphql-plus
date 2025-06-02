using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

public class MatcherTestsBase
  : VerifierTestsBase
{
  protected Map<IGqlpDescribed> Types { get; } = [];
  protected Map<string> EnumValues { get; } = [];
  protected EnumContext Context { get; }

  public MatcherTestsBase()
    => Context = new(Types, Errors, EnumValues);

  protected static Matcher<T>.D MatcherFor<T>(out Matcher<T>.I matcher)
  {
    matcher = For<Matcher<T>.I>();

    Matcher<T>.D result = For<Matcher<T>.D>();
    result().Returns(matcher);

    return result;
  }
}
