using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public class CategoryModelTests : ModelAliasedTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Name(string output, string name)
    => _checks.AstExpected(
      new(AstNulls.At, name, output),
      ["!_Category",
        "name: " + name,
        "output: " + output,
        "resolution: !_Resolution Parallel"]);

  [Theory, RepeatData(Repeats)]
  public void Model_Resolution(string output, CategoryOption option)
    => _checks.AstExpected(
      new(AstNulls.At, output) { Option = option },
      ["!_Category",
        "name: " + output.Camelize(),
        "output: " + output,
        $"resolution: !_Resolution {option}"]);

  [Theory, RepeatData(Repeats)]
  public void Model_Modifiers(string output)
    => _checks
    .RenderReturn("Modifiers")
    .AstExpected(
      new(AstNulls.At, output) { Modifiers = TestMods() },
      ["!_Category",
        "modifiers: [!_Modifier List, !_Modifier Optional]",
        "name: " + output.Camelize(),
        "output: " + output,
        "resolution: !_Resolution Parallel"]);

  [Theory, RepeatData(Repeats)]
  public void Model_All(string output, string name, string contents, string[] aliases, CategoryOption option)
    => _checks
    .RenderReturn("Modifiers")
    .AstExpected(
      new(AstNulls.At, name, output) {
        Aliases = aliases,
        Description = contents,
        Option = option,
        Modifiers = TestMods(),
      },
      ["!_Category",
        $"aliases: [{string.Join(", ", aliases)}]",
        "description: " + _checks.YamlQuoted(contents),
        "modifiers: [!_Modifier List, !_Modifier Optional]",
        "name: " + name,
        "output: " + output,
        $"resolution: !_Resolution {option}"]);

  protected override string[] ExpectedDescriptionAliases(string input, string description, string aliases)
    => ["!_Category",
      aliases,
      description,
      "name: " + input.Camelize(),
      "output: " + input,
      "resolution: !_Resolution Parallel"];

  internal override ModelAliasedChecks<string, CategoryDeclAst> AliasedChecks => _checks;

  private readonly CategoryModelChecks _checks = new();
}

internal sealed class CategoryModelChecks
  : ModelAliasedChecks<string, CategoryDeclAst>
{
  internal readonly IModeller<CategoryDeclAst> Category;
  internal readonly IModeller<ModifierAst> Modifier;

  public CategoryModelChecks()
    => Category = new CategoryModeller(
      Modifier = ForModeller<ModifierAst, ModifierModel>(
        m => new(m.Kind)));

  protected override CategoryDeclAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input) { Description = description };

  protected override IRendering AstToModel(CategoryDeclAst aliased)
    => Category.ToRenderer(aliased);
}
