namespace GqlPlus.Generating.Simple;

internal abstract class GenerateBaseDomain<TItem>
  : GenerateForSimple<IGqlpDomain<TItem>>
  where TItem : IGqlpDomainItem
{
  internal override IEnumerable<MapPair<string>> TypeMembers(IGqlpDomain<TItem> ast, GqlpGeneratorContext context)
    => [];
}
