namespace GqlPlus.Generating.Simple;

internal abstract class GenerateBaseDomain<TItem>(
  DomainKind kind
) : GenerateForSimple<Abstractions.Schema.IGqlpDomain<TItem>>
  where TItem : IGqlpDomainItem
{
  internal override IEnumerable<MapPair<string>> TypeMembers(Abstractions.Schema.IGqlpDomain<TItem> ast, GqlpGeneratorContext context)
    => [];
  protected override bool HasDefaultParent(out string? defaultParent)
  {
    defaultParent = $"GqlpDomain{kind}";

    return true;
  }
}
