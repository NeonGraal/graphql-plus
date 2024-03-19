﻿using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class CategoryModelTests(
  IModeller<CategoryDeclAst, CategoryModel> modeller
) : TestAliasedModel<string>
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

  internal override ICheckAliasedModel<string> AliasedChecks => _checks;

  private readonly CategoryModelChecks _checks = new(modeller);
}

internal sealed class CategoryModelChecks(
  IModeller<CategoryDeclAst, CategoryModel> modeller
) : CheckAliasedModel<string, CategoryDeclAst, CategoryModel>(modeller)
{
  protected override string[] ExpectedDescriptionAliases(ExpectedDescriptionAliasesInput<string> input)
    => ["!_Category",
      .. input.Aliases ?? [],
      .. input.Description ?? [],
      "name: " + input.Name.Camelize(),
      .. input.Name.TypeRefFor(TypeKindModel.Output, "output"),
      "resolution: !_Resolution Parallel"];

  protected override CategoryDeclAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input) { Description = description };
}
