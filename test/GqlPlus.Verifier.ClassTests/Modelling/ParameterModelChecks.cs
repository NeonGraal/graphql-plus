using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal sealed class ParameterModelChecks
  : ModelDescribedChecks<string, ParameterAst>
{
  internal readonly IModeller<ParameterAst> Parameter;
  internal readonly IModeller<ModifierAst> Modifier;

  public ParameterModelChecks()
    => Parameter = new ParameterModeller(
      Modifier = ForModeller<ModifierAst, ModifierModel>(
        m => new(m.Kind)));

  protected override IRendering AstToModel(ParameterAst ast)
    => Parameter.ToRenderer(ast);

  protected override ParameterAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description);
}
