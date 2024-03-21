namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarAstStringTests
  : AstScalarTests<string, ScalarRegexAst>
{
  protected override string MembersString(string name, string input)
    => $"( !S {name} String !SX /{input}/ )";
  protected override AstScalar<ScalarRegexAst> NewScalar(string name, ScalarRegexAst[] list)
    => new(AstNulls.At, name, ScalarDomain.String, list);
  protected override ScalarRegexAst[] ScalarMembers(string input)
    => [new(AstNulls.At, false, input)];
}
