namespace GqlPlus.Schema.Modelling;

public abstract class SchModellerClassTestBase<TAst, TModel>
  : SubstituteBase
  where TAst : class, IAstError
  where TModel : class
{
  protected IMap<GqlpTypeKind> TypeKinds { get; } = new Map<GqlpTypeKind>();

  protected abstract IModeller<TAst, TModel> Modeller { get; }

  [Fact]
  public void ToModel_WithNullAst_ThrowsException()
  {
    Action act = () => Modeller.ToModel(default, TypeKinds);

    act.ShouldThrow<Exception>();
  }

  protected void TypeKindIs(string key, GqlpTypeKind kind)
    => TypeKinds[key] = kind;
}
