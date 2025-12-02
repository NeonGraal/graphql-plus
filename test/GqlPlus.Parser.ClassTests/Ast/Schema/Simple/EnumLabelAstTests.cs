namespace GqlPlus.Ast.Schema.Simple;

public partial class EnumLabelAstTests
{
  [CheckTests(Inherited = true)]
  internal IAstAliasedChecks<string> AliasedChecks { get; }
    = new AstAliasedChecks<EnumLabelAst>(CreateLabel);

  [CheckTests]
  internal ICloneChecks<string> CloneChecks { get; } = new CloneChecks<string, EnumLabelAst>(
     CreateLabel,
     (original, input) => original with { Name = input });

  private static EnumLabelAst CreateLabel(string input)
    => new(AstNulls.At, input);
}
