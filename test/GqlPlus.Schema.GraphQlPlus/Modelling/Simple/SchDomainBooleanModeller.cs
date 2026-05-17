using System.Linq;

namespace GqlPlus.Schema.Modelling;

internal sealed class SchDomainBooleanModeller
  : ModellerBase<IAstDomain<IAstDomainTrueFalse>, ISch_Type>
{
  protected override ISch_Type ToModel(IAstDomain<IAstDomainTrueFalse> ast, IMap<GqlpTypeKind> typeKinds)
  {
    ICollection<ISch_DomainTrueFalse> items = [.. ast.Items.Select(MakeItem)];
    ICollection<ISch_DomainItemTrueFalse> allItems = [.. ast.Items.Select(item => MakeAllItem(ast.Name, item))];

    Sch_BaseDomain<Sch_DomainKind, ISch_DomainTrueFalse, ISch_DomainItemTrueFalse> domain = new() {
      As__BaseDomain = new Sch_BaseDomainObject<Sch_DomainKind, ISch_DomainTrueFalse, ISch_DomainItemTrueFalse>(
        SchModellerHelpers.Desc(ast.Description),
        SchModellerHelpers.MakeName(ast.Name),
        SchModellerHelpers.MakeAliases(ast.Aliases),
        SchModellerHelpers.MakeNamedParent(ast.Parent),
        items,
        allItems,
        Sch_DomainKind.Boolean),
    };

    return new Sch_Type {
      As_DomainKindBoolean = domain,
      As__Type = new Sch_TypeObject(),
    };
  }

  private static ISch_DomainTrueFalse MakeItem(IAstDomainTrueFalse ast)
  {
    Sch_DomainTrueFalse result = new();
    result.As__DomainTrueFalse = new Sch_DomainTrueFalseObject(
      SchModellerHelpers.Desc(ast.Description),
      ast.Excludes,
      ast.IsTrue);
    return result;
  }

  private static Sch_DomainItemTrueFalse MakeAllItem(string domainName, IAstDomainTrueFalse ast)
  {
    ISch_DomainTrueFalse item = MakeItem(ast);
    return new Sch_DomainItemTrueFalse {
      As_Parent = item,
      As__DomainItemTrueFalse = new Sch_DomainItemTrueFalseObject(SchModellerHelpers.MakeName(domainName)),
    };
  }
}
