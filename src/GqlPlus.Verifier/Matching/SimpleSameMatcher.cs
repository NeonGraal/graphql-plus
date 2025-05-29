using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class SimpleSameMatcher<TType>
  : MatcherBase<TType>
  where TType : IGqlpSimple
{
  public override bool Matches(TType type, string constraint, UsageContext context)
    => type.Name.Equals(constraint, StringComparison.Ordinal)
     || MatchParent(type.Parent, constraint, context);

  private static bool MatchParent(string? parent, string constraint, UsageContext context)
    => !string.IsNullOrWhiteSpace(parent)
      && (parent!.Equals(constraint, StringComparison.Ordinal)
        || context.GetTyped(parent, out TType? typeParent)
          && MatchParent(typeParent.Parent, constraint, context));
}
