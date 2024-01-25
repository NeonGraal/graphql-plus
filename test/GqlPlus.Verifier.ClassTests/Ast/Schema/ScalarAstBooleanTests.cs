
namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarAstBooleanTests
  : AstScalarTests<bool, ScalarFalseAst>
{
  protected override string MembersString(string name, bool input)
    => $"( !S {name} Boolean {BoolString(input)})";
  private static object BoolString(bool input)
    => input ? "!SF " : "";
  protected override AstScalar<ScalarFalseAst> NewScalar(string name, ScalarFalseAst[] list)
    => new(AstNulls.At, name, ScalarKind.Boolean, list);
  protected override ScalarFalseAst[] ScalarMembers(bool input)
    => input ? [new(AstNulls.At)] : [];
}
