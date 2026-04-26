namespace GqlPlus.Modelling.Simple;

public class DomainEnumModellerTests
  : DomainModellerClassTestBase<IAstDomainLabel, DomainLabelModel>
{
  protected override IDomainModeller<IAstDomainLabel, DomainLabelModel> DomainModeller { get; }
    = new DomainEnumModeller();

  protected override DomainKind Kind => DomainKind.Enum;
  protected override DomainKindModel KindModel => DomainKindModel.Enum;
}
