using GqlPlus.Abstractions.Schema;
using GqlPlus.Models;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using Shouldly;

namespace GqlPlus.Modelling;

public class TypesModellerTests
  : SubstituteBase
{
  [Fact]
  public void ToModel_ForType_CallsToTypeModel()
  {
    IGqlpType ast = For<IGqlpType>();
    Map<TypeKindModel> typeKinds = [];

    ITypeModeller modeller = For<ITypeModeller>();
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
