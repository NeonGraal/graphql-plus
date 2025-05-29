using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class SimpleSameMatcher<TType>
  : MatcherBase<TType, TType>
  where TType : IGqlpSimple
{
  public override bool Matches(TType type, TType constraint, UsageContext context)
    => type.Name.Equals(constraint.Name, StringComparison.Ordinal)
     || !string.IsNullOrWhiteSpace(type.Parent)
            && (type.Parent!.Equals(constraint.Name, StringComparison.Ordinal)
              || context.GetTyped(type.Parent, out TType? typeParent)
                && Matches(typeParent, constraint, context));
}
