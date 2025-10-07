namespace GqlPlus.Matching;

public class MatchAnyTypesTestsBase
  : MatchTestsBase
{
  protected Matcher<IGqlpType>.D AnyTypeMatcher { get; }

  private readonly Matcher<IGqlpType>.I _anyTypeMatcher;

  protected MatchAnyTypesTestsBase()
    => AnyTypeMatcher = MatcherFor(out _anyTypeMatcher);

  protected void AnyTypeMatches(bool result)
    => _anyTypeMatcher.Matches(default!, "", default!)
      .ReturnsForAnyArgs(result);
}
