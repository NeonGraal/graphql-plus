namespace GqlPlus.Schema.Modelling;

internal abstract class SchDomainModellerBase<TAstItem, TSchItem, TSchAllItem>
  : ModellerBase<IAstDomain<TAstItem>, ISch_Type>
  where TAstItem : class, IAstDomainItem
  where TSchItem : class
  where TSchAllItem : class
{
  protected abstract Sch_DomainKind DomainKind { get; }
  protected abstract TSchItem MakeItem(TAstItem ast);
  protected abstract TSchAllItem MakeAllItem(string domainName, TAstItem ast);
  protected abstract ISch_Type WrapDomain(Sch_BaseDomain<Sch_DomainKind, TSchItem, TSchAllItem> domain);

  protected override ISch_Type ToModel(IAstDomain<TAstItem> ast, IMap<GqlpTypeKind> typeKinds)
  {
    ICollection<TSchItem> items = [.. ast.Items.Select(MakeItem)];
    ICollection<TSchAllItem> allItems = [.. ast.Items.Select(item => MakeAllItem(ast.Name, item))];

    Sch_BaseDomain<Sch_DomainKind, TSchItem, TSchAllItem> domain = new() {
      As__BaseDomain = new Sch_BaseDomainObject<Sch_DomainKind, TSchItem, TSchAllItem>(
        SchModellerHelpers.Desc(ast.Description),
        SchModellerHelpers.MakeName(ast.Name),
        SchModellerHelpers.MakeAliases(ast.Aliases),
        SchModellerHelpers.MakeNamedParent(ast.Parent),
        items,
        allItems,
        DomainKind),
    };

    return WrapDomain(domain);
  }
}
