using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Model;

internal sealed class ConstantModelChecks
  : ModelBaseChecks<string, ConstantAst>
{
  protected override IRendering AstToModel(ConstantAst ast)
    => ast.ToModel();
  protected override ConstantAst NewBaseAst(string input)
    => new FieldKeyAst(AstNulls.At, input);
}
