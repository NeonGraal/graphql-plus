using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class ScalarStringModelTests
  : ModelScalarTests<string, ScalarRegexAst>
{
  internal override IModelScalarChecks<string, ScalarRegexAst> ScalarChecks => _checks;

  private readonly ScalarStringModelChecks _checks = new();
}

internal sealed class ScalarStringModelChecks
  : ModelScalarChecks<string, ScalarRegexAst>
{
  public ScalarStringModelChecks()
    : base(ScalarKind.String, new ScalarStringModeller())
  { }

  protected override string[] ExpectedItem(string input, string exclude, string[] scalar)
    => ["- !_ScalarRegex", exclude, "  regex: " + input, .. scalar];

  protected override ScalarRegexAst[]? ScalarItems(string[]? inputs)
    => inputs?.ScalarRegexes();
}
