using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public class ScalarEnumModelTests : ModelAliasedTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Parent(string name, string parent)
    => _checks.AstExpected(
      new(AstNulls.At, name, ScalarKind.Enum, []) { Parent = parent },
      ["!_ScalarEnum",
        .. parent.TypeRefFor(SimpleKindModel.Scalar),
        "kind: !_TypeKind Scalar",
        "name: " + name,
        "scalar: !_ScalarKind Enum"]);

  [Theory, RepeatData(Repeats)]
  public void Model_Members(string name, string[] members)
    => _checks
    .AstExpected(
      new(AstNulls.At, name, ScalarKind.Enum, members.ScalarMembers()),
      ["!_ScalarEnum",
        "allItems:",
        .. members.SelectMany(ExpectedAllItem(name)),
        "items:",
        .. members.SelectMany(ExpectedItem),
        "kind: !_TypeKind Scalar",
        "name: " + name,
        "scalar: !_ScalarKind Enum"]);

  [Theory, RepeatData(Repeats)]
  public void Model_All(string name, string contents, string[] aliases, string parent, string[] members)
    => _checks
    .AstExpected(
      new(AstNulls.At, name, ScalarKind.Enum, members.ScalarMembers()) {
        Aliases = aliases,
        Description = contents,
        Parent = parent,
      },
      ["!_ScalarEnum",
        $"aliases: [{string.Join(", ", aliases)}]",
        "allItems:",
        .. members.SelectMany(ExpectedAllItem(name)),
        "description: " + _checks.YamlQuoted(contents),
        .. parent.TypeRefFor(SimpleKindModel.Scalar),
        "items:",
        .. members.SelectMany(ExpectedItem),
        "kind: !_TypeKind Scalar",
        "name: " + name,
        "scalar: !_ScalarKind Enum"]);

  protected override string[] ExpectedDescriptionAliases(string input, string description, string aliases)
    => ["!_ScalarEnum",
      aliases,
      description,
      "kind: !_TypeKind Scalar",
      "name: " + input,
      "scalar: !_ScalarKind Enum"];

  private Func<string, string[]> ExpectedAllItem(string ofScalar)
    => member => ["- !_ScalarItem(_ScalarMember)", "  exclude: false", "  kind: !_SimpleKind Enum", "  scalar: " + ofScalar, "  value: " + member];

  private string[] ExpectedItem(string member)
    => ["- !_ScalarMember", "  exclude: false", "  kind: !_SimpleKind Enum", "  value: " + member];

  internal override IModelAliasedChecks<string> AliasedChecks => _checks;

  private readonly ScalarEnumModelChecks _checks = new();
}

internal sealed class ScalarEnumModelChecks
  : ModelAliasedChecks<string, AstScalar<ScalarMemberAst>>
{
  internal readonly IModeller<AstScalar<ScalarMemberAst>> Scalar;

  public ScalarEnumModelChecks()
    => Scalar = new ScalarEnumModeller();

  protected override IRendering AstToModel(AstScalar<ScalarMemberAst> aliased)
    => Scalar.ToRenderer(aliased);

  protected override AstScalar<ScalarMemberAst> NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description, ScalarKind.Enum);
}
