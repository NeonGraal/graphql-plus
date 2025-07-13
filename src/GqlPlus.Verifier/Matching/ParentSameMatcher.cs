using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class ParentSameMatcher<TParent, TType>(
  ILoggerFactory logger
) : TypeMatcherBase<TType>(logger)
  where TParent : IGqlpNamed
  where TType : IGqlpType<TParent>
{
  public override bool Matches(TType type, string constraint, EnumContext context)
  {
    TryingMatch(type, constraint);

    return type.Name.Equals(constraint, StringComparison.Ordinal)
      || MatchParent(type.Parent?.Name, constraint, context);
  }

  protected static bool MatchName(string? parent, string constraint)
    => !string.IsNullOrWhiteSpace(parent)
      && parent!.Equals(constraint, StringComparison.Ordinal);

  protected virtual bool MatchParent(string? parent, string constraint, UsageContext context)
    => MatchName(parent, constraint)
      || context.GetTyped(parent, out TType? typeParent)
        && MatchParent(typeParent.Parent?.Name, constraint, context);
}
