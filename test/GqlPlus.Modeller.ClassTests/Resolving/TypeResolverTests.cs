namespace GqlPlus.Resolving;

public class TypeResolverTests
  : ResolverClassTestBase<TypeEnumModel>
{
  private readonly TypeEnumResolver _resolver = new();
  private ITypeResolver TypeResolver => _resolver;

  protected override IResolver<TypeEnumModel> Resolver => _resolver;

  [Theory, RepeatData]
  public void ForType_WithCorrectModelType_ReturnsTrue(string name)
  {
    TypeEnumModel model = new(name, "");

    bool result = TypeResolver.ForType(model);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void ForType_WithWrongModelType_ReturnsFalse(string name)
  {
    TypeUnionModel model = new(name, "");

    bool result = TypeResolver.ForType(model);

    result.ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void ResolveType_WithCorrectModelType_ReturnsModel(string name)
  {
    TypeEnumModel model = new(name, "");

    BaseTypeModel result = TypeResolver.ResolveType(model, Context);

    result.ShouldBe(model);
  }

  [Theory, RepeatData]
  public void ResolveType_WithWrongModelType_ThrowsException(string name)
  {
    TypeUnionModel model = new(name, "");

    Action action = () => TypeResolver.ResolveType(model, Context);

    action.ShouldThrow<InvalidCastException>();
  }
}
