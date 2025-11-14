namespace GqlPlus.Ast.Schema.Simple;

public class EnumLabelAstTests
  : AstAliasedBaseTests
{
  private readonly AstAliasedChecks<EnumLabelAst> _checks
    = new(CreateLabel, CloneLabel);

  private static EnumLabelAst CloneLabel(EnumLabelAst original, string input)
    => original with { Name = input };
  private static EnumLabelAst CreateLabel(string input)
    => new(AstNulls.At, input);

  internal override IAstAliasedChecks<string> AliasedChecks => _checks;

  protected override Func<string, string, bool> SameInput
    => (name1, name2) => name1.Camelize() == name2.Camelize();
}
