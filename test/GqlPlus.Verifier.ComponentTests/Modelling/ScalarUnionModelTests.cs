using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class ScalarUnionModelTests
    : ScalarModelTests<string, ScalarReferenceAst>
{
  internal override IScalarModelChecks<string, ScalarReferenceAst> ScalarChecks => _checks;

  private readonly ScalarUnionModelChecks _checks = new();
}

internal sealed class ScalarUnionModelChecks
  : ScalarModelChecks<string, ScalarReferenceAst, TypeSimpleModel>
{
  public ScalarUnionModelChecks()
    : base(ScalarKind.Union, new ScalarUnionModeller())
  { }

  protected override string[] ExpectedItem(string input, string exclude, string[] scalar)
    => ["- !_TypeSimple", "  kind: !_SimpleKind Basic", "  name: " + input, .. scalar];

  protected override ScalarReferenceAst[]? ScalarItems(string[]? inputs)
    => inputs?.ScalarReferences();
}
