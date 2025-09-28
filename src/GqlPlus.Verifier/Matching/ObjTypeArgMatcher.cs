using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class ObjTypeArgMatcher(
  ILoggerFactory logger,
  Matcher<IGqlpType>.D anyTypeMatcher
) : MatcherBase<IGqlpObjTypeArg>(logger)
{
  private readonly Matcher<IGqlpType>.L _anyTypeMatcher = anyTypeMatcher;

  public override bool Matches(IGqlpObjTypeArg arg, string constraint, EnumContext context)
  {
    TryingMatch(arg, constraint);

    if (arg.FullType.Equals(constraint, StringComparison.Ordinal)) {
      return true;
    }

    if (context.GetTyped(arg.FullType, out IGqlpTypeParam? typeParam)) {
      return typeParam.Constraint.Equals(constraint, StringComparison.Ordinal);
    }

    if (!context.GetTyped(arg.FullType, out IGqlpType? argType)) {
      return false;
    }

    if (argType.Name.Equals(constraint, StringComparison.Ordinal)) {
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

    return _anyTypeMatcher.Matches(argType, constraint, context);
  }

  private static bool MatchArgTypeParam(IGqlpObjTypeArg arg, string constraint, EnumContext context)
  {
    if (context.GetTyped(arg.FullType, out IGqlpTypeParam? typeParam)) {
      // Todo: Check if the type param is a constraint of the param
      if (typeParam.Constraint.Equals(constraint, StringComparison.Ordinal)) {
        return true;
      }
    }

    return false;
  }

  private bool MatchConstraintType(IGqlpObjTypeArg arg, EnumContext context, IGqlpDescribed constraintType)
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

  private bool MatchArgLabel(IGqlpObjTypeArg arg, string constraint, EnumContext context)
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
