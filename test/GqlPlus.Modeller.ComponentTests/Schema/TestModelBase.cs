using GqlPlus.Convert;
using GqlPlus.Modelling;
using GqlPlus.Resolving;

namespace GqlPlus.Schema;

public abstract class TestModelBase<TName, TRender>(
  ICheckModelBase<TName, TRender> baseChecks
) where TRender : IModelBase
{
  [SkippableTheory, RepeatData(Repeats)]
  public void Model_Default(TName name)
    => baseChecks
      .SkipIf(SkipIf(name))
      .Model_Expected(
        baseChecks.ToModel(baseChecks.BaseAst(name)),
        baseChecks.ExpectedBase(name));

  protected virtual bool SkipIf(TName name)
    => false;

  internal ToExpected<TItem> EmptyExpected<TItem>() => i => [];
}

internal abstract class CheckModelBase<TName, TAst, TModel>(
  IModeller<TAst, TModel> modeller,
  IRenderer<TModel> rendering
) : CheckModelBase<TName, TAst, TAst, TModel, TModel>(modeller, rendering)
  where TAst : IGqlpError
  where TModel : IModelBase
{ }

internal abstract class CheckModelBase<TName, TSrc, TAst, TModel>(
  IModeller<TSrc, TModel> modeller,
  IRenderer<TModel> rendering
) : CheckModelBase<TName, TSrc, TAst, TModel, TModel>(modeller, rendering)
  where TSrc : IGqlpError
  where TAst : IGqlpError, TSrc
  where TModel : IModelBase
{ }

internal abstract class CheckModelBase<TName, TSrc, TAst, TModel, TRender>
  : ICheckModelBase<TName, TRender>
  where TSrc : IGqlpError
  where TAst : IGqlpError, TSrc
  where TModel : IModelBase
  where TRender : IModelBase
{
  protected IModeller<TSrc, TModel> _modeller;
  protected IRenderer<TRender> _rendering;

  public IResolveContext Context { get; } = new TestResolveContext();
  public IMap<TypeKindModel> TypeKinds { get; } = new Map<TypeKindModel>();

  protected CheckModelBase(IModeller<TSrc, TModel> modeller, IRenderer<TRender> rendering)
  {
    ArgumentNullException.ThrowIfNull(modeller);
    ArgumentNullException.ThrowIfNull(rendering);

    _modeller = modeller;
    _rendering = rendering;
  }

  internal void AstExpected(TAst ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected);

  internal void Model_Expected(IModelBase model, string[] expected)
  {
    Structured render = _rendering.Render((TRender)model);

    string yaml = render.ToYaml(false);

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

  void ICheckModelBase.Model_Expected(IModelBase model, string[] expected) => Model_Expected(model, expected);
  IGqlpError ICheckModelBase<TName, TRender>.BaseAst(TName name) => NewBaseAst(name);
  IModelBase ICheckModelBase.ToModel(IGqlpError ast) => AstToModel((TAst)ast);
  string[] ICheckModelBase<TName, TRender>.ExpectedBase(TName name) => ExpectedBase(name);
}

public delegate IEnumerable<string> ToExpected<TItem>(TItem input);

public interface ICheckModelBase<TName, TRender>
  : ICheckModelBase
  where TRender : IModelBase
{
  IGqlpError BaseAst(TName name);
  string[] ExpectedBase(TName name);
}

public interface ICheckModelBase
{
  IResolveContext Context { get; }
  IMap<TypeKindModel> TypeKinds { get; }
  IModelBase ToModel(IGqlpError ast);

  void Model_Expected(IModelBase model, string[] expected);
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
