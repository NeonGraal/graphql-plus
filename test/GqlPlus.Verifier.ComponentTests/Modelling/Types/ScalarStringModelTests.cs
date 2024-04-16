using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling.Types;

public class ScalarStringModelTests(
  IScalarModeller<ScalarRegexAst, ScalarRegexModel> modeller
) : TestScalarModel<string, ScalarRegexAst>
{
  internal override ICheckScalarModel<string, ScalarRegexAst> ScalarChecks => _checks;

  private readonly ScalarStringModelChecks _checks = new(modeller);
}

internal sealed class ScalarStringModelChecks(
  IScalarModeller<ScalarRegexAst, ScalarRegexModel> modeller
) : CheckScalarModel<string, ScalarRegexAst, ScalarRegexModel>(ScalarDomain.String, modeller)
{
  protected override string[] ExpectedItem(string input, string exclude, string[] scalar)
    => ["- !_ScalarRegex", exclude, "  regex: " + input, .. scalar];

  protected override ScalarRegexAst[]? ScalarItems(string[]? inputs)
    => inputs?.ScalarRegexes();
}
