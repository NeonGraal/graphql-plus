using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal abstract class ModelBaseChecks<TInput, TAst> : IModelBaseChecks<TInput>
  where TAst : AstBase
{
  internal void AstExpected(TAst ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected);

  internal static void Model_Expected(IRendering model, string[] expected)
  {
    var render = model.Render().ToYaml();

    render.ToLines().Should().BeEquivalentTo(expected);
  }

  internal string YamlQuoted(string input)
    => $"'{input.Replace("'", "''")}'";

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
