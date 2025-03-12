using GqlPlus.Ast;
using GqlPlus.Ast.Operation;

namespace GqlPlus.Operation;

public class DirectiveAstTests : AstAbbreviatedTests
{
  [Theory, RepeatData]
  public void HashCode_WithArg(string variable, string name)
    => _checks.HashCode(
      () => new DirectiveAst(AstNulls.At, name) { Arg = new ArgAst(AstNulls.At, variable) });

  [Theory, RepeatData]
  public void String_WithArg(string variable, string name)
    => _checks.Text(
      () => new DirectiveAst(AstNulls.At, name) { Arg = new ArgAst(AstNulls.At, variable) },
      $"( !d {name} ( !a ${variable} ) )");

  [Theory, RepeatData]
  public void Equality_WithArg(string variable, string name)
    => _checks.Equality(
      () => new DirectiveAst(AstNulls.At, name) { Arg = new ArgAst(AstNulls.At, variable) });

  [Theory, RepeatData]
  public void Inequality_WithArg(string variable, string name)
    => _checks.InequalityWith(name,
      () => new DirectiveAst(AstNulls.At, name) { Arg = new ArgAst(AstNulls.At, variable) });

  [Theory, RepeatData]
  public void Inequality_BetweenArgs(string variable1, string variable2, string name)
    => _checks.InequalityBetween(variable1, variable2,
      variable => new DirectiveAst(AstNulls.At, name) { Arg = new ArgAst(AstNulls.At, variable) },
      variable1 == variable2);

  private readonly AstAbbreviatedChecks<DirectiveAst> _checks = new(name => new DirectiveAst(AstNulls.At, name));

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
