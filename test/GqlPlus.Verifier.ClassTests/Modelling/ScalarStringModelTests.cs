using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public class ScalarStringModelTests
  : ModelScalarTests<string>
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
        .. AllItems(regexes, name),
        .. Items(regexes),
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
        .. AllItems(regexes, name),
        "description: " + _checks.YamlQuoted(contents),
        .. parent.TypeRefFor(SimpleKindModel.Scalar),
        .. Items(regexes),
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

  protected override string[] ExpectedItem(string input, string exclude, string[] scalar)
    => ["- !_ScalarRegex", exclude, "  regex: " + input, .. scalar];

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
