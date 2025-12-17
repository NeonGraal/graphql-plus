namespace GqlPlus.Generating.Simple;

internal abstract class GenerateBaseDomain<TItem>(
  DomainKind kind
) : GenerateForSimple<IGqlpDomain<TItem>>
  where TItem : IGqlpDomainItem
{
  internal override IEnumerable<MapPair<string>> TypeMembers(IGqlpDomain<TItem> ast, GqlpGeneratorContext context)
    => [];
  protected override bool HasDefaultParent(out string? defaultParent)
  {
    defaultParent = $"Domain{kind}";

    return true;
  }
}
