namespace GqlPlus.Modelling.Simple;

public class DomainEnumModellerTests
  : DomainModellerClassTestBase<IGqlpDomainLabel, DomainLabelModel>
{
  protected override IDomainModeller<IGqlpDomainLabel, DomainLabelModel> DomainModeller { get; }
    = new DomainEnumModeller();

  protected override DomainKind Kind => DomainKind.Enum;
  protected override DomainKindModel KindModel => DomainKindModel.Enum;
}
