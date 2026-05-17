using System.Linq;

namespace GqlPlus.Schema.Modelling;

internal sealed class SchDomainNumberModeller
  : ModellerBase<IAstDomain<IAstDomainRange>, ISch_Type>
{
  protected override ISch_Type ToModel(IAstDomain<IAstDomainRange> ast, IMap<GqlpTypeKind> typeKinds)
  {
    ICollection<ISch_DomainRange> items = [.. ast.Items.Select(MakeItem)];
    ICollection<ISch_DomainItemRange> allItems = [.. ast.Items.Select(item => MakeAllItem(ast.Name, item))];

    Sch_BaseDomain<Sch_DomainKind, ISch_DomainRange, ISch_DomainItemRange> domain = new() {
      As__BaseDomain = new Sch_BaseDomainObject<Sch_DomainKind, ISch_DomainRange, ISch_DomainItemRange>(
        SchModellerHelpers.Desc(ast.Description),
        SchModellerHelpers.MakeName(ast.Name),
        SchModellerHelpers.MakeAliases(ast.Aliases),
        SchModellerHelpers.MakeNamedParent(ast.Parent),
        items,
        allItems,
        Sch_DomainKind.Number),
    };

    return new Sch_Type {
      As_DomainKindNumber = domain,
      As__Type = new Sch_TypeObject(),
    };
  }

  private static ISch_DomainRange MakeItem(IAstDomainRange ast)
  {
    Sch_DomainRangeObject domainObject = new(
      SchModellerHelpers.Desc(ast.Description),
      ast.Excludes) {
      Lower = ast.Lower,
      Upper = ast.Upper,
    };

    Sch_DomainRange result = new();
    result.As__DomainRange = domainObject;
    return result;
  }

  private static Sch_DomainItemRange MakeAllItem(string domainName, IAstDomainRange ast)
  {
    ISch_DomainRange item = MakeItem(ast);
    return new Sch_DomainItemRange {
      As_Parent = item,
      As__DomainItemRange = new Sch_DomainItemRangeObject(SchModellerHelpers.MakeName(domainName)),
    };
  }
}
