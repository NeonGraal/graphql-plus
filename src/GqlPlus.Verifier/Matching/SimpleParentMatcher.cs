using GqlPlus.Ast.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class SimpleParentMatcher<TType>(
  IMatcherRepository matchers
) : MatchParentBase<IAstTypeRef, TType>(matchers)
  where TType : IAstSimple
{
  protected override bool MatchParent(IAstTypeRef parent, string constraint, UsageContext context)
    => !string.IsNullOrWhiteSpace(parent.Name)
      && (parent.Name.Equals(constraint, StringComparison.Ordinal)
        || MatchParentType(parent.Name, constraint, context));

  private bool MatchParentType(string name, string constraint, UsageContext context)
    => context.GetTyped(name, out TType? typeParent)
      && typeParent.Parent is not null
      && MatchParent(typeParent.Parent, constraint, context);

  internal static SimpleParentMatcher<TType> Factory(IMatcherRepository m) => new(m);
}
