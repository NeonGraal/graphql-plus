using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class ScalarEnumModelTests
  : TestScalarModel<string, ScalarMemberAst>
{
  internal override ICheckScalarModel<string, ScalarMemberAst> ScalarChecks => _checks;

  private readonly ScalarEnumModelChecks _checks = new();
}

internal sealed class ScalarEnumModelChecks
  : CheckScalarModel<string, ScalarMemberAst, ScalarMemberModel>
{
  public ScalarEnumModelChecks()
    : base(ScalarDomain.Enum, new ScalarEnumModeller())
  { }

  protected override string[] ExpectedItem(string input, string exclude, string[] scalar)
    => ["- !_ScalarMember", exclude, "  kind: !_SimpleKind Enum", .. scalar, "  value: " + input];

  protected override ScalarMemberAst[]? ScalarItems(string[]? inputs)
    => inputs?.ScalarMembers();
}
