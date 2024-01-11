using System.Threading.Tasks;
using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Model;

internal abstract class ModelBaseChecks<TInput, TAst> : IModelBaseChecks<TInput>
  where TAst : AstBase
{
  internal static void Model_Expected(IRendering model, string[] expected)
  {
    var render = model.Render().ToYaml();

    render.ToLines().Should().BeEquivalentTo(expected);
  }

  public string YamlQuoted(string input)
    => $"'{input.Replace("'", "''")}'";

  protected abstract TAst NewBaseAst(TInput input);
  protected abstract IRendering AstToModel(TAst ast);

  void IModelBaseChecks<TInput>.Model_Expected(IRendering model, string[] expected) => Model_Expected(model, expected);
  AstBase IModelBaseChecks<TInput>.BaseAst(TInput input) => NewBaseAst(input);
  IRendering IModelBaseChecks<TInput>.ToModel(AstBase ast) => AstToModel((TAst)ast);
}

internal interface IModelBaseChecks<TInput>
{
  AstBase BaseAst(TInput input);
  IRendering ToModel(AstBase ast);

  void Model_Expected(IRendering model, string[] expected);
  string YamlQuoted(string input);
}
