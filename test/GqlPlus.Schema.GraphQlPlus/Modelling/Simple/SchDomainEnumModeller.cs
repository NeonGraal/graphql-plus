namespace GqlPlus.Schema.Modelling;

internal sealed class SchDomainEnumModeller
  : SchDomainModellerBase<IAstDomainLabel, ISch_DomainLabel, ISch_DomainItemLabel>
{
  internal static IModeller<IAstDomain<IAstDomainLabel>, ISch_Type> Factory(ISchModellerRepository _)
    => new SchDomainEnumModeller();
  protected override Sch_DomainKind DomainKind => Sch_DomainKind.Enum;

  protected override ISch_Type WrapDomain(
    Sch_BaseDomain<Sch_DomainKind, ISch_DomainLabel, ISch_DomainItemLabel> domain)
    => new Sch_Type {
      As_DomainKindEnum = domain,
      As__Type = new Sch_TypeObject(),
    };

  protected override ISch_DomainLabel MakeItem(IAstDomainLabel ast)
  {
    Sch_DomainLabel result = new();
    result.As__DomainLabel = new Sch_DomainLabelObject(
      SchModellerHelpers.Desc(ast.Description),
      ast.Excludes,
      MakeEnumValue(ast));
    return result;
  }

  protected override ISch_DomainItemLabel MakeAllItem(string domainName, IAstDomainLabel ast)
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
