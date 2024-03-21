using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class ScalarStringModelTests
  : TestScalarModel<string, ScalarRegexAst>
{
  internal override ICheckScalarModel<string, ScalarRegexAst> ScalarChecks => _checks;

  private readonly ScalarStringModelChecks _checks = new();
}

internal sealed class ScalarStringModelChecks
  : CheckScalarModel<string, ScalarRegexAst, ScalarRegexModel>
{
  public ScalarStringModelChecks()
    : base(ScalarDomain.String, new ScalarStringModeller())
  { }

  protected override string[] ExpectedItem(string input, string exclude, string[] scalar)
    => ["- !_ScalarRegex", exclude, "  regex: " + input, .. scalar];

  protected override ScalarRegexAst[]? ScalarItems(string[]? inputs)
    => inputs?.ScalarRegexes();
}
