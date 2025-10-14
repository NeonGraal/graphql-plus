namespace GqlPlus.Ast.Schema.Simple;

public class UnionMemberAstTests
  : AstNamedTests
{
  private readonly AstNamedChecks<UnionMemberAst> _checks
    = new(name => new UnionMemberAst(AstNulls.At, name, ""));

  protected override Func<string, string, bool> SameInput
    => (name1, name2) => name1.Camelize() == name2.Camelize();

  internal override IAstNamedChecks<string> NamedChecks => _checks;
}
