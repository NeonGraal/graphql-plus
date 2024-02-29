namespace GqlPlus.Verifier.Ast.Operation;

public class DirectiveAstTests : AstAbbreviatedTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithArgument(string variable, string name)
    => _checks.HashCode(
      () => new DirectiveAst(AstNulls.At, name) { Argument = new ArgumentAst(AstNulls.At, variable) });

  [Theory, RepeatData(Repeats)]
  public void String_WithArgument(string variable, string name)
    => _checks.Text(
      () => new DirectiveAst(AstNulls.At, name) { Argument = new ArgumentAst(AstNulls.At, variable) },
      $"( !d {name} ( !a ${variable} ) )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithArgument(string variable, string name)
    => _checks.Equality(
      () => new DirectiveAst(AstNulls.At, name) { Argument = new ArgumentAst(AstNulls.At, variable) });

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithArgument(string variable, string name)
    => _checks.InequalityWith(name,
      () => new DirectiveAst(AstNulls.At, name) { Argument = new ArgumentAst(AstNulls.At, variable) });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenArguments(string variable1, string variable2, string name)
    => _checks.InequalityBetween(variable1, variable2,
      variable => new DirectiveAst(AstNulls.At, name) { Argument = new ArgumentAst(AstNulls.At, variable) },
      variable1 == variable2);

  private readonly AstAbbreviatedChecks<DirectiveAst> _checks = new(name => new DirectiveAst(AstNulls.At, name));

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
