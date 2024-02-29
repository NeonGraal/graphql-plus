using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;
using NSubstitute;

namespace GqlPlus.Verifier.Modelling;

public abstract class ModelBaseTests<TInput>
{
  [SkippableTheory, RepeatData(Repeats)]
  public void Model_Default(TInput input)
  {
    Skip.If(SkipIf(input));

    BaseChecks.Model_Expected(
        BaseChecks.ToModel(BaseChecks.BaseAst(input)),
        ExpectedBase(input).Tidy());
  }

  protected virtual bool SkipIf(TInput input)
    => false;

  protected abstract string[] ExpectedBase(TInput input);
  internal abstract IModelBaseChecks<TInput> BaseChecks { get; }
}

internal abstract class ModelBaseChecks<TInput, TAst, TModel>
  : IModelBaseChecks<TInput>
  where TAst : AstBase
  where TModel : IRendering
{
  protected IModeller<TAst> _modeller;

  protected ModelBaseChecks(IModeller<TAst> modeller)
  {
    ArgumentNullException.ThrowIfNull(modeller);

    _modeller = modeller;
  }

  internal void AstExpected(TAst ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected);

  internal static void Model_Expected(IRendering model, string[] expected)
  {
    var render = model.Render().ToYaml();

    render.ToLines().Should().BeEquivalentTo(expected);
  }

  [SuppressMessage("Performance", "CA1822:Mark members as static")]
  internal string YamlQuoted(string? input)
    => input is null ? ""
    : $"'{input.Replace("'", "''", StringComparison.Ordinal)}'";

  protected abstract TAst NewBaseAst(TInput input);
  protected TModel AstToModel(TAst ast)
    => _modeller.ToModel<TModel>(ast);

  void IModelBaseChecks<TInput>.Model_Expected(IRendering model, string[] expected) => Model_Expected(model, expected);
  AstBase IModelBaseChecks<TInput>.BaseAst(TInput input) => NewBaseAst(input);
  IRendering IModelBaseChecks<TInput>.ToModel(AstBase ast) => AstToModel((TAst)ast);
  string IModelBaseChecks<TInput>.YamlQuoted(string input) => YamlQuoted(input);
}

internal interface IModelBaseChecks<TInput>
{
  AstBase BaseAst(TInput input);
  IRendering ToModel(AstBase ast);

  void Model_Expected(IRendering model, string[] expected);
  string YamlQuoted(string input);
}

internal static class TestModeller<TAst>
  where TAst : AstBase
{
  internal static IModeller<TAst> For()
  {
    var rendering = Substitute.For<IRendering>();
    rendering.Render()
        .Returns(new RenderStructure("", ""));

    var modeller = Substitute.For<IModeller<TAst>>();
    modeller.ToRenderer(default!)
      .ReturnsForAnyArgs(rendering);

    return modeller;
  }

  internal static IModeller<TAst> For<TModel>(Func<TAst, TModel> factory)
    where TModel : IRendering
  {
    var modeller = Substitute.For<IModeller<TAst>>();
    modeller.ToRenderer(default!)
      .ReturnsForAnyArgs(c => factory(c.Arg<TAst>()));
    modeller.ToModel<TModel>(default)
      .ReturnsForAnyArgs(c => factory(c.Arg<TAst>()));

    return modeller;
  }
}
