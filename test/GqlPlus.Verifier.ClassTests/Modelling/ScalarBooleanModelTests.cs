using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public class ScalarBooleanModelTests
  : ModelScalarTests<bool, ScalarTrueFalseAst>
{
  internal override IModelScalarChecks<bool, ScalarTrueFalseAst> ScalarChecks => _checks;

  private readonly ScalarBooleanModelChecks _checks = new();
}

internal sealed class ScalarBooleanModelChecks
  : ModelScalarChecks<bool, ScalarTrueFalseAst>
{
  public ScalarBooleanModelChecks()
    : base(ScalarKind.Boolean, new ScalarBooleanModeller())
  { }

  protected override string[] ExpectedItem(bool input, string exclude, string[] scalar)
    => ["- !_ScalarTrueFalse", exclude, .. scalar, "  value: " + input.TrueFalse()];

  protected override ScalarTrueFalseAst[]? ScalarItems(bool[]? inputs)
    => inputs?.ScalarTrueFalses();
}
