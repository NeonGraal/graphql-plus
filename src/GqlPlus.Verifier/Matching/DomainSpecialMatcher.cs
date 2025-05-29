using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class DomainSpecialMatcher
  : MatcherBase<IGqlpDomain>
{
  public override bool Matches(IGqlpDomain type, string constraint, UsageContext context)
    => type.DomainKind switch {
      DomainKind.Boolean => constraint.Equals("Boolean", StringComparison.Ordinal),
      DomainKind.Number => constraint.Equals("Number", StringComparison.Ordinal),
      DomainKind.String => constraint.Equals("String", StringComparison.Ordinal),
      _ => false,
    };
}
