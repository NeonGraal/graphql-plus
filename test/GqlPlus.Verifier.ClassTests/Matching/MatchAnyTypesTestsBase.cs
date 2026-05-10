namespace GqlPlus.Matching;

public class MatchAnyTypesTestsBase
  : MatchTestsBase
{
  protected MatcherOne<IAstType>.D AnyTypeMatcher { get; }

  private readonly IMatcher<IAstType> _anyTypeMatcher;

  protected MatchAnyTypesTestsBase()
  {
    AnyTypeMatcher = MatcherFor(out _anyTypeMatcher);
    MatcherForReturns(AnyTypeMatcher);
  }

  protected void AnyTypeMatches(bool result)
    => _anyTypeMatcher.Matches(default!, "", default!)
      .ReturnsForAnyArgs(result);
}
