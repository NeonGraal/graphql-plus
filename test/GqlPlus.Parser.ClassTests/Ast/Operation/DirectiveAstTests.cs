
namespace GqlPlus.Ast.Operation;

[CheckTestsFor(nameof(Checks))]
[CheckTestsFor(nameof(CloneChecks))]
public partial class DirectiveAstTests
{
  private IDirectiveAstChecks Checks { get; } = new DirectiveAstChecks();
  private ICloneChecks<string> CloneChecks { get; } = new CloneChecks<string, DirectiveAst>(
    DirectiveAstChecks.CreateDirective, CloneDirective);

  private static DirectiveAst CloneDirective(DirectiveAst original, string input)
    => original with { Identifier = input };
}

internal sealed class DirectiveAstChecks()
  : AstAbbreviatedChecks<DirectiveAst>(CreateDirective)
  , IDirectiveAstChecks
{
  public void HashCode_WithArg(string variable, string name)
    => HashCode(DirectiveWithArgFactory(variable, name));

  public void Text_WithArg(string variable, string name)
    => Text(DirectiveWithArgFactory(variable, name),
      $"( !d {name} ( !a ${variable} ) )");

  public void Equality_WithArg(string variable, string name)
    => Equality(DirectiveWithArgFactory(variable, name));

  public void Inequality_WithArg(string variable, string name)
    => InequalityWith(name, DirectiveWithArgFactory(variable, name));
  public void Inequality_BetweenArgs(string variable1, string variable2, string name)
    => InequalityBetween(variable1, variable2,
      variable => DirectiveWithArgFactory(variable, name)(),
      variable1 == variable2);

  private static AstCreator DirectiveWithArgFactory(string variable, string name)
    => () => new DirectiveAst(AstNulls.At, name) { Arg = new ArgAst(AstNulls.At, variable) };

  internal static DirectiveAst CreateDirective(string input)
     => new(AstNulls.At, input);
}

internal interface IDirectiveAstChecks
{
  void HashCode_WithArg(string variable, string name);
  void Text_WithArg(string variable, string name);
  void Equality_WithArg(string variable, string name);
  void Inequality_WithArg(string variable, string name);
  void Inequality_BetweenArgs(string variable1, string variable2, string name);
}
