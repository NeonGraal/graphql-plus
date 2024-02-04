using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public class ScalarStringModelTests : ModelAliasedTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Parent(string name, string parent)
    => _checks.AstExpected(
      new(AstNulls.At, name, ScalarKind.String, []) { Parent = parent },
      ["!_ScalarString",
        .. parent.TypeRefFor(SimpleKindModel.Scalar),
        "kind: !_TypeKind Scalar",
        "name: " + name,
        "scalar: !_ScalarKind String"]);

  [Theory, RepeatData(Repeats)]
  public void Model_Members(string name)
    => _checks
    .RenderReturn("Parameters")
    .AstExpected(
      new(AstNulls.At, name, ScalarKind.String, [] /* Members = members.ScalarMembers() */),
      ["!_ScalarString",
        "kind: !_TypeKind Scalar",
        //"members:",
        //.. members.SelectMany(m => ExpectedMember(m, name)),
        "name: " + name,
        "scalar: !_ScalarKind String"]);

  [Theory, RepeatData(Repeats)]
  public void Model_All(string name, string contents, string[] aliases, string parent)
    => _checks
    .RenderReturn("Parameters")
    .AstExpected(
      new(AstNulls.At, name, ScalarKind.String, [] /* Members = members.ScalarMembers() */) {
        Aliases = aliases,
        Description = contents,
        Parent = parent,
      },
      ["!_ScalarString",
        $"aliases: [{string.Join(", ", aliases)}]",
        "description: " + _checks.YamlQuoted(contents),
        .. parent.TypeRefFor(SimpleKindModel.Scalar),
        "kind: !_TypeKind Scalar",
        //"members:",
        //.. members.SelectMany(m => ExpectedMember(m, name)),
        "name: " + name,
        "scalar: !_ScalarKind String"]);

  protected override string[] ExpectedDescriptionAliases(string input, string description, string aliases)
    => ["!_ScalarString",
      aliases,
      description,
      "kind: !_TypeKind Scalar",
      "name: " + input,
      "scalar: !_ScalarKind String"];

  private string[] ExpectedMember(string member, string ofScalar)
    => ["- !_ScalarMember", "  scalar: " + ofScalar, "  name: " + member];

  internal override IModelAliasedChecks<string> AliasedChecks => _checks;

  private readonly ScalarStringModelChecks _checks = new();
}

internal sealed class ScalarStringModelChecks
  : ModelAliasedChecks<string, AstScalar<ScalarRegexAst>>
{
  internal readonly IModeller<AstScalar<ScalarRegexAst>> Scalar;

  public ScalarStringModelChecks()
    => Scalar = new ScalarStringModeller();

  protected override IRendering AstToModel(AstScalar<ScalarRegexAst> aliased)
    => Scalar.ToRenderer(aliased);

  protected override AstScalar<ScalarRegexAst> NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description, ScalarKind.String);
}
