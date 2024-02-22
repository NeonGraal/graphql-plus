using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class ScalarNumberModelTests
  : ModelScalarTests<ScalarRangeInput, ScalarRangeAst>
{
  internal override IModelScalarChecks<ScalarRangeInput, ScalarRangeAst> ScalarChecks => _checks;

  private readonly ScalarNumberModelChecks _checks = new();
}

internal sealed class ScalarNumberModelChecks
  : ModelScalarChecks<ScalarRangeInput, ScalarRangeAst>
{
  public ScalarNumberModelChecks()
    : base(ScalarKind.Number, new ScalarNumberModeller())
  { }

  protected override string[] ExpectedItem(ScalarRangeInput input, string exclude, string[] scalar)
    => ["- !_ScalarRange", exclude, "  from: " + input.Lower, .. scalar, "  to: " + input.Upper];

  protected override ScalarRangeAst[]? ScalarItems(ScalarRangeInput[]? inputs)
    => inputs?.ScalarRanges();
}
