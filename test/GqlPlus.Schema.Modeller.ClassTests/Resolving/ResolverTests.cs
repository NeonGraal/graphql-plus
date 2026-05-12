using GqlPlus.Models;
using GqlPlus.Resolving;

namespace GqlPlus.Resolving;

public class ResolverTests
  : SubstituteBase
{
  [Fact]
  public void Resolve_WhenCalled_DelegatesToValue()
  {
    IResolver<IModelBase> inner = A.Of<IResolver<IModelBase>>();
    IModelBase model = A.Of<IModelBase>();
    IResolveContext context = A.Of<IResolveContext>();
    inner.Resolve(model, context).Returns(model);

    Resolver<IModelBase> resolver = new(() => inner);

    IModelBase result = resolver.Resolve(model, context);

    result.ShouldBeSameAs(model);
  }

  [Fact]
  public void ImplicitConvert_FromDelegate_ReturnsResolver()
  {
    IResolver<IModelBase> inner = A.Of<IResolver<IModelBase>>();
    IModelBase model = A.Of<IModelBase>();
    IResolveContext context = A.Of<IResolveContext>();
    inner.Resolve(model, context).Returns(model);

    Resolver<IModelBase>.D factory = () => inner;
    Resolver<IModelBase> result = factory;

    result.Resolve(model, context).ShouldBeSameAs(model);
  }

  [Fact]
  public void ImplicitConvert_NullFactory_ThrowsArgumentNullException()
  {
    Resolver<IModelBase>.D? factory = null;

    Action result = () => _ = (Resolver<IModelBase>)factory!;

    result.ShouldThrow<ArgumentNullException>();
  }
}
