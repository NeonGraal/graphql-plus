using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

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

  internal abstract ICheckModelBase<TName> BaseChecks { get; }
}

internal abstract class CheckModelBase<TName, TAst, TModel>
  : ICheckModelBase<TName>
  where TAst : AstBase
  where TModel : IRendering
{
  protected IModeller<TAst, TModel> _modeller;

  public IRenderContext Context { get; } = new TestRenderContext();
  public IMap<TypeKindModel> TypeKinds { get; } = new Map<TypeKindModel>();

  protected CheckModelBase(IModeller<TAst, TModel> modeller)
  {
    ArgumentNullException.ThrowIfNull(modeller);

    _modeller = modeller;
  }

  internal void AstExpected(TAst ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected, false);

  internal void Model_Expected(IRendering model, string[] expected, bool skipIf)
  {
    Skip.If(skipIf);

    var render = model.Render(Context);

    var yaml = render.ToYaml();

    yaml.ToLines().Should().Equal(expected.Tidy());
  }

  internal string YamlQuoted(string? input)
    => input is null ? ""
    : $"'{input.Replace("'", "''", StringComparison.Ordinal)}'";

  protected TModel AstToModel(TAst ast)
    => _modeller.ToModel<TModel>(ast, TypeKinds);

  protected abstract TAst NewBaseAst(TName name);
  protected abstract string[] ExpectedBase(TName name);

  protected static IEnumerable<string> ItemsExpected<TItem>(string field, TItem[]? items, Func<TItem, IEnumerable<string>> mapping)
    => items == null || items.Length == 0 ? []
      : string.IsNullOrWhiteSpace(field)
        ? items.SelectMany(mapping)
        : items.SelectMany(mapping).Prepend(field);

  void ICheckModelBase.Model_Expected(IRendering model, string[] expected) => Model_Expected(model, expected, false);
  AstBase ICheckModelBase<TName>.BaseAst(TName name) => NewBaseAst(name);
  IRendering ICheckModelBase.ToModel(AstBase ast) => AstToModel((TAst)ast);
  string ICheckModelBase.YamlQuoted(string input) => YamlQuoted(input);
  string[] ICheckModelBase<TName>.ExpectedBase(TName name) => ExpectedBase(name);
}

internal interface ICheckModelBase<TName>
  : ICheckModelBase
{
  AstBase BaseAst(TName name);
  string[] ExpectedBase(TName name);
}

internal interface ICheckModelBase
{
  IRenderContext Context { get; }
  IMap<TypeKindModel> TypeKinds { get; }
  IRendering ToModel(AstBase ast);

  void Model_Expected(IRendering model, string[] expected);
  string YamlQuoted(string input);
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
    foreach (var type in types) {
      var key = $"{type}";
      if (!string.IsNullOrWhiteSpace(key)) {
        check.TypeKinds[key] = kind;
      }
    }

    return check;
  }

  internal static TCheck SkipIf<TCheck>(this TCheck check, bool skipIf)
    where TCheck : ICheckModelBase
  {
    Skip.If(skipIf);

    return check;
  }
}
