using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal sealed class ConstantModelChecks(
  IModeller<ConstantAst> constant
) : ModelBaseChecks<string, ConstantAst>
{
  protected override IRendering AstToModel(ConstantAst ast)
    => constant.ToRenderer(ast);
  protected override ConstantAst NewBaseAst(string input)
    => new FieldKeyAst(AstNulls.At, input);
}
