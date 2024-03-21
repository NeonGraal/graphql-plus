﻿using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class ScalarNumberModelTests
  : TestScalarModel<ScalarRangeInput, ScalarRangeAst>
{
  internal override ICheckScalarModel<ScalarRangeInput, ScalarRangeAst> ScalarChecks => _checks;

  private readonly ScalarNumberModelChecks _checks = new();
}

internal sealed class ScalarNumberModelChecks
  : CheckScalarModel<ScalarRangeInput, ScalarRangeAst, ScalarRangeModel>
{
  public ScalarNumberModelChecks()
    : base(ScalarDomain.Number, new ScalarNumberModeller())
  { }

  protected override string[] ExpectedItem(ScalarRangeInput input, string exclude, string[] scalar)
    => ["- !_ScalarRange", exclude, "  from: " + input.Lower, .. scalar, "  to: " + input.Upper];

  protected override ScalarRangeAst[]? ScalarItems(ScalarRangeInput[]? inputs)
    => inputs?.ScalarRanges();
}
