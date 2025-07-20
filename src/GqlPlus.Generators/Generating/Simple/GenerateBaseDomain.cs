namespace GqlPlus.Generating.Simple;

internal abstract class GenerateBaseDomain<TItem>
  : GenerateForSimple<IGqlpDomain<TItem>>
  where TItem : IGqlpDomainItem
{
  public override string TypePrefix => "Domain";

  internal override IEnumerable<MapPair<string>> TypeMembers(IGqlpDomain<TItem> ast, GqlpGeneratorContext context)
    => [];
}
