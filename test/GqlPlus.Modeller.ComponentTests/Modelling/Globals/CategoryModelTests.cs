using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Modelling.Globals;

public class CategoryModelTests(
  IModeller<IGqlpSchemaCategory, CategoryModel> modeller,
  IRenderer<CategoryModel> rendering
) : TestAliasedModel<string>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Name(string output, string name)
    => _checks.CategoryExpected(
      new(AstNulls.At, name, output),
      new(output, name));

  [Theory, RepeatData(Repeats)]
  public void Model_Resolution(string output, CategoryOption option)
    => _checks.CategoryExpected(
      new(AstNulls.At, output) { Option = option },
      new(output) { Option = option });

  [Theory, RepeatData(Repeats)]
  public void Model_Modifiers(string output)
    => _checks.CategoryExpected(
      new(AstNulls.At, output) { Modifiers = TestMods() },
      new(output) { Modifiers = true });

  [Theory, RepeatData(Repeats)]
  public void Model_All(
    string output,
    string name,
    string contents,
    string[] aliases,
    CategoryOption option
  ) => _checks.CategoryExpected(
      new(AstNulls.At, name, output) {
        Aliases = aliases,
        Description = contents,
        Option = option,
        Modifiers = TestMods(),
      },
      new(output, name, aliases, contents) { Option = option, Modifiers = true });

  internal override ICheckAliasedModel<string> AliasedChecks => _checks;

  private readonly CategoryModelChecks _checks = new(modeller, rendering);
}

internal sealed class CategoryModelChecks(
  IModeller<IGqlpSchemaCategory, CategoryModel> modeller,
  IRenderer<CategoryModel> rendering
) : CheckAliasedModel<string, IGqlpSchemaCategory, CategoryDeclAst, CategoryModel>(modeller, rendering)
{
  protected override string[] ExpectedDescriptionAliases(ExpectedDescriptionAliasesInput<string> input)
    => ExpectedCategory(new(input));

  private string[] ExpectedCategory(ExpectedCategoryInput input)
    => ["!_Category",
      .. input.ExpectedAliases ?? [],
      .. input.ExpectedDescription ?? [],
      input.Modifiers ? "modifiers: [!_Modifier {modifierKind: !_ModifierKind List}, !_Modifier {modifierKind: !_ModifierKind Opt}]" : "",
      "name: " + input.Name,
      .. input.Output.TypeRefFor(TypeKindModel.Output),
      $"resolution: !_Resolution {input.Option}"];

  protected override CategoryDeclAst NewAliasedAst(string name, string? description = null, string[]? aliases = null)
    => new(AstNulls.At, name) {
      Description = description ?? "",
      Aliases = aliases ?? [],
    };

  internal void CategoryExpected(CategoryDeclAst ast, ExpectedCategoryInput input)
    => AstExpected(ast, ExpectedCategory(input));
}

internal sealed class ExpectedCategoryInput(
  string output,
  string? name = null,
  IEnumerable<string>? aliases = null,
  string? description = null
) : ExpectedDescriptionAliasesInput<string>(name ?? output.Camelize(), aliases, description)
{
  public bool Modifiers { get; init; }
  public string Output { get; } = output;
  public CategoryOption Option { get; init; } = CategoryOption.Parallel;

  internal ExpectedCategoryInput(ExpectedDescriptionAliasesInput<string> input)
    : this(input.Name)
  {
    Aliases = input.Aliases;
    ExpectedAliases = input.ExpectedAliases;
    Description = input.Description;
    ExpectedDescription = input.ExpectedDescription;
  }
}
