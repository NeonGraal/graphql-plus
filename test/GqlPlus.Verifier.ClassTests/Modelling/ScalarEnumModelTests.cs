using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class ScalarEnumModelTests
  : ModelScalarTests<string, ScalarMemberAst>
{
  internal override IModelScalarChecks<string, ScalarMemberAst> ScalarChecks => _checks;

  private readonly ScalarEnumModelChecks _checks = new();
}

internal sealed class ScalarEnumModelChecks
  : ModelScalarChecks<string, ScalarMemberAst>
{
  public ScalarEnumModelChecks()
    : base(ScalarKind.Enum, new ScalarEnumModeller())
  { }

  protected override string[] ExpectedItem(string input, string exclude, string[] scalar)
    => ["- !_ScalarMember", exclude, "  kind: !_SimpleKind Enum", .. scalar, "  value: " + input];

  protected override ScalarMemberAst[]? ScalarItems(string[]? inputs)
    => inputs?.ScalarMembers();
}
