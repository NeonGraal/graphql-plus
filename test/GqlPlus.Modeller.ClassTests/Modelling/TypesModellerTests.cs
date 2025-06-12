using NSubstitute.ReceivedExtensions;

namespace GqlPlus.Modelling;

public class TypesModellerTests
  : SubstituteBase
{
  [Fact]
  public void ToModel_ForType_CallsToTypeModel()
  {
    IGqlpType ast = A.Of<IGqlpType>();
    Map<TypeKindModel> typeKinds = [];

    ITypeModeller modeller = A.Of<ITypeModeller>();
    modeller.ForType(ast).Returns(true);
    modeller.ToTypeModel(ast, typeKinds).Returns(new TestTypeModel());

    TypesModeller sut = new([modeller]);

    BaseTypeModel result = sut.ToModel<BaseTypeModel>(ast, typeKinds);

    modeller.ShouldSatisfyAllConditions(
      m => m.ReceivedWithAnyArgs(1).ForType(ast),
      m => m.ReceivedWithAnyArgs(1).ToTypeModel(ast, typeKinds));
  }
}

internal sealed record TestTypeModel
  : BaseTypeModel
{
  public TestTypeModel()
    : base(TypeKindModel.Basic, "Test", "")
  { }
}
