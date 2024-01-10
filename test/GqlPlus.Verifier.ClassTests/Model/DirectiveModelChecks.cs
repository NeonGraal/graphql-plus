using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;

internal sealed class DirectiveModelChecks : ModelBaseChecks<DirectiveModel>
{
  internal void Directive_Expected(DirectiveDeclAst directive, string expected)
    => Model_Expected(directive.ToModel(), expected);
}
