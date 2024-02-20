using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;
using NSubstitute;

namespace GqlPlus.Verifier.Modelling;

public abstract class ModelBaseTests<TInput>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Default(TInput input)
    => BaseChecks.Model_Expected(
      BaseChecks.ToModel(BaseChecks.BaseAst(input)),
      ExpectedBase(input).Tidy());

  protected abstract string[] ExpectedBase(TInput input);
  internal abstract IModelBaseChecks<TInput> BaseChecks { get; }
}

internal abstract class ModelBaseChecks<TInput, TAst>
  : IModelBaseChecks<TInput>
  where TAst : AstBase
{
  private readonly IRendering _rendering;

  protected ModelBaseChecks()
  {
    _rendering = Substitute.For<IRendering>();
    RenderReturn("");
  }

  internal ModelBaseChecks<TInput, TAst> RenderReturn(string tagAndValue)
  {
    _rendering.Render()
        .Returns(new RenderStructure(tagAndValue, tagAndValue));

    return this;
  }

  internal void AstExpected(TAst ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected);

  internal static void Model_Expected(IRendering model, string[] expected)
  {
    var render = model.Render().ToYaml();

    render.ToLines().Should().BeEquivalentTo(expected);
  }

  internal string YamlQuoted(string input)
    => $"'{input.Replace("'", "''")}'";

  protected IModeller<TA> ForModeller<TA>()
    where TA : AstBase
  {
    var modeller = Substitute.For<IModeller<TA>>();
    modeller.ToRenderer(default!)
      .ReturnsForAnyArgs(_rendering);

    return modeller;
  }

  protected IModeller<TA> ForModeller<TA, TM>(Func<TA, TM> factory)
    where TA : AstBase
    where TM : IRendering
  {
    var modeller = Substitute.For<IModeller<TA>>();
    modeller.ToRenderer(default!)
      .ReturnsForAnyArgs(c => factory(c.Arg<TA>()));
    modeller.ToModel<TM>(default!)
      .ReturnsForAnyArgs(c => factory(c.Arg<TA>()));

    return modeller;
  }

  protected abstract TAst NewBaseAst(TInput input);
  protected abstract IRendering AstToModel(TAst ast);

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
