using GqlPlus.Ast.Schema;

namespace GqlPlus.Generating.Simple;

internal abstract class GenerateBaseDomain<TItem>(
  DomainKind kind
) : GenerateForSimple<IAstDomain<TItem>>
  where TItem : IAstDomainItem
{
  internal override IEnumerable<MapPair<string>> TypeMembers(IAstDomain<TItem> ast, GqlpGeneratorTypes types)
    => [];

  protected override bool HasDefaultParent(out string? defaultParent)
  {
    defaultParent = $"GqlpDomain{kind}";

    return true;
  }
}
