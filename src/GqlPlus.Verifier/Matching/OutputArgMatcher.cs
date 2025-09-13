using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class OutputArgMatcher(
  ILoggerFactory logger,
  Matcher<IGqlpType>.D anyTypeMatcher
) : ObjArgMatcher<IGqlpObjArg>(logger, anyTypeMatcher)
{
  public override bool Matches(IGqlpObjArg arg, string constraint, EnumContext context)
  {
    if (base.Matches(arg, constraint, context)) {
      return true;
    }

    if (string.IsNullOrWhiteSpace(arg.EnumLabel)) {
      if (arg.EnumType.IsTypeParam
          && MatchArgTypeParam(arg, constraint, context)) {
        return true;
      }

      if (context.GetType(constraint, out IGqlpDescribed? constraintType)
          && !MatchConstraintType(arg, context, constraintType)) {
        return false;
      }
    } else if (MatchArgLabel(arg, constraint, context)) {
      return true;
    }

    return false;
  }

  private static bool MatchArgTypeParam(IGqlpObjArg arg, string constraint, EnumContext context)
  {
    if (context.GetTyped(arg.FullType, out IGqlpTypeParam? typeParam)) {
      // Todo: Check if the type param is a constraint of the param
      if (typeParam.Constraint.Equals(constraint, StringComparison.Ordinal)) {
        return true;
      }
    }

    return false;
  }

  private bool MatchConstraintType(IGqlpObjArg arg, EnumContext context, IGqlpDescribed constraintType)
  {
    if (constraintType is IGqlpEnum enumType) {
      if (!EnumHasLabel(context, enumType, arg.EnumType.Name)) {
        return false;
      }
    } else if (constraintType is IGqlpDomain<IGqlpDomainLabel> domType) {
      IGqlpEnum? domEnum = DomainHasLabel(context, domType, arg.EnumType.Name);
      if (domEnum is null) {
        return false;
      }
    }

    return true;
  }

  private bool MatchArgLabel(IGqlpObjArg arg, string constraint, EnumContext context)
  {
    if (context.GetType(constraint, out IGqlpDescribed? constraintType)) {
      if (constraintType is IGqlpEnum enumType) {
        if (EnumHasLabel(context, enumType, arg.EnumLabel!)) {
          return true;
        }
      } else if (constraintType is IGqlpDomain<IGqlpDomainLabel> domType) {
        IGqlpEnum? domEnum = DomainHasLabel(context, domType, arg.EnumLabel!);
        if (domEnum is not null) {
          return true;
        }
      }
    }

    return false;
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

    if (context.GetTyped(enumType.Parent?.Name, out IGqlpEnum? parentType)) {
      return EnumHasLabel(context, parentType, label);
    }

    return false;
  }
}
