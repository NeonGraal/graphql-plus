using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class DomainSpecialMatcher
  : MatcherBase<IGqlpDomain, IGqlpTypeSpecial>
{
  public override bool Matches(IGqlpDomain type, IGqlpTypeSpecial constraint, UsageContext context)
    => type.DomainKind switch {
      DomainKind.Boolean => constraint.Name.Equals("Boolean", StringComparison.Ordinal),
      DomainKind.Number => constraint.Name.Equals("Number", StringComparison.Ordinal),
      DomainKind.String => constraint.Name.Equals("String", StringComparison.Ordinal),
      _ => false,
    };
}
