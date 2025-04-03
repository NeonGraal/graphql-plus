using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Schema.Simple;

public class EnumLabelAstTests
  : AstAliasedTests
{
  private readonly AstAliasedChecks<EnumLabelAst> _checks
    = new(name => new EnumLabelAst(AstNulls.At, name));

  internal override IAstAliasedChecks<string> AliasedChecks => _checks;

  protected override Func<string, string, bool> SameInput
    => (name1, name2) => name1.Camelize() == name2.Camelize();
}
