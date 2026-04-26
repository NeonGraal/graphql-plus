using GqlPlus.Modelling.Simple;

namespace GqlPlus.Modelling;

public class SpecialTypeModellerTests
  : TypeModellerTests<IAstTypeSpecial, SpecialTypeModel>
{
  public SpecialTypeModellerTests()
    : base(TypeKindModel.Special)
  { }

  protected override IModeller<IAstTypeSpecial, SpecialTypeModel> Modeller { get; }
    = new SpecialTypeModeller();
}
