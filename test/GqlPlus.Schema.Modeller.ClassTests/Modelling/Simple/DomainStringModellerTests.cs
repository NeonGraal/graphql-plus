namespace GqlPlus.Modelling;

public class DomainStringModellerTests
  : DomainModellerClassTestBase<IAstDomainRegex, DomainRegexModel>
{
  protected override IDomainModeller<IAstDomainRegex, DomainRegexModel> DomainModeller { get; }
    = new DomainStringModeller();

  protected override DomainKind Kind => DomainKind.String;
  protected override DomainKindModel KindModel => DomainKindModel.String;
}
