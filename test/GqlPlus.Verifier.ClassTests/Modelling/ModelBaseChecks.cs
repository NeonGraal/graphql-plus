using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;
using NSubstitute;

namespace GqlPlus.Verifier.Modelling;

internal abstract class ModelBaseChecks<TInput, TAst>
  : IModelBaseChecks<TInput>
  where TAst : IAstBase
{
  private readonly IRendering Rendering;

  protected ModelBaseChecks()
  {
    Rendering = Substitute.For<IRendering>();
    RenderReturn("");
  }

  internal ModelBaseChecks<TInput, TAst> RenderReturn(string tagAndValue)
  {
    Rendering.Render()
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
    where TA : IAstBase
  {
    var modeller = Substitute.For<IModeller<TA>>();
    modeller.ToRenderer(default!)
      .ReturnsForAnyArgs(Rendering);

    return modeller;
  }

  protected IModeller<TA> ForModeller<TA, TM>(Func<TA, TM> factory)
    where TA : IAstBase
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
  IAstBase IModelBaseChecks<TInput>.BaseAst(TInput input) => NewBaseAst(input);
  IRendering IModelBaseChecks<TInput>.ToModel(IAstBase ast) => AstToModel((TAst)ast);
  string IModelBaseChecks<TInput>.YamlQuoted(string input) => YamlQuoted(input);
}

internal interface IModelBaseChecks<TInput>
{
  IAstBase BaseAst(TInput input);
  IRendering ToModel(IAstBase ast);

  void Model_Expected(IRendering model, string[] expected);
  string YamlQuoted(string input);
}
