using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;

internal sealed class ParameterModelChecks : ModelDescribedChecks<string, ParameterAst>
{
  protected override IRendering AstToModel(ParameterAst ast)
    => ast.ToModel();

  protected override ParameterAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description);
}
