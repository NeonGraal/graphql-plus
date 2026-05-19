namespace GqlPlus.Modelling;

public class ModellerTests
  : SubstituteBase
{
  private readonly IMap<TypeKindModel> _typeKinds = A.Of<IMap<TypeKindModel>>();

  [Fact]
  public void TryModel_WhenCalled_DelegatesToValue()
  {
    IModeller<IAstError, IModelBase> inner = A.Of<IModeller<IAstError, IModelBase>>();
    IModelBase expected = A.Of<IModelBase>();
    inner.TryModel(Arg.Any<IAstError>(), _typeKinds).Returns(expected);

    Modeller<IAstError, IModelBase> modeller = new(() => inner);

    IModelBase? result = modeller.TryModel(A.Of<IAstError>(), _typeKinds);

    result.ShouldBeSameAs(expected);
  }

  [Fact]
  public void ToModel_WhenCalled_DelegatesToValue()
  {
    IModeller<IAstError, IModelBase> inner = A.Of<IModeller<IAstError, IModelBase>>();
    IModelBase expected = A.Of<IModelBase>();
    inner.ToModel(Arg.Any<IAstError>(), _typeKinds).Returns(expected);

    Modeller<IAstError, IModelBase> modeller = new(() => inner);

    IModelBase result = modeller.ToModel(A.Of<IAstError>(), _typeKinds);

    result.ShouldBeSameAs(expected);
  }

  [Fact]
  public void ToModels_WhenCalled_DelegatesToValue()
  {
    IModeller<IAstError, IModelBase> inner = A.Of<IModeller<IAstError, IModelBase>>();
    IModelBase[] expected = [A.Of<IModelBase>()];
    inner.ToModels(Arg.Any<IEnumerable<IAstError>>(), _typeKinds).Returns(expected);

    Modeller<IAstError, IModelBase> modeller = new(() => inner);

    IModelBase[] result = modeller.ToModels([A.Of<IAstError>()], _typeKinds);

    result.ShouldBeSameAs(expected);
  }

  [Fact]
  public void ImplicitConvert_FromDelegate_ReturnsModeller()
  {
    IModeller<IAstError, IModelBase> inner = A.Of<IModeller<IAstError, IModelBase>>();
    IModelBase expected = A.Of<IModelBase>();
    inner.ToModel(Arg.Any<IAstError>(), _typeKinds).Returns(expected);

    Modeller<IAstError, IModelBase>.D factory = () => inner;
    Modeller<IAstError, IModelBase> result = factory;

    result.ToModel(A.Of<IAstError>(), _typeKinds).ShouldBeSameAs(expected);
  }

  [Fact]
  public void ImplicitConvert_NullFactory_ThrowsArgumentNullException()
  {
    Modeller<IAstError, IModelBase>.D? factory = null;

    Action result = () => _ = (Modeller<IAstError, IModelBase>)factory!;

    result.ShouldThrow<ArgumentNullException>();
  }
}
