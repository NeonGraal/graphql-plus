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
    BaseTypeModel model = new SpecialTypeModel("special", string.Empty);
    TryModelReturns(Modeller, model);

    TypesContext result = TypesContext.WithBuiltins(Modeller);

    result.ShouldSatisfyAllConditions(
      r => r[BuiltIn.StringAlias].ShouldBe(TypeKindModel.Basic),
      r => r.TryGetType("", BuiltIn.StringAlias, out BaseTypeModel? _).ShouldBeTrue()
      );
  }
}
