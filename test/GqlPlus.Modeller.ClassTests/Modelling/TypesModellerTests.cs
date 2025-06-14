using NSubstitute.ReceivedExtensions;

namespace GqlPlus.Modelling;

public class TypesModellerTests
  : SubstituteBase
{
  [Theory, RepeatData]
  public void ToModel_ForType_CallsToTypeModel(string name)
  {
    IGqlpType ast = A.Of<IGqlpType>();
    Map<TypeKindModel> typeKinds = [];

    ITypeModeller modeller = A.Of<ITypeModeller>();
    modeller.ForType(ast).Returns(true);
    modeller.ToTypeModel(ast, typeKinds).Returns(new SpecialTypeModel(name, ""));

    TypesModeller sut = new([modeller]);

    BaseTypeModel result = sut.ToModel<BaseTypeModel>(ast, typeKinds);

    modeller.ShouldSatisfyAllConditions(
      m => m.ReceivedWithAnyArgs(1).ForType(ast),
      m => m.ReceivedWithAnyArgs(1).ToTypeModel(ast, typeKinds));
  }

  [Theory, RepeatData]
  public void AddTypeKind_ForType_CallsToTypeModel(string name)
  {
    IGqlpType ast = A.Named<IGqlpType>(name, "");
    Map<TypeKindModel> typeKinds = [];

    ITypeModeller modeller = A.Of<ITypeModeller>();
    modeller.ForType(ast).Returns(true);
    modeller.Kind.Returns(TypeKindModel.Special);

    TypesModeller sut = new([modeller]);

    sut.AddTypeKinds([ast], typeKinds);

    modeller.ShouldSatisfyAllConditions(
      () => _ = modeller.ReceivedWithAnyArgs(1).Kind,
      () => typeKinds.ShouldContainKey(name));
  }
}
