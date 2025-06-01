using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class OutputArgMatcher(
  Matcher<IGqlpType>.D anyTypeMatcher
) : ObjArgMatcher<IGqlpOutputArg>(anyTypeMatcher)
{
  public override bool Matches(IGqlpOutputArg arg, string constraint, UsageContext context)
  {
    if (string.IsNullOrWhiteSpace(arg.EnumLabel)) {
      if (arg.EnumType.IsTypeParam) {
        if (context.GetTyped(arg.FullType, out IGqlpTypeParam? typeParam)) {
          // Todo: Check if the type param is a constraint of the param
          if (!string.IsNullOrWhiteSpace(typeParam.Constraint)
              && typeParam.Constraint!.Equals(constraint, StringComparison.Ordinal)) {
            return true;
          }
        }
      }

      if (context.GetType(constraint, out IGqlpDescribed? constraintType)) {
        if (constraintType is IGqlpEnum enumType) {
          if (EnumHasLabel(context, enumType, arg.EnumType.Name)) {
            arg.SetEnumType(enumType.Name);
          }
        } else if (constraintType is IGqlpDomain<IGqlpDomainLabel> domType) {
          IGqlpEnum? domEnum = DomainHasLabel(context, domType, arg.EnumType.Name);
          if (domEnum is null) {
            return false;
          } else {
            arg.SetEnumType(domEnum.Name);
          }
        }
      }
    }

    return base.Matches(arg, constraint, context);
  }

  private IGqlpEnum? DomainHasLabel(UsageContext context, IGqlpDomain<IGqlpDomainLabel> domType, string label)
  {
    foreach (IGqlpDomainLabel item in domType.Items.Where(i => !i.Excludes && (i.EnumItem == label || i.EnumItem == "*"))) {
      if (context.GetTyped(item.EnumType, out IGqlpEnum? enumType)) {
        if (EnumHasLabel(context, enumType, label)) {
          return enumType;
        }
      }
    }

    // Todo: Handle domain parents

    return null;
  }

  [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Todo")]
  internal bool EnumHasLabel(UsageContext context, IGqlpEnum enumType, string label)
  {
    if (enumType.HasValue(label)) {
      return true;
    }

    if (context.GetTyped(enumType.Parent, out IGqlpEnum? parentType)) {
      return EnumHasLabel(context, parentType, label);
    }

    return false;
  }
}
