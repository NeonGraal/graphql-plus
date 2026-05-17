using System.Linq;

namespace GqlPlus.Schema.Modelling;

internal sealed class SchDomainEnumModeller
  : ModellerBase<IAstDomain<IAstDomainLabel>, ISch_Type>
{
  protected override ISch_Type ToModel(IAstDomain<IAstDomainLabel> ast, IMap<GqlpTypeKind> typeKinds)
  {
    ICollection<ISch_DomainLabel> items = [.. ast.Items.Select(MakeItem)];
    ICollection<ISch_DomainItemLabel> allItems = [.. ast.Items.Select(item => MakeAllItem(ast.Name, item))];

    Sch_BaseDomain<Sch_DomainKind, ISch_DomainLabel, ISch_DomainItemLabel> domain = new() {
      As__BaseDomain = new Sch_BaseDomainObject<Sch_DomainKind, ISch_DomainLabel, ISch_DomainItemLabel>(
        SchModellerHelpers.Desc(ast.Description),
        SchModellerHelpers.MakeName(ast.Name),
        SchModellerHelpers.MakeAliases(ast.Aliases),
        SchModellerHelpers.MakeNamedParent(ast.Parent),
        items,
        allItems,
        Sch_DomainKind.Enum),
    };

    return new Sch_Type {
      As_DomainKindEnum = domain,
      As__Type = new Sch_TypeObject(),
    };
  }

  private static ISch_DomainLabel MakeItem(IAstDomainLabel ast)
  {
    Sch_DomainLabel result = new();
    result.As__DomainLabel = new Sch_DomainLabelObject(
      SchModellerHelpers.Desc(ast.Description),
      ast.Excludes,
      MakeEnumValue(ast));
    return result;
  }

  private static Sch_DomainItemLabel MakeAllItem(string domainName, IAstDomainLabel ast)
  {
    ISch_DomainLabel item = MakeItem(ast);
    return new Sch_DomainItemLabel {
      As_Parent = item,
      As__DomainItemLabel = new Sch_DomainItemLabelObject(SchModellerHelpers.MakeName(domainName)),
    };
  }

  private static Sch_EnumValue MakeEnumValue(IAstDomainLabel ast)
  {
    Sch_EnumValue result = new();
    result.As__EnumValue = new Sch_EnumValueObject([], SchModellerHelpers.MakeName(ast.EnumType), SchModellerHelpers.MakeName(ast.EnumItem));
    return result;
  }
}
