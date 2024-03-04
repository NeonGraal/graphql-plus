using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class CategoryModelTests(
  IModeller<CategoryDeclAst, CategoryModel> modeller
) : AliasedModelTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Name(string output, string name)
    => _checks.AstExpected(
      new(AstNulls.At, name, output),
      ["!_Category",
        "name: " + name,
        .. output.TypeRefFor(TypeKindModel.Output),
        "resolution: !_Resolution Parallel"]);

  [Theory, RepeatData(Repeats)]
  public void Model_Resolution(string output, CategoryOption option)
    => _checks.AstExpected(
      new(AstNulls.At, output) { Option = option },
      ["!_Category",
        "name: " + output.Camelize(),
        .. output.TypeRefFor(TypeKindModel.Output),
        $"resolution: !_Resolution {option}"]);

  [Theory, RepeatData(Repeats)]
  public void Model_Modifiers(string output)
    => _checks
    .AstExpected(
      new(AstNulls.At, output) { Modifiers = TestMods() },
      ["!_Category",
        "modifiers: [!_Modifier List, !_Modifier Optional]",
        "name: " + output.Camelize(),
        .. output.TypeRefFor(TypeKindModel.Output),
        "resolution: !_Resolution Parallel"]);

  [Theory, RepeatData(Repeats)]
  public void Model_All(
    string output,
    string name,
    string contents,
    string[] aliases,
    CategoryOption option
  ) => _checks
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
        .. output.TypeRefFor(TypeKindModel.Output),
        $"resolution: !_Resolution {option}"]);

  protected override string[] ExpectedDescriptionAliases(string input, string description, string aliases)
    => ["!_Category",
      aliases,
      description,
      "name: " + input.Camelize(),
      .. input.TypeRefFor(TypeKindModel.Output, "output"),
      "resolution: !_Resolution Parallel"];

  internal override IAliasedModelChecks<string> AliasedChecks => _checks;

  private readonly CategoryModelChecks _checks = new(modeller);
}

internal sealed class CategoryModelChecks(
  IModeller<CategoryDeclAst, CategoryModel> modeller
) : AliasedModelChecks<string, CategoryDeclAst, CategoryModel>(modeller)
{
  protected override CategoryDeclAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input) { Description = description };
}
