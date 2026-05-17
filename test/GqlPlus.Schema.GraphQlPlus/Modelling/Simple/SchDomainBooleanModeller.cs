namespace GqlPlus.Schema.Modelling;

internal sealed class SchDomainBooleanModeller
  : SchDomainModellerBase<IAstDomainTrueFalse, ISch_DomainTrueFalse, ISch_DomainItemTrueFalse>
{
  protected override Sch_DomainKind DomainKind => Sch_DomainKind.Boolean;

  protected override ISch_Type WrapDomain(
    Sch_BaseDomain<Sch_DomainKind, ISch_DomainTrueFalse, ISch_DomainItemTrueFalse> domain)
    => new Sch_Type {
      As_DomainKindBoolean = domain,
      As__Type = new Sch_TypeObject(),
    };

  protected override ISch_DomainTrueFalse MakeItem(IAstDomainTrueFalse ast)
  {
    Sch_DomainTrueFalse result = new();
    result.As__DomainTrueFalse = new Sch_DomainTrueFalseObject(
      SchModellerHelpers.Desc(ast.Description),
      ast.Excludes,
      ast.IsTrue);
    return result;
  }

  protected override ISch_DomainItemTrueFalse MakeAllItem(string domainName, IAstDomainTrueFalse ast)
  {
    ISch_DomainTrueFalse item = MakeItem(ast);
    return new Sch_DomainItemTrueFalse {
      As_Parent = item,
      As__DomainItemTrueFalse = new Sch_DomainItemTrueFalseObject(SchModellerHelpers.MakeName(domainName)),
    };
  }
}
