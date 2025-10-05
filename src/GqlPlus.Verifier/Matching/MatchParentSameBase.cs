using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal abstract class MatchParentSameBase<TParent, TType>(
  ILoggerFactory logger
) : MatchTypeBase<TType>(logger)
  where TParent : IGqlpNamed
  where TType : IGqlpType<TParent>
{
  public override bool Matches(TType type, string constraint, EnumContext context)
  {
    TryingMatch(type, constraint);

    return type.Name.Equals(constraint, StringComparison.Ordinal)
      || MatchParent(type.Parent, constraint, context);
  }

  protected static bool MatchName(string? parent, string constraint)
    => !string.IsNullOrWhiteSpace(parent)
      && parent!.Equals(constraint, StringComparison.Ordinal);

  protected virtual bool MatchParent(TParent? parent, string constraint, UsageContext context)
    => MatchName(parent?.Name, constraint)
      || context.GetTyped(parent?.Name, out TType? typeParent)
        && MatchParent(typeParent.Parent, constraint, context);
}
