using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal sealed class SimpleModelChecks(
  IModeller<FieldKeyAst> simple
) : ModelBaseChecks<string, FieldKeyAst>
{
  protected override IRendering AstToModel(FieldKeyAst ast)
    => simple.ToRenderer(ast);
  protected override FieldKeyAst NewBaseAst(string input)
    => new(AstNulls.At, input);
}
