using GqlPlus.Ast.Schema;

namespace GqlPlus.Matching;

public class MatchAnyTypesTestsBase
  : MatchTestsBase
{
  protected Matcher<IAstType>.D AnyTypeMatcher { get; }

  private readonly Matcher<IAstType>.I _anyTypeMatcher;

  protected MatchAnyTypesTestsBase()
  {
    AnyTypeMatcher = MatcherFor(out _anyTypeMatcher);
    MatcherRepo.MatcherFor<IAstType>().Returns(AnyTypeMatcher);
  }

  protected void AnyTypeMatches(bool result)
    => _anyTypeMatcher.Matches(default!, "", default!)
      .ReturnsForAnyArgs(result);
}
