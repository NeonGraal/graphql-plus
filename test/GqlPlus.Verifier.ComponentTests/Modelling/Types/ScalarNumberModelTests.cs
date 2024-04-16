using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling.Types;

public class ScalarNumberModelTests(
  IScalarModeller<ScalarRangeAst, ScalarRangeModel> modeller
) : TestScalarModel<ScalarRangeInput, ScalarRangeAst>
{
  internal override ICheckScalarModel<ScalarRangeInput, ScalarRangeAst> ScalarChecks => _checks;

  private readonly ScalarNumberModelChecks _checks = new(modeller);
}

internal sealed class ScalarNumberModelChecks(
  IScalarModeller<ScalarRangeAst, ScalarRangeModel> modeller
) : CheckScalarModel<ScalarRangeInput, ScalarRangeAst, ScalarRangeModel>(ScalarDomain.Number, modeller)
{
  protected override string[] ExpectedItem(ScalarRangeInput input, string exclude, string[] scalar)
    => ["- !_ScalarRange", exclude, "  from: " + input.Lower, .. scalar, "  to: " + input.Upper];

  protected override ScalarRangeAst[]? ScalarItems(ScalarRangeInput[]? inputs)
    => inputs?.ScalarRanges();
}
