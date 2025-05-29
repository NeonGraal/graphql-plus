using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

public class MatcherTestsBase
  : SubstituteBase
{
  protected IGqlpType Type { get; } = For<IGqlpType>();
  protected IGqlpType Constraint { get; } = For<IGqlpType>();
  protected Map<IGqlpDescribed> Types { get; } = [];

  protected TokenMessages Errors { get; } = [];
  protected UsageContext Context { get; }

  public MatcherTestsBase()
    => Context = new(Types, Errors);
}
