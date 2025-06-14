namespace GqlPlus.Modelling.Simple;

public class DomainStringModellerTests
  : DomainModellerClassTestBase<IGqlpDomainRegex, DomainRegexModel>
{
  protected override IDomainModeller<IGqlpDomainRegex, DomainRegexModel> DomainModeller { get; }
    = new DomainStringModeller();

  protected override DomainKind Kind => DomainKind.String;
  protected override DomainKindModel KindModel => DomainKindModel.String;
}
