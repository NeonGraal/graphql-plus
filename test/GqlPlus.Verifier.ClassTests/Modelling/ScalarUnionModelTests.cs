using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public class ScalarUnionModelTests : ModelAliasedTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Parent(string name, string parent)
    => _checks.AstExpected(
      new(AstNulls.At, name, ScalarKind.Union, []) { Parent = parent },
      ["!_ScalarUnion",
        .. parent.TypeRefFor(SimpleKindModel.Scalar),
        "kind: !_TypeKind Scalar",
        "name: " + name,
        "scalar: !_ScalarKind Union"]);

  [Theory, RepeatData(Repeats)]
  public void Model_Members(string name, string[] references)
    => _checks
    .AstExpected(
      new(AstNulls.At, name, ScalarKind.Union, references.ScalarReferences()),
      ["!_ScalarUnion",
        "allItems:",
        .. references.SelectMany(ExpectedAllItem(name)),
        "items:",
        .. references.SelectMany(ExpectedItem),
        "kind: !_TypeKind Scalar",
        "name: " + name,
        "scalar: !_ScalarKind Union"]);

  [Theory, RepeatData(Repeats)]
  public void Model_All(string name, string contents, string[] aliases, string parent, string[] references)
    => _checks
  .AstExpected(
      new(AstNulls.At, name, ScalarKind.Union, references.ScalarReferences()) {
        Aliases = aliases,
        Description = contents,
        Parent = parent,
      },
      ["!_ScalarUnion",
        $"aliases: [{string.Join(", ", aliases)}]",
        "allItems:",
        .. references.SelectMany(ExpectedAllItem(name)),
        "description: " + _checks.YamlQuoted(contents),
        .. parent.TypeRefFor(SimpleKindModel.Scalar),
        "items:",
        .. references.SelectMany(ExpectedItem),
        "kind: !_TypeKind Scalar",
        "name: " + name,
        "scalar: !_ScalarKind Union"]);

  protected override string[] ExpectedDescriptionAliases(string input, string description, string aliases)
    => ["!_ScalarUnion",
      aliases,
      description,
      "kind: !_TypeKind Scalar",
      "name: " + input,
      "scalar: !_ScalarKind Union"];

  private Func<string, string[]> ExpectedAllItem(string ofScalar)
    => regex => ["- !_ScalarItem(_TypeRef(_SimpleKind))", "  kind: !_SimpleKind Basic", "  name: " + regex, "  scalar: " + ofScalar];

  private string[] ExpectedItem(string regex)
    => ["- !_TypeRef(_SimpleKind)", "  kind: !_SimpleKind Basic", "  name: " + regex];

  internal override IModelAliasedChecks<string> AliasedChecks => _checks;

  private readonly ScalarUnionModelChecks _checks = new();
}

internal sealed class ScalarUnionModelChecks
  : ModelAliasedChecks<string, AstScalar<ScalarReferenceAst>>
{
  internal readonly IModeller<AstScalar<ScalarReferenceAst>> Scalar;

  public ScalarUnionModelChecks()
    => Scalar = new ScalarUnionModeller();

  protected override IRendering AstToModel(AstScalar<ScalarReferenceAst> aliased)
    => Scalar.ToRenderer(aliased);

  protected override AstScalar<ScalarReferenceAst> NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description, ScalarKind.Union);
}
