using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class ScalarUnionModelTests
    : TestScalarModel<string, ScalarReferenceAst>
{
  [Theory, RepeatData(Repeats)]
  public void Model_MembersEnum(string name, string[] members)
    => _checks
    .SetKind(TypeKindModel.Enum)
    .AddTypeKinds(members, TypeKindModel.Enum)
    .ScalarExpected(
      ScalarChecks.ScalarAst(name, members),
      ScalarChecks.ExpectedScalar(new(name, items: members)));

  [Theory, RepeatData(Repeats)]
  public void Model_MembersScalar(string name, string[] members)
    => _checks
    .SetKind(TypeKindModel.Scalar)
    .AddTypeKinds(members, TypeKindModel.Scalar)
    .ScalarExpected(
      ScalarChecks.ScalarAst(name, members),
      ScalarChecks.ExpectedScalar(new(name, items: members)));

  internal override ICheckScalarModel<string, ScalarReferenceAst> ScalarChecks => _checks;

  private readonly ScalarUnionModelChecks _checks = new();
}

internal sealed class ScalarUnionModelChecks
  : CheckScalarModel<string, ScalarReferenceAst, TypeSimpleModel>
{
  private TypeKindModel _kind = TypeKindModel.Basic;

  public ScalarUnionModelChecks()
    : base(ScalarKind.Union, new ScalarUnionModeller())
  { }

  public ICheckScalarModel<string, ScalarReferenceAst> SetKind(TypeKindModel kind)
  {
    _kind = kind;
    return this;
  }

  protected override string[] ExpectedItem(string input, string exclude, string[] scalar)
    => ["- !_TypeSimple", $"  kind: !_SimpleKind {_kind}", "  name: " + input, .. scalar];

  protected override ScalarReferenceAst[]? ScalarItems(string[]? inputs)
    => inputs?.ScalarReferences();
}
