using System.Linq;

namespace GqlPlus.Schema.Modelling;

internal sealed class SchDomainStringModeller
  : ModellerBase<IAstDomain<IAstDomainRegex>, ISch_Type>
{
  protected override ISch_Type ToModel(IAstDomain<IAstDomainRegex> ast, IMap<GqlpTypeKind> typeKinds)
  {
    ICollection<ISch_DomainRegex> items = [.. ast.Items.Select(MakeItem)];
    ICollection<ISch_DomainItemRegex> allItems = [.. ast.Items.Select(item => MakeAllItem(ast.Name, item))];

    Sch_BaseDomain<Sch_DomainKind, ISch_DomainRegex, ISch_DomainItemRegex> domain = new() {
      As__BaseDomain = new Sch_BaseDomainObject<Sch_DomainKind, ISch_DomainRegex, ISch_DomainItemRegex>(
        SchModellerHelpers.Desc(ast.Description),
        SchModellerHelpers.MakeName(ast.Name),
        SchModellerHelpers.MakeAliases(ast.Aliases),
        SchModellerHelpers.MakeNamedParent(ast.Parent),
        items,
        allItems,
        Sch_DomainKind.String),
    };

    return new Sch_Type {
      As_DomainKindString = domain,
      As__Type = new Sch_TypeObject(),
    };
  }

  private static ISch_DomainRegex MakeItem(IAstDomainRegex ast)
  {
    Sch_DomainRegex result = new();
    result.As__DomainRegex = new Sch_DomainRegexObject(
      SchModellerHelpers.Desc(ast.Description),
      ast.Excludes,
      ast.Pattern);
    return result;
  }

  private static Sch_DomainItemRegex MakeAllItem(string domainName, IAstDomainRegex ast)
  {
    ISch_DomainRegex item = MakeItem(ast);
    return new Sch_DomainItemRegex {
      As_Parent = item,
      As__DomainItemRegex = new Sch_DomainItemRegexObject(SchModellerHelpers.MakeName(domainName)),
    };
  }
}
