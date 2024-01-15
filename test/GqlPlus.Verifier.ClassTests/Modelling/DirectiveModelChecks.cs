using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal sealed class DirectiveModelChecks
  : ModelAliasedChecks<string, DirectiveDeclAst>
{
  internal readonly IModeller<DirectiveDeclAst> Directive;

  public DirectiveModelChecks()
    => Directive = new DirectiveModeller();

  protected override IRendering AstToModel(DirectiveDeclAst aliased)
    => Directive.ToRenderer(aliased);

  protected override DirectiveDeclAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description);
}
