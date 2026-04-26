namespace GqlPlus.Modelling.Simple;

public class DomainNumberModellerTests
  : DomainModellerClassTestBase<IAstDomainRange, DomainRangeModel>
{
  protected override IDomainModeller<IAstDomainRange, DomainRangeModel> DomainModeller { get; }
    = new DomainNumberModeller();

  protected override DomainKind Kind => DomainKind.Number;
  protected override DomainKindModel KindModel => DomainKindModel.Number;
}
