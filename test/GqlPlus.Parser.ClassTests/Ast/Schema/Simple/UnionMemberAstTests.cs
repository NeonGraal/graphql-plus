namespace GqlPlus.Ast.Schema.Simple;

public class UnionMemberAstTests
  : AstNamedBaseTests<string>
{
  private readonly AstNamedChecks<UnionMemberAst> _checks
    = new(CreateMember, CloneMember);

  private static UnionMemberAst CloneMember(UnionMemberAst original, string input)
    => original with { Name = input };
  private static UnionMemberAst CreateMember(string input)
    => new(AstNulls.At, input, "");

  protected override Func<string, string, bool> SameInput
    => (name1, name2) => name1.Camelize() == name2.Camelize();

  internal override IAstNamedChecks<string> NamedChecks => _checks;
}
