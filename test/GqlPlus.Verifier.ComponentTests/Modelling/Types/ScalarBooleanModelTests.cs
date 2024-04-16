using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling.Types;

public class ScalarBooleanModelTests(
  IScalarModeller<ScalarTrueFalseAst, ScalarTrueFalseModel> modeller
) : TestScalarModel<bool, ScalarTrueFalseAst>
{
  internal override ICheckScalarModel<bool, ScalarTrueFalseAst> ScalarChecks => _checks;

  private readonly ScalarBooleanModelChecks _checks = new(modeller);
}

internal sealed class ScalarBooleanModelChecks(
  IScalarModeller<ScalarTrueFalseAst, ScalarTrueFalseModel> modeller
) : CheckScalarModel<bool, ScalarTrueFalseAst, ScalarTrueFalseModel>(ScalarDomain.Boolean, modeller)
{
  protected override string[] ExpectedItem(bool input, string exclude, string[] scalar)
    => ["- !_ScalarTrueFalse", exclude, .. scalar, "  value: " + input.TrueFalse()];

  protected override ScalarTrueFalseAst[]? ScalarItems(bool[]? inputs)
    => inputs?.ScalarTrueFalses();
}
