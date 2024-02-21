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
  public void Model_Members(string name, string[] regexes)
    => _checks
    .AstExpected(
      new(AstNulls.At, name, ScalarKind.String, regexes.ScalarRegexes()),
      ["!_ScalarString",
        "allItems:",
        .. regexes.SelectMany(ExpectedAllItem(name)),
        "items:",
        .. regexes.SelectMany(ExpectedItem),
        "kind: !_TypeKind Scalar",
        "name: " + name,
        "scalar: !_ScalarKind String"]);

  [Theory, RepeatData(Repeats)]
  public void Model_All(string name, string contents, string[] aliases, string parent, string[] regexes)
    => _checks
    .AstExpected(
      new(AstNulls.At, name, ScalarKind.String, regexes.ScalarRegexes()) {
        Aliases = aliases,
        Description = contents,
        Parent = parent,
      },
      ["!_ScalarString",
        $"aliases: [{string.Join(", ", aliases)}]",
        "allItems:",
        .. regexes.SelectMany(ExpectedAllItem(name)),
        "description: " + _checks.YamlQuoted(contents),
        .. parent.TypeRefFor(SimpleKindModel.Scalar),
        "items:",
        .. regexes.SelectMany(ExpectedItem),
        "kind: !_TypeKind Scalar",
        "name: " + name,
        "scalar: !_ScalarKind String"]);

  protected override string[] ExpectedDescriptionAliases(string input, string description, string aliases)
    => ["!_ScalarString",
      aliases,
      description,
      "kind: !_TypeKind Scalar",
      "name: " + input,
      "scalar: !_ScalarKind String"];

  private Func<string, string[]> ExpectedAllItem(string ofScalar)
    => regex => ["- !_ScalarItem(_ScalarRegex)", "  exclude: false", "  regex: " + regex, "  scalar: " + ofScalar];

  private string[] ExpectedItem(string regex)
    => ["- !_ScalarRegex", "  exclude: false", "  regex: " + regex];

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
