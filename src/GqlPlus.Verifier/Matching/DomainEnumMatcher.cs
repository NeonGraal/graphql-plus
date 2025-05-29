using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class DomainEnumMatcher(
  IMatch<IGqlpEnum, IGqlpEnum> enumMatcher
) : MatcherBase<IGqlpDomain, IGqlpEnum>
{
  public override bool Matches(IGqlpDomain type, IGqlpEnum constraint, UsageContext context)
    => type.DomainKind == DomainKind.Enum
    && type is IGqlpDomain<IGqlpDomainLabel> domain
    && domain.Items.Any(i => MatchDomainLabel(i, constraint, context));

  private bool MatchDomainLabel(IGqlpDomainLabel i, IGqlpEnum constraint, UsageContext context)
    => string.IsNullOrWhiteSpace(i.EnumType)
    ? MatchEnumLabel(i.EnumItem, constraint, context)
    : MatchEnumType(i.EnumType, constraint, context);

  private bool MatchEnumType(string enumName, IGqlpEnum constraint, UsageContext context)
    => enumName.Equals(constraint.Name, StringComparison.Ordinal)
      || context.GetTyped(enumName, out IGqlpEnum? enumType)
        && enumMatcher.Matches(enumType, constraint, context);

  private bool MatchEnumLabel(string enumItem, IGqlpEnum constraint, UsageContext context)
    => context is EnumContext enumContext
      && enumContext.GetEnumValue(enumItem, out string? enumType)
      && MatchEnumType(enumType, constraint, context);
}
