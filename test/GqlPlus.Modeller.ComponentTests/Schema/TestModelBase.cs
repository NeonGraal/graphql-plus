using GqlPlus.Abstractions.Schema;
using GqlPlus.Convert;
using GqlPlus.Modelling;
using GqlPlus.Resolving;

namespace GqlPlus.Schema;

public abstract class TestModelBase<TName, TResult>(
  ICheckModelBase<TName, TResult> baseChecks
) where TResult : IModelBase
{
  [Theory, RepeatData]
  public void Model_Default(TName name)
    => baseChecks
      .SkipIf(SkipIf(name), SkipReason)
      .Model_Expected(
        baseChecks.ToModel(baseChecks.BaseAst(name)),
        baseChecks.ExpectedBase(name));

  protected virtual bool SkipIf(TName name)
    => false;
  protected virtual string SkipReason => "";

  internal ToExpected<TItem> EmptyExpected<TItem>() => i => [];
}

internal abstract class CheckModelBase<TName, TAst, TModel>(
  IModeller<TAst, TModel> modeller,
  IEncoder<TModel> encoding
) : CheckModelBase<TName, TAst, TAst, TModel, TModel>(modeller, encoding)
  where TAst : IGqlpError
  where TModel : IModelBase
{ }

internal abstract class CheckModelBase<TName, TSrc, TAst, TModel>(
  IModeller<TSrc, TModel> modeller,
  IEncoder<TModel> encoding
) : CheckModelBase<TName, TSrc, TAst, TModel, TModel>(modeller, encoding)
  where TSrc : IGqlpError
  where TAst : IGqlpError, TSrc
  where TModel : IModelBase
{ }

internal abstract class CheckModelBase<TName, TSrc, TAst, TModel, TResult>
  : ICheckModelBase<TName, TResult>
  where TSrc : IGqlpError
  where TAst : IGqlpError, TSrc
  where TModel : IModelBase
  where TResult : IModelBase
{
  protected IModeller<TSrc, TModel> _modeller;
  protected IEncoder<TResult> _encoding;

  public IResolveContext Context { get; } = new TestResolveContext();
  public IMap<TypeKindModel> TypeKinds { get; } = new Map<TypeKindModel>();

  protected CheckModelBase(IModeller<TSrc, TModel> modeller, IEncoder<TResult> encoding)
  {
    ArgumentNullException.ThrowIfNull(modeller);
    ArgumentNullException.ThrowIfNull(encoding);

    _modeller = modeller;
    _encoding = encoding;
  }

  internal void AstExpected(TAst ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected);

  internal void Model_Expected(IModelBase model, string[] expected)
  {
    Structured render = _encoding.Encode((TResult)model);

    string[] yaml = render.ToPlain(false);
    yaml.ShouldBe(expected.Tidy());
  }

  protected virtual TModel AstToModel(TAst ast)
    => _modeller.ToModel<TModel>(ast, TypeKinds);

  protected abstract TAst NewBaseAst(TName name);
  protected abstract string[] ExpectedBase(TName name);

  protected static IEnumerable<string> ItemsExpected<TItem>(string field, TItem[]? items, ToExpected<TItem> mapping)
    => items == null || items.Length == 0 ? []
      : field.IsWhiteSpace()
        ? items.SelectMany(i => mapping(i))
        : items.SelectMany(i => mapping(i)).Prepend(field);

  void ICheckModelBase.Model_Expected(IModelBase model, string[] expected) => Model_Expected(model, expected);
  IGqlpError ICheckModelBase<TName, TResult>.BaseAst(TName name) => NewBaseAst(name);
  IModelBase ICheckModelBase.ToModel(IGqlpError ast) => AstToModel((TAst)ast);
  string[] ICheckModelBase<TName, TResult>.ExpectedBase(TName name) => ExpectedBase(name);
}

public delegate IEnumerable<string> ToExpected<TItem>(TItem input);

public interface ICheckModelBase<TName, TResult>
  : ICheckModelBase
  where TResult : IModelBase
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
    foreach (TItem type in types) {
      string key = $"{type}";
      if (type is IGqlpNamed named) {
        key = named.Name;
      }

      if (!key.IsWhiteSpace()) {
        check.TypeKinds[key] = kind;
      }
    }

    return check;
  }
}
