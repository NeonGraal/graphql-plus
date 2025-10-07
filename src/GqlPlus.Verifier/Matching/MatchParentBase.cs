using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal abstract class MatchParentBase<TParent, TType>(
  ILoggerFactory logger
) : MatchTypeBase<TType>(logger)
  where TParent : IGqlpNamed
  where TType : IGqlpType<TParent>
{
  public override bool Matches(TType type, string constraint, EnumContext context)
  {
    TryingMatch(type, constraint);

    return type.Name.Equals(constraint, StringComparison.Ordinal)
      || type.Parent is not null && MatchParent(type.Parent, constraint, context);
  }

  protected abstract bool MatchParent(TParent parent, string constraint, UsageContext context);
}
