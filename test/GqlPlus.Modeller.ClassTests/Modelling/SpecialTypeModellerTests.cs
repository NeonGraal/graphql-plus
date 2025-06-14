using GqlPlus.Modelling.Simple;

namespace GqlPlus.Modelling;

public class SpecialTypeModellerTests
  : TypeModellerTests<IGqlpTypeSpecial, SpecialTypeModel>
{
  public SpecialTypeModellerTests()
    : base(TypeKindModel.Special)
  { }

  protected override IModeller<IGqlpTypeSpecial, SpecialTypeModel> Modeller { get; }
    = new SpecialTypeModeller();
}
