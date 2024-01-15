using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal sealed class ConstantModelChecks
  : ModelBaseChecks<string, ConstantAst>
{
  internal readonly IModeller<ConstantAst> Constant;
  internal readonly IModeller<FieldKeyAst> Simple;

  public ConstantModelChecks()
    => Constant = new ConstantModeller(
      Simple = ForModeller<FieldKeyAst, SimpleModel>(
        k => new(k.Value ?? k.String!)));

  protected override IRendering AstToModel(ConstantAst ast)
    => Constant.ToRenderer(ast);
  protected override ConstantAst NewBaseAst(string input)
    => new FieldKeyAst(AstNulls.At, input);
}
