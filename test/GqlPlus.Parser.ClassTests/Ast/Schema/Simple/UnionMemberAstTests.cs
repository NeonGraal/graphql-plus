namespace GqlPlus.Ast.Schema.Simple;

public partial class UnionMemberAstTests
{
  [CheckTests(Inherited = true)]
  internal IAstNamedChecks<string> NamedChecks { get; }
    = new AstNamedChecks<UnionMemberAst>(CreateMember);

  [CheckTests]
  internal ICloneChecks<string> CloneChecks { get; } = new CloneChecks<string, UnionMemberAst>(
     CreateMember,
     (original, input) => original with { Name = input });

  private static UnionMemberAst CreateMember(string input)
    => new(AstNulls.At, input, input);
}
