namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarAstUnionTests
  : AstScalarTests<ScalarReferenceInput, ScalarReferenceAst>
{
  protected override string MembersString(string name, ScalarReferenceInput input)
    => $"( !S {name} Union {input.Types.Joined("!ST ")} )";
  protected override AstScalar<ScalarReferenceAst> NewScalar(string name, ScalarReferenceAst[] list)
    => new(AstNulls.At, name, ScalarKind.Union, list);
  protected override ScalarReferenceAst[] ScalarMembers(ScalarReferenceInput input)
    => [.. input.Types.Select(t => new ScalarReferenceAst(AstNulls.At, t))];
}

public record struct ScalarReferenceInput(string[] Types);
