using GqlPlus.Modelling;
using NSubstitute.ExceptionExtensions;

namespace GqlPlus.Resolving;

public class TypesContextTests
  : ModellerClassTestBase<IGqlpType, BaseTypeModel>
{
  protected override IModeller<IGqlpType, BaseTypeModel> Modeller { get; }

  public TypesContextTests()
  {
    Modeller = A.Of<IModeller<IGqlpType, BaseTypeModel>>();
    Modeller.ToModel(null, TypeKinds).Throws<ModelTypeException<IGqlpType>>();
  }

  [Fact]
  public void TypesContext_DefinesString_TypeKindAndModel()
  {
    BaseTypeModel model = new SpecialTypeModel("special", "");
    TryModelReturns(Modeller, model);

    TypesContext result = TypesContext.WithBuiltins(Modeller);

    result.ShouldSatisfyAllConditions(
      r => r["*"].ShouldBe(TypeKindModel.Basic),
      r => r.TryGetType("", "*", out BaseTypeModel? _).ShouldBeTrue()
      );
  }
}
