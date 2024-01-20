using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public class ScalarNumberModelTests : ModelAliasedTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Extends(string name, string extends)
    => _checks.AstExpected(
      new(AstNulls.At, name, ScalarKind.Number, []) { Extends = extends },
      ["!_ScalarNumber",
        .. extends.TypeRefFor(SimpleKindModel.Scalar),
        "kind: !_TypeKind Scalar",
        "name: " + name,
        "scalar: !_ScalarKind Number"]);

  [Theory, RepeatData(Repeats)]
  public void Model_Members(string name)
    => _checks
    .RenderReturn("Parameters")
    .AstExpected(
      new(AstNulls.At, name, ScalarKind.Number, [] /* members.ScalarMembers() */),
      ["!_ScalarNumber",
        "kind: !_TypeKind Scalar",
        //"members:",
        //.. members.SelectMany(m => ExpectedMember(m, name)),
        "name: " + name,
        "scalar: !_ScalarKind Number"]);

  [Theory, RepeatData(Repeats)]
  public void Model_All(string name, string contents, string[] aliases, string extends)
    => _checks
    .RenderReturn("Parameters")
    .AstExpected(
      new(AstNulls.At, name, ScalarKind.Number, [] /* members.ScalarMembers() */) {
        Aliases = aliases,
        Description = contents,
        Extends = extends,
      },
      ["!_ScalarNumber",
        $"aliases: [{string.Join(", ", aliases)}]",
        "description: " + _checks.YamlQuoted(contents),
        .. extends.TypeRefFor(SimpleKindModel.Scalar),
        "kind: !_TypeKind Scalar",
        //"members:",
        //.. members.SelectMany(m => ExpectedMember(m, name)),
        "name: " + name,
        "scalar: !_ScalarKind Number"]);

  protected override string[] ExpectedDescriptionAliases(string input, string description, string aliases)
    => ["!_ScalarNumber",
      aliases,
      description,
      "kind: !_TypeKind Scalar",
      "name: " + input,
      "scalar: !_ScalarKind Number"];

  private string[] ExpectedMember(string member, string ofScalar)
    => ["- !_ScalarMember", "  scalar: " + ofScalar, "  name: " + member];

  internal override IModelAliasedChecks<string> AliasedChecks => _checks;

  private readonly ScalarNumberModelChecks _checks = new();
}

internal sealed class ScalarNumberModelChecks
  : ModelAliasedChecks<string, AstScalar<ScalarRangeNumberAst>>
{
  internal readonly IModeller<AstScalar<ScalarRangeNumberAst>> Scalar;

  public ScalarNumberModelChecks()
    => Scalar = new ScalarNumberModeller();

  protected override IRendering AstToModel(AstScalar<ScalarRangeNumberAst> aliased)
    => Scalar.ToRenderer(aliased);

  protected override AstScalar<ScalarRangeNumberAst> NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description, ScalarKind.Number);
}
