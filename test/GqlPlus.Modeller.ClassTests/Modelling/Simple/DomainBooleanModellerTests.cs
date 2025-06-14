namespace GqlPlus.Modelling.Simple;

public class DomainBooleanModellerTests
  : DomainModellerClassTestBase<IGqlpDomainTrueFalse, DomainTrueFalseModel>
{
  protected override IDomainModeller<IGqlpDomainTrueFalse, DomainTrueFalseModel> DomainModeller { get; }
    = new DomainBooleanModeller();

  protected override DomainKind Kind => DomainKind.Boolean;
  protected override DomainKindModel KindModel => DomainKindModel.Boolean;
}
