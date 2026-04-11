using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class DomainMatcher(
  IMatcherRepository matchers
) : MatchTypeBase<IAstDomain>(matchers)
  , Matcher<IAstDomain>.I
  , ITypeMatcher
{
  private readonly Matcher<IAstEnum>.L _enumMatcher = matchers.MatcherFor<IAstEnum>();

  public override bool Matches(IAstDomain type, string constraint, EnumContext context)
  {
    TryingMatch(type, constraint);

    return type.DomainKind switch {
      DomainKind.Boolean => constraint.Equals(BuiltIn.BooleanType, StringComparison.Ordinal),
      DomainKind.Enum => MatchDomainLabels(type, constraint, context),
      DomainKind.Number => constraint.Equals(BuiltIn.NumberType, StringComparison.Ordinal),
      DomainKind.String => constraint.Equals(BuiltIn.StringType, StringComparison.Ordinal),
      _ => false,
    };
  }

  private bool MatchDomainLabels(IAstDomain type, string constraint, EnumContext context)
    => context.GetTyped(type.Parent?.Name, out IAstDomain? parentType)
        && parentType.DomainKind == DomainKind.Enum
        && MatchDomainLabels(parentType, constraint, context)
      || type is IAstDomain<IAstDomainLabel> domain
        && domain.Items.Any(i => MatchDomainLabel(i, constraint, context));

  private bool MatchDomainLabel(IAstDomainLabel i, string constraint, EnumContext context)
    => string.IsNullOrWhiteSpace(i.EnumType)
      ? MatchEnumLabel(i.EnumItem, constraint, context)
      : MatchEnumType(i.EnumType, constraint, context);

  private bool MatchEnumType(string enumName, string constraint, EnumContext context)
    => enumName.Equals(constraint, StringComparison.Ordinal)
      || context.GetTyped(enumName, out IAstEnum? enumType)
        && _enumMatcher.Matches(enumType, constraint, context);

  private bool MatchEnumLabel(string enumItem, string constraint, EnumContext context)
    => context.GetEnumValue(enumItem, out string? enumType)
      && MatchEnumType(enumType, constraint, context);
}
