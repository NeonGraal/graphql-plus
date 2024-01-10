using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;

internal sealed class DirectiveModelChecks : ModelAliasedChecks<DirectiveDeclAst>
{
  protected override IRendering AstToModel(DirectiveDeclAst aliased)
    => aliased.ToModel();

  protected override DirectiveDeclAst NewAliasedAst(string input)
    => new(AstNulls.At, input);

  internal static void Directive_Expected(DirectiveDeclAst directive, string[] expected)
    => Model_Expected(directive.ToModel(), expected);
}
