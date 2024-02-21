using System;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public class ScalarNumberModelTests : ModelAliasedTests<string>
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
    .RenderReturn("Parameters")
    .AstExpected(
      new(AstNulls.At, name, ScalarKind.Number, [.. ranges.SelectMany(r => r.ScalarRange())]),
      ["!_ScalarNumber",
        "allItems:",
        .. ranges.SelectMany(ExpectedAllRange(name)),
        "items:",
        .. ranges.SelectMany(ExpectedRange),
        "kind: !_TypeKind Scalar",
        "name: " + name,
        "scalar: !_ScalarKind Number"]);

  [Theory, RepeatData(Repeats)]
  public void Model_All(string name, string contents, string[] aliases, string parent, ScalarRangeInput[] ranges)
    => _checks
    .RenderReturn("Parameters")
    .AstExpected(
      new(AstNulls.At, name, ScalarKind.Number, [.. ranges.SelectMany(r => r.ScalarRange())]) {
        Aliases = aliases,
        Description = contents,
        Parent = parent,
      },
      ["!_ScalarNumber",
        $"aliases: [{string.Join(", ", aliases)}]",
        "allItems:",
        .. ranges.SelectMany(ExpectedAllRange(name)),
        "description: " + _checks.YamlQuoted(contents),
        .. parent.TypeRefFor(SimpleKindModel.Scalar),
        "items:",
        .. ranges.SelectMany(ExpectedRange),
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

  private string[] ExpectedRange(ScalarRangeInput range)
    => ["- !_ScalarRange", "  exclude: false", "  from: " + range.Lower, "  to: " + range.Upper];

  private Func<ScalarRangeInput, string[]> ExpectedAllRange(string ofScalar)
    => range => ["- !_ScalarItem(_ScalarRange)", "  exclude: false", "  from: " + range.Lower, "  scalar: " + ofScalar, "  to: " + range.Upper];

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
