
namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarAstBooleanTests
  : AstScalarTests<bool, ScalarFalseAst>
{
  protected override string MembersString(string name, bool input)
    => $"( !S {name} Boolean !SF {input} )";
  protected override AstScalar<ScalarFalseAst> NewScalar(string name, ScalarFalseAst[] list)
    => new(AstNulls.At, name, ScalarKind.Boolean, list);
  protected override ScalarFalseAst[] ScalarMembers(bool input)
    => [new(AstNulls.At, input)];
}
