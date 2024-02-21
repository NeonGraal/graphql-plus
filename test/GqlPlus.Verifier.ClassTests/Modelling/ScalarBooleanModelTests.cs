using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public class ScalarBooleanModelTests : ModelAliasedTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Parent(string name, string parent)
    => _checks.AstExpected(
      new(AstNulls.At, name, ScalarKind.Boolean, []) { Parent = parent },
      ["!_ScalarBoolean",
        .. parent.TypeRefFor(SimpleKindModel.Scalar),
        "kind: !_TypeKind Scalar",
        "name: " + name,
        "scalar: !_ScalarKind Boolean"]);

  [Theory, RepeatData(Repeats)]
  public void Model_Members(string name, bool[] members)
    => _checks
    .AstExpected(
      new(AstNulls.At, name, ScalarKind.Boolean, members.ScalarTrueFalses()),
      ["!_ScalarBoolean",
        "items:",
        .. members.SelectMany(m => ExpectedItem(m, name)),
        "kind: !_TypeKind Scalar",
        "name: " + name,
        "scalar: !_ScalarKind Boolean"]);

  [Theory, RepeatData(Repeats)]
  public void Model_All(string name, string contents, string[] aliases, string parent, bool[] members)
    => _checks
    .AstExpected(
      new(AstNulls.At, name, ScalarKind.Boolean, members.ScalarTrueFalses()) {
        Aliases = aliases,
        Description = contents,
        Parent = parent,
      },
      ["!_ScalarBoolean",
        $"aliases: [{string.Join(", ", aliases)}]",
        "description: " + _checks.YamlQuoted(contents),
        .. parent.TypeRefFor(SimpleKindModel.Scalar),
        "items:",
        .. members.SelectMany(m => ExpectedItem(m, name)),
        "kind: !_TypeKind Scalar",
        "name: " + name,
        "scalar: !_ScalarKind Boolean"]);

  protected override string[] ExpectedDescriptionAliases(string input, string description, string aliases)
    => ["!_ScalarBoolean",
      aliases,
      description,
      "kind: !_TypeKind Scalar",
      "name: " + input,
      "scalar: !_ScalarKind Boolean"];

  private string[] ExpectedItem(bool value, string ofScalar)
    => ["- !_ScalarTrueFalse", "  exclude: false", "  scalar: " + ofScalar, "  value: " + value.TrueFalse()];

  internal override IModelAliasedChecks<string> AliasedChecks => _checks;

  private readonly ScalarBooleanModelChecks _checks = new();
}

internal sealed class ScalarBooleanModelChecks
  : ModelAliasedChecks<string, AstScalar<ScalarTrueFalseAst>>
{
  internal readonly IModeller<AstScalar<ScalarTrueFalseAst>> Scalar;

  public ScalarBooleanModelChecks()
    => Scalar = new ScalarBooleanModeller();

  protected override IRendering AstToModel(AstScalar<ScalarTrueFalseAst> aliased)
    => Scalar.ToRenderer(aliased);

  protected override AstScalar<ScalarTrueFalseAst> NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description, ScalarKind.Boolean);
}
