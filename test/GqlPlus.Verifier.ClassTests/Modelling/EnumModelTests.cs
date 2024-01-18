using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public class EnumModelTests : ModelAliasedTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Extends(string name, string extends)
    => _checks.AstExpected(
      new(AstNulls.At, name) { Extends = extends },
      ["!_Enum",
        .. extends.TypeRefFor(SimpleKindModel.Enum),
        "kind: !_TypeKind Enum",
        "name: " + name]);

  [Theory, RepeatData(Repeats)]
  public void Model_Members(string name, string[] members)
    => _checks
    .RenderReturn("Parameters")
    .AstExpected(
      new(AstNulls.At, name) { Members = members.EnumMembers() },
      ["!_Enum",
        "kind: !_TypeKind Enum",
        "members:",
        .. members.SelectMany(m => ExpectedMember(m, name)),
        "name: " + name]);

  [Theory, RepeatData(Repeats)]
  public void Model_All(string name, string contents, string[] aliases, string extends, string[] members)
    => _checks
    .RenderReturn("Parameters")
    .AstExpected(
      new(AstNulls.At, name) {
        Aliases = aliases,
        Description = contents,
        Extends = extends,
        Members = members.EnumMembers(),
      },
      ["!_Enum",
        $"aliases: [{string.Join(", ", aliases)}]",
        "description: " + _checks.YamlQuoted(contents),
        .. extends.TypeRefFor(SimpleKindModel.Enum),
        "kind: !_TypeKind Enum",
        "members:",
        .. members.SelectMany(m => ExpectedMember(m, name)),
        "name: " + name]);

  protected override string[] ExpectedDescriptionAliases(string input, string description, string aliases)
    => ["!_Enum",
      aliases,
      description,
      "kind: !_TypeKind Enum",
      "name: " + input];

  private string[] ExpectedMember(string member, string ofEnum)
    => ["- !_EnumMember", "  enum: " + ofEnum, "  name: " + member];

  internal override IModelAliasedChecks<string> AliasedChecks => _checks;

  private readonly EnumModelChecks _checks = new();
}

internal sealed class EnumModelChecks
  : ModelAliasedChecks<string, EnumDeclAst>
{
  internal readonly IModeller<EnumDeclAst> Enum;

  public EnumModelChecks()
    => Enum = new EnumModeller();

  protected override IRendering AstToModel(EnumDeclAst aliased)
    => Enum.ToRenderer(aliased);

  protected override EnumDeclAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description);
}
