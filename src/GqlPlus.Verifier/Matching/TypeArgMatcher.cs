using System.Diagnostics.CodeAnalysis;
using GqlPlus.Ast.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class TypeArgMatcher(
  IMatcherRepository matchers
) : MatchLogger(matchers)
  , Matcher<IAstTypeArg>.I
{
  private readonly Matcher<IAstType>.L _anyTypeMatcher = matchers.MatcherFor<IAstType>();

  public bool Matches(IAstTypeArg arg, string constraint, EnumContext context)
  {
    TryingMatch(arg, constraint);

    return MatchArgOrType<IAstType, EnumContext>(arg.FullType, constraint, context, ArgAction);

    bool ArgAction(IAstType t, string c, EnumContext ctx)
    {
      if (arg.EnumValue is not null
        && MatchArgLabel(arg, constraint, context)) {
        return true;
      }

      return _anyTypeMatcher.Matches(t, c, ctx);
    }
  }

  private bool MatchArgLabel(IAstTypeArg arg, string constraint, EnumContext context)
  {
    if (context.GetType(constraint, out IAstDescribed? constraintType) && arg.EnumValue is not null) {
      if (constraintType is IAstEnum enumType) {
        if (EnumHasLabel(context, enumType, arg.EnumValue.EnumLabel)) {
          return true;
        }
      } else if (constraintType is IAstDomain<IAstDomainLabel> domType) {
        IAstDomainLabel? domLabel = DomainHasLabel(context, domType, arg.EnumValue.EnumLabel);
        return domLabel?.Excludes == false;
      }
    }

    return false;
  }

  private IAstDomainLabel? DomainHasLabel(UsageContext context, IAstDomain<IAstDomainLabel> domType, string label)
  {
    foreach (IAstDomainLabel item in domType.Items.Where(i => i.EnumItem == label || i.EnumItem == GqlpDomainLabelConstants.All)) {
      if (context.GetTyped(item.EnumType, out IAstEnum? enumType)) {
        if (EnumHasLabel(context, enumType, label)) {
          return item;
        }
      }
    }

    if (context.GetTyped(domType.Parent?.Name, out IAstDomain<IAstDomainLabel>? parentType)) {
      return DomainHasLabel(context, parentType, label);
    }

    return null;
  }

  [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Todo")]
  internal bool EnumHasLabel(UsageContext context, IAstEnum enumType, string label)
  {
    if (enumType.HasValue(label)) {
      return true;
    }

    if (context.GetTyped(enumType.Parent?.Name, out IAstEnum? parentType)) {
      return EnumHasLabel(context, parentType, label);
    }

    return false;
  }

  internal static TypeArgMatcher Factory(IMatcherRepository m) => new(m);
}
