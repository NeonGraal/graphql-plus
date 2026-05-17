namespace GqlPlus.Schema.Modelling;

internal sealed class SchDomainStringModeller
  : SchDomainModellerBase<IAstDomainRegex, ISch_DomainRegex, ISch_DomainItemRegex>
{
  protected override Sch_DomainKind DomainKind => Sch_DomainKind.String;

  protected override ISch_Type WrapDomain(
    Sch_BaseDomain<Sch_DomainKind, ISch_DomainRegex, ISch_DomainItemRegex> domain)
    => new Sch_Type {
      As_DomainKindString = domain,
      As__Type = new Sch_TypeObject(),
    };

  protected override ISch_DomainRegex MakeItem(IAstDomainRegex ast)
  {
    Sch_DomainRegex result = new();
    result.As__DomainRegex = new Sch_DomainRegexObject(
      SchModellerHelpers.Desc(ast.Description),
      ast.Excludes,
      ast.Pattern);
    return result;
  }

  protected override ISch_DomainItemRegex MakeAllItem(string domainName, IAstDomainRegex ast)
  {
    ISch_DomainRegex item = MakeItem(ast);
    return new Sch_DomainItemRegex {
      As_Parent = item,
      As__DomainItemRegex = new Sch_DomainItemRegexObject(SchModellerHelpers.MakeName(domainName)),
    };
  }
}
