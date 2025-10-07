using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class SimpleParentMatcher<TType>(
  ILoggerFactory logger
) : MatchParentBase<IGqlpTypeRef, TType>(logger)
  where TType : IGqlpSimple
{
  protected override bool MatchParent(IGqlpTypeRef parent, string constraint, UsageContext context)
    => !string.IsNullOrWhiteSpace(parent.Name)
      && (parent.Name.Equals(constraint, StringComparison.Ordinal)
        || MatchParentType(parent.Name, constraint, context));

  private bool MatchParentType(string name, string constraint, UsageContext context)
    => context.GetTyped(name, out TType? typeParent)
      && typeParent.Parent is not null
      && MatchParent(typeParent.Parent, constraint, context);
}
