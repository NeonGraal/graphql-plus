using NSubstitute.ReceivedExtensions;

namespace GqlPlus.Modelling;

public class TypesModellerTests
  : SubstituteBase
{
  [Theory, RepeatData]
  public void ToModel_ForType_CallsToTypeModel(string name)
  {
    IAstType ast = A.Of<IAstType>();
    Map<TypeKindModel> typeKinds = [];

    ITypeModeller modeller = A.Of<ITypeModeller>();
    modeller.ForType(ast).Returns(true);
    modeller.ToTypeModel(ast, typeKinds).Returns(new SpecialTypeModel(name, string.Empty));

    IModellerRepository repo = A.Of<IModellerRepository>();
    repo.TypeModellers.Returns(new[] { modeller });
    TypesModeller sut = new(repo);

    BaseTypeModel result = sut.ToModel<BaseTypeModel>(ast, typeKinds);

    modeller.ShouldSatisfyAllConditions(
      m => m.ReceivedWithAnyArgs(1).ForType(ast),
      m => m.ReceivedWithAnyArgs(1).ToTypeModel(ast, typeKinds));
  }

  [Theory, RepeatData]
  public void AddTypeKind_ForType_CallsToTypeModel(string name)
  {
    IAstType ast = A.Named<IAstType>(name, string.Empty);
    Map<TypeKindModel> typeKinds = [];

    ITypeModeller modeller = A.Of<ITypeModeller>();
    modeller.ForType(ast).Returns(true);
    modeller.Kind.Returns(TypeKindModel.Special);

    IModellerRepository repo = A.Of<IModellerRepository>();
    repo.TypeModellers.Returns(new[] { modeller });
    TypesModeller sut = new(repo);

    sut.AddTypeKinds([ast], typeKinds);

    modeller.ShouldSatisfyAllConditions(
      () => _ = modeller.ReceivedWithAnyArgs(1).Kind,
      () => typeKinds.ShouldContainKey(name));
  }
}
