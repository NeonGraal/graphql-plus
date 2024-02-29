using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class ScalarEnumModelTests
  : ScalarModelTests<string, ScalarMemberAst>
{
  internal override IScalarModelChecks<string, ScalarMemberAst> ScalarChecks => _checks;

  private readonly ScalarEnumModelChecks _checks = new();
}

internal sealed class ScalarEnumModelChecks
  : ScalarModelChecks<string, ScalarMemberAst, ScalarMemberModel>
{
  public ScalarEnumModelChecks()
    : base(ScalarKind.Enum, new ScalarEnumModeller())
  { }

  protected override string[] ExpectedItem(string input, string exclude, string[] scalar)
    => ["- !_ScalarMember", exclude, "  kind: !_SimpleKind Enum", .. scalar, "  value: " + input];

  protected override ScalarMemberAst[]? ScalarItems(string[]? inputs)
    => inputs?.ScalarMembers();
}
