using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class DomainMatcher(
  Matcher<IGqlpEnum>.D enumMatcher
) : MatcherBase<IGqlpDomain>
{
  private readonly Matcher<IGqlpEnum>.L _enumMatcher = enumMatcher;

  public override bool Matches(IGqlpDomain type, string constraint, UsageContext context)
    => type.DomainKind switch {
      DomainKind.Boolean => constraint.Equals("Boolean", StringComparison.Ordinal),
      DomainKind.Enum => type is IGqlpDomain<IGqlpDomainLabel> domain
        && domain.Items.Any(i => MatchDomainLabel(i, constraint, context)),
      DomainKind.Number => constraint.Equals("Number", StringComparison.Ordinal),
      DomainKind.String => constraint.Equals("String", StringComparison.Ordinal),
      _ => false,
    };

  private bool MatchDomainLabel(IGqlpDomainLabel i, string constraint, UsageContext context)
    => string.IsNullOrWhiteSpace(i.EnumType)
    ? MatchEnumLabel(i.EnumItem, constraint, context)
    : MatchEnumType(i.EnumType, constraint, context);

  private bool MatchEnumType(string enumName, string constraint, UsageContext context)
    => enumName.Equals(constraint, StringComparison.Ordinal)
      || context.GetTyped(enumName, out IGqlpEnum? enumType)
        && _enumMatcher.Matches(enumType, constraint, context);

  private bool MatchEnumLabel(string enumItem, string constraint, UsageContext context)
    => context is EnumContext enumContext
      && enumContext.GetEnumValue(enumItem, out string? enumType)
      && MatchEnumType(enumType, constraint, context);
}
