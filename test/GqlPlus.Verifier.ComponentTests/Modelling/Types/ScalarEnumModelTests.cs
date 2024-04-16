using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling.Types;

public class ScalarEnumModelTests(
  IScalarModeller<ScalarMemberAst, ScalarMemberModel> modeller
) : TestScalarModel<string, ScalarMemberAst>
{
  internal override ICheckScalarModel<string, ScalarMemberAst> ScalarChecks => _checks;

  private readonly ScalarEnumModelChecks _checks = new(modeller);
}

internal sealed class ScalarEnumModelChecks(
  IScalarModeller<ScalarMemberAst, ScalarMemberModel> modeller
) : CheckScalarModel<string, ScalarMemberAst, ScalarMemberModel>(ScalarDomain.Enum, modeller)
{
  protected override string[] ExpectedItem(string input, string exclude, string[] scalar)
    => ["- !_ScalarMember", exclude, "  kind: !_SimpleKind Enum", .. scalar, "  value: " + input];

  protected override ScalarMemberAst[]? ScalarItems(string[]? inputs)
    => inputs?.ScalarMembers();
}
