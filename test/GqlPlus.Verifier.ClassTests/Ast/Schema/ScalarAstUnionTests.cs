namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarAstUnionTests
  : AstScalarTests<string, ScalarReferenceAst>
{
  protected override string MembersString(string name, string input)
    => $"( !S {name} Union !ST {input} )";
  protected override AstScalar<ScalarReferenceAst> NewScalar(string name, ScalarReferenceAst[] list)
    => new(AstNulls.At, name, ScalarKind.Union, list);
  protected override ScalarReferenceAst[] ScalarMembers(string input)
    => [new(AstNulls.At, input)];
}
