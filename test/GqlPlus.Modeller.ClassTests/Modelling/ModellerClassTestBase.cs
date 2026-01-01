namespace GqlPlus.Modelling;

public abstract class ModellerClassTestBase<TAst, TModel>
  : SubstituteBase
  where TAst : IGqlpError
  where TModel : IModelBase
{
  [Fact]
  public void ToModel_WithNullAst_ThrowsModelTypeException()
  {
    Action act = () => Modeller.ToModel(default, TypeKinds);

    // Act & Assert
    act.ShouldThrow<ModelTypeException<TAst>>();
  }

  protected abstract IModeller<TAst, TModel> Modeller { get; }

  protected IMap<TypeKindModel> TypeKinds { get; } = A.Of<IMap<TypeKindModel>>();

  internal static IModeller<TA, TM> MFor<TA, TM>()
    where TA : IGqlpError
    where TM : IModelBase
    => A.Of<IModeller<TA, TM>>();

  internal void ToModelReturns<TA, TM>(IModeller<TA, TM> modeller, TM result)
    where TA : IGqlpError
    where TM : IModelBase
  {
    modeller.ToModel(default, TypeKinds).ReturnsForAnyArgs(result);
    modeller.ToModel<TM>(default, TypeKinds).ReturnsForAnyArgs(result);
  }

  internal void ToModelReturns<TA, TM>(IModeller<TA, TM> modeller, TA arg, TM result)
    where TA : IGqlpError
    where TM : IModelBase
  {
    modeller.ToModel(arg, TypeKinds).Returns(result);
    modeller.ToModel<TM>(arg, TypeKinds).Returns(result);
  }

  internal void ToModelsReturns<TA, TM>(IModeller<TA, TM> modeller, TM[] results)
    where TA : IGqlpError
    where TM : IModelBase
  {
    modeller.ToModels(default, TypeKinds).ReturnsForAnyArgs(results);
    modeller.ToModels<TM>(default, TypeKinds).ReturnsForAnyArgs(results);
  }

  internal void ToModelsReturns<TI, TA, TM>(TI modeller, IEnumerable<TA> args, TM[] results)
    where TI : IModeller<TA, TM>
    where TA : IGqlpError
    where TM : IModelBase
  {
    modeller.ToModels(args, TypeKinds).Returns(results);
    modeller.ToModels<TM>(args, TypeKinds).Returns(results);
  }

  internal void TryModelReturns<TA, TM>(IModeller<TA, TM> modeller, TM result)
    where TA : IGqlpError
    where TM : IModelBase
  {
    modeller.TryModel(default, TypeKinds).ReturnsForAnyArgs(result);
    // modeller.TryModel<TM>(default, TypeKinds).ReturnsForAnyArgs(result);
  }

  internal void TryModelReturns<TA, TM>(IModeller<TA, TM> modeller, TA arg, TM result)
    where TA : IGqlpError
    where TM : IModelBase
  {
    modeller.TryModel(arg, TypeKinds).Returns(result);
    // modeller.TryModel<TM>(arg, TypeKinds).Returns(result);
  }

  internal void TypeKindIs(string key, TypeKindModel typeKind)
  {
    TypeKinds.TryGetValue(key, out Arg.Any<TypeKindModel>())
        .Returns(x => {
          x[1] = typeKind;
          return true;
        });
  }
}
