namespace GqlPlus.Schema.Modelling;

internal sealed class SchDomainNumberModeller
  : SchDomainModellerBase<IAstDomainRange, ISch_DomainRange, ISch_DomainItemRange>
{
  protected override Sch_DomainKind DomainKind => Sch_DomainKind.Number;

  protected override ISch_Type WrapDomain(
    Sch_BaseDomain<Sch_DomainKind, ISch_DomainRange, ISch_DomainItemRange> domain)
    => new Sch_Type {
      As_DomainKindNumber = domain,
      As__Type = new Sch_TypeObject(),
    };

  protected override ISch_DomainRange MakeItem(IAstDomainRange ast)
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

  protected override ISch_DomainItemRange MakeAllItem(string domainName, IAstDomainRange ast)
  {
    ISch_DomainRange item = MakeItem(ast);
    return new Sch_DomainItemRange {
      As_Parent = item,
      As__DomainItemRange = new Sch_DomainItemRangeObject(SchModellerHelpers.MakeName(domainName)),
    };
  }
}
