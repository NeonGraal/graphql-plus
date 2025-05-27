using GqlPlus.Modelling;

namespace GqlPlus.Resolving;

public class TypesContextTests
  : SubstituteBase
{
  [Fact]
  public void TypesContext_DefinesString_TypeKindAndModel()
  {
    IModeller<IGqlpType, BaseTypeModel> typesModeller = For<IModeller<IGqlpType, BaseTypeModel>>();
    BaseTypeModel model = new SpecialTypeModel("special", "");
    typesModeller.TryModel(null, null!).ReturnsForAnyArgs(model);

    TypesContext result = TypesContext.WithBuiltins(typesModeller);

    result.ShouldSatisfyAllConditions(
      r => r["*"].ShouldBe(TypeKindModel.Basic),
      r => r.TryGetType("", "*", out BaseTypeModel? _).ShouldBeTrue()
      );
  }
}
