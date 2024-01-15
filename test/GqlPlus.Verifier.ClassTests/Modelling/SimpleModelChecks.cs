using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal sealed class SimpleModelChecks
  : ModelBaseChecks<string, FieldKeyAst>
{
  internal readonly IModeller<FieldKeyAst> Simple;

  public SimpleModelChecks()
    => Simple = new SimpleModeller();

  protected override IRendering AstToModel(FieldKeyAst ast)
    => Simple.ToRenderer(ast);
  protected override FieldKeyAst NewBaseAst(string input)
    => new(AstNulls.At, input);
}
