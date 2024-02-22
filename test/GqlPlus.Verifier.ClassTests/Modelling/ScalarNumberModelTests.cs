using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public class ScalarNumberModelTests
  : ModelScalarTests<ScalarRangeInput>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Parent(string name, string parent)
    => _checks.AstExpected(
      new(AstNulls.At, name, ScalarKind.Number, []) { Parent = parent },
      ["!_ScalarNumber",
        .. parent.TypeRefFor(SimpleKindModel.Scalar),
        "kind: !_TypeKind Scalar",
        "name: " + name,
        "scalar: !_ScalarKind Number"]);

  [Theory, RepeatData(Repeats)]
  public void Model_Members(string name, ScalarRangeInput[] ranges)
    => _checks
    .AstExpected(
      new(AstNulls.At, name, ScalarKind.Number, ranges.ScalarRanges()),
      ["!_ScalarNumber",
        .. AllItems(ranges, name),
        .. Items(ranges),
        "kind: !_TypeKind Scalar",
        "name: " + name,
        "scalar: !_ScalarKind Number"]);

  [Theory, RepeatData(Repeats)]
  public void Model_All(string name, string contents, string[] aliases, string parent, ScalarRangeInput[] ranges)
    => _checks
    .AstExpected(
      new(AstNulls.At, name, ScalarKind.Number, ranges.ScalarRanges()) {
        Aliases = aliases,
        Description = contents,
        Parent = parent,
      },
      ["!_ScalarNumber",
        $"aliases: [{string.Join(", ", aliases)}]",
        .. AllItems(ranges, name),
        "description: " + _checks.YamlQuoted(contents),
        .. parent.TypeRefFor(SimpleKindModel.Scalar),
        .. Items(ranges),
        "kind: !_TypeKind Scalar",
        "name: " + name,
        "scalar: !_ScalarKind Number"]);

  protected override string[] ExpectedDescriptionAliases(string input, string description, string aliases)
    => ["!_ScalarNumber",
      aliases,
      description,
      "kind: !_TypeKind Scalar",
      "name: " + input,
      "scalar: !_ScalarKind Number"];

  protected override string[] ExpectedItem(ScalarRangeInput input, string exclude, string[] scalar)
    => ["- !_ScalarRange", exclude, "  from: " + input.Lower, .. scalar, "  to: " + input.Upper];

  internal override IModelAliasedChecks<string> AliasedChecks => _checks;

  private readonly ScalarNumberModelChecks _checks = new();
}

internal sealed class ScalarNumberModelChecks
  : ModelAliasedChecks<string, AstScalar<ScalarRangeAst>>
{
  internal readonly IModeller<AstScalar<ScalarRangeAst>> Scalar;

  public ScalarNumberModelChecks()
    => Scalar = new ScalarNumberModeller();

  protected override IRendering AstToModel(AstScalar<ScalarRangeAst> aliased)
    => Scalar.ToRenderer(aliased);

  protected override AstScalar<ScalarRangeAst> NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description, ScalarKind.Number);
}
