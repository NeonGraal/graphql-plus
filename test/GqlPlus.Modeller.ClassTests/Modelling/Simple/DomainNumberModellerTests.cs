namespace GqlPlus.Modelling.Simple;

public class DomainNumberModellerTests
  : DomainModellerClassTestBase<IGqlpDomainRange, DomainRangeModel>
{
  protected override IDomainModeller<IGqlpDomainRange, DomainRangeModel> DomainModeller { get; }
    = new DomainNumberModeller();

  protected override DomainKind Kind => DomainKind.Number;
  protected override DomainKindModel KindModel => DomainKindModel.Number;
}
