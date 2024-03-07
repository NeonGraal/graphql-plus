using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public class ScalarBooleanModelTests
  : TestScalarModel<bool, ScalarTrueFalseAst>
{
  internal override ICheckScalarModel<bool, ScalarTrueFalseAst> ScalarChecks => _checks;

  private readonly ScalarBooleanModelChecks _checks = new();
}

internal sealed class ScalarBooleanModelChecks
  : CheckScalarModel<bool, ScalarTrueFalseAst, ScalarTrueFalseModel>
{
  public ScalarBooleanModelChecks()
    : base(ScalarKind.Boolean, new ScalarBooleanModeller())
  { }

  protected override string[] ExpectedItem(bool input, string exclude, string[] scalar)
    => ["- !_ScalarTrueFalse", exclude, .. scalar, "  value: " + input.TrueFalse()];

  protected override ScalarTrueFalseAst[]? ScalarItems(bool[]? inputs)
    => inputs?.ScalarTrueFalses();
}
