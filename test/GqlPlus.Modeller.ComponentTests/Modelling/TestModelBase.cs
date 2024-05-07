namespace GqlPlus.Modelling;

public abstract class TestModelBase<TName>
{
  [SkippableTheory, RepeatData(Repeats)]
  public void Model_Default(TName name)
    => BaseChecks
      .SkipIf(SkipIf(name))
      .Model_Expected(
        BaseChecks.ToModel(BaseChecks.BaseAst(name)),
        BaseChecks.ExpectedBase(name));

  protected virtual bool SkipIf(TName name)
    => false;

  internal ToExpected<TItem> EmptyExpected<TItem>() => i => [];

  internal abstract ICheckModelBase<TName> BaseChecks { get; }
}

internal abstract class CheckModelBase<TName, TAst, TModel>(
  IModeller<TAst, TModel> modeller
) : CheckModelBase<TName, TAst, TAst, TModel>(modeller)
  where TAst : AstBase
  where TModel : IRendering
{ }

internal abstract class CheckModelBase<TName, TSrc, TAst, TModel>
  : ICheckModelBase<TName>
  where TSrc : IGqlpError
  where TAst : IGqlpError, TSrc
  where TModel : IRendering
{
  protected IModeller<TSrc, TModel> _modeller;

  public IRenderContext Context { get; } = new TestRenderContext();
  public IMap<TypeKindModel> TypeKinds { get; } = new Map<TypeKindModel>();

  protected CheckModelBase(IModeller<TSrc, TModel> modeller)
  {
    ArgumentNullException.ThrowIfNull(modeller);

    _modeller = modeller;
  }

  internal void AstExpected(TAst ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected);

  internal void Model_Expected(IRendering model, string[] expected)
  {
    RenderStructure render = model.Render(Context);

    string yaml = render.ToYaml();

    yaml.ToLines().Should().Equal(expected.Tidy());
  }

  protected virtual TModel AstToModel(TAst ast)
    => _modeller.ToModel<TModel>(ast, TypeKinds);

  protected abstract TAst NewBaseAst(TName name);
  protected abstract string[] ExpectedBase(TName name);

  protected static IEnumerable<string> ItemsExpected<TItem>(string field, TItem[]? items, ToExpected<TItem> mapping)
    => items == null || items.Length == 0 ? []
      : string.IsNullOrWhiteSpace(field)
        ? items.SelectMany(i => mapping(i))
        : items.SelectMany(i => mapping(i)).Prepend(field);

  void ICheckModelBase.Model_Expected(IRendering model, string[] expected) => Model_Expected(model, expected);
  IGqlpError ICheckModelBase<TName>.BaseAst(TName name) => NewBaseAst(name);
  IRendering ICheckModelBase.ToModel(IGqlpError ast) => AstToModel((TAst)ast);
  string[] ICheckModelBase<TName>.ExpectedBase(TName name) => ExpectedBase(name);
}

internal delegate IEnumerable<string> ToExpected<TItem>(TItem input);

internal interface ICheckModelBase<TName>
  : ICheckModelBase
{
  IGqlpError BaseAst(TName name);
  string[] ExpectedBase(TName name);
}

internal interface ICheckModelBase
{
  IRenderContext Context { get; }
  IMap<TypeKindModel> TypeKinds { get; }
  IRendering ToModel(IGqlpError ast);

  void Model_Expected(IRendering model, string[] expected);
}

internal static class CheckModelBaseHelper
{
  internal static TCheck AddParent<TCheck>(this TCheck check, BaseTypeModel type)
    where TCheck : ICheckModelBase
  {
    if (check.Context is IDictionary<string, BaseTypeModel> dict) {
      dict.Add(type.Name, type);
    }

    return check;
  }

  internal static TCheck AddTypeKinds<TCheck, TItem>(this TCheck check, TypeKindModel kind, params TItem[] types)
    where TCheck : ICheckModelBase
    => check.AddTypeKinds(types, kind);

  internal static TCheck AddTypeKinds<TCheck, TItem>(this TCheck check, IEnumerable<TItem> types, TypeKindModel kind)
    where TCheck : ICheckModelBase
  {
    foreach (TItem? type in types) {
      string key = $"{type}";
      if (!string.IsNullOrWhiteSpace(key)) {
        check.TypeKinds[key] = kind;
      }
    }

    return check;
  }
}
