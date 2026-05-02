namespace GqlPlus.Matching;

public class MatchAnyTypesTestsBase
  : MatchTestsBase
{
  protected Matcher<IAstType>.D AnyTypeMatcher { get; }

  private readonly Matcher<IAstType>.I _anyTypeMatcher;

  protected MatchAnyTypesTestsBase()
  {
    AnyTypeMatcher = MatcherFor(out _anyTypeMatcher);
    MatcherForReturns(AnyTypeMatcher);
  }

  protected void AnyTypeMatches(bool result)
    => _anyTypeMatcher.Matches(default!, "", default!)
      .ReturnsForAnyArgs(result);
}
