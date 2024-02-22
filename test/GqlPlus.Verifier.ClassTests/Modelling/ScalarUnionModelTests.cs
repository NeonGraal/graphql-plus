using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class ScalarUnionModelTests
    : ModelScalarTests<string, ScalarReferenceAst>
{
  internal override IModelScalarChecks<string, ScalarReferenceAst> ScalarChecks => _checks;

  private readonly ScalarUnionModelChecks _checks = new();
}

internal sealed class ScalarUnionModelChecks
  : ModelScalarChecks<string, ScalarReferenceAst>
{
  public ScalarUnionModelChecks()
    : base(ScalarKind.Union, new ScalarUnionModeller())
  { }

  protected override string[] ExpectedItem(string input, string exclude, string[] scalar)
    => ["- !_TypeRef(_SimpleKind)", "  kind: !_SimpleKind Basic", "  name: " + input, .. scalar];

  protected override ScalarReferenceAst[]? ScalarItems(string[]? inputs)
    => inputs?.ScalarReferences();
}
