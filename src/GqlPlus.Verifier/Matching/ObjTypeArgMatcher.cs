using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class ObjTypeArgMatcher(
  ILoggerFactory logger,
  Matcher<IGqlpType>.D anyTypeMatcher
) : MatchLogger(logger)
  , Matcher<IGqlpObjTypeArg>.I
{
  private readonly Matcher<IGqlpType>.L _anyTypeMatcher = anyTypeMatcher;

  public bool Matches(IGqlpObjTypeArg arg, string constraint, EnumContext context)
  {
    TryingMatch(arg, constraint);

    return MatchArgOrType<IGqlpType, EnumContext>(arg.FullType, constraint, context, ArgAction);

    bool ArgAction(IGqlpType t, string c, EnumContext ctx)
    {
      if (arg.EnumValue is not null
        && MatchArgLabel(arg, constraint, context)) {
        return true;
      }

      return _anyTypeMatcher.Matches(t, c, ctx);
    }
  }

  private bool MatchArgLabel(IGqlpObjTypeArg arg, string constraint, EnumContext context)
  {
    if (context.GetType(constraint, out IGqlpDescribed? constraintType) && arg.EnumValue is not null) {
      if (constraintType is IGqlpEnum enumType) {
        if (EnumHasLabel(context, enumType, arg.EnumValue.EnumLabel)) {
          return true;
        }
      } else if (constraintType is IGqlpDomain<IGqlpDomainLabel> domType) {
        IGqlpDomainLabel? domLabel = DomainHasLabel(context, domType, arg.EnumValue.EnumLabel);
        return domLabel?.Excludes == false;
      }
    }

    return false;
  }

  private IGqlpDomainLabel? DomainHasLabel(UsageContext context, IGqlpDomain<IGqlpDomainLabel> domType, string label)
  {
    foreach (IGqlpDomainLabel item in domType.Items.Where(i => i.EnumItem == label || i.EnumItem == "*")) {
      if (context.GetTyped(item.EnumType, out IGqlpEnum? enumType)) {
        if (EnumHasLabel(context, enumType, label)) {
          return item;
        }
      }
    }

    if (context.GetTyped(domType.Parent?.Name, out IGqlpDomain<IGqlpDomainLabel>? parentType)) {
      return DomainHasLabel(context, parentType, label);
    }

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
