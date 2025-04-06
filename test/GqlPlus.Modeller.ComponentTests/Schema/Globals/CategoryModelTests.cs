using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Modelling;

namespace GqlPlus.Schema.Globals;

public class CategoryModelTests(
  ICategoryModelChecks checks
) : TestAliasedModel<string, CategoryModel>(checks)
{
  [Theory, RepeatData]
  public void Model_Name(string output, string name)
    => checks.CategoryExpected(
      new CategoryDeclAst(AstNulls.At, name, new(AstNulls.At, output)),
      new(output, name));

  [Theory, RepeatData]
  public void Model_Resolution(string output, CategoryOption option)
    => checks.CategoryExpected(
      new CategoryDeclAst(AstNulls.At, new(AstNulls.At, output)) { Option = option },
      new(output) { Option = option });

  [Theory, RepeatData]
  public void Model_Modifiers(string output)
    => checks.CategoryExpected(
      new CategoryDeclAst(AstNulls.At, new(AstNulls.At, output)) { Modifiers = TestMods() },
      new(output) { Modifiers = true });

  [Theory, RepeatData]
  public void Model_All(
    string output,
    string name,
    string contents,
    string[] aliases,
    CategoryOption option
  ) => checks.CategoryExpected(
      new CategoryDeclAst(AstNulls.At, name, new(AstNulls.At, output)) {
        Aliases = aliases,
        Description = contents,
        Option = option,
        Modifiers = TestMods(),
      },
      new(output, name, aliases, contents) { Option = option, Modifiers = true });
}

internal sealed class CategoryModelChecks(
  IModeller<IGqlpSchemaCategory, CategoryModel> modeller,
  IRenderer<CategoryModel> rendering
) : CheckAliasedModel<string, IGqlpSchemaCategory, CategoryDeclAst, CategoryModel>(modeller, rendering)
  , ICategoryModelChecks
{
  protected override string[] ExpectedDescriptionAliases(ExpectedDescriptionAliasesInput<string> input)
    => ExpectedCategory(new(input));

  private string[] ExpectedCategory(ExpectedCategoryInput input)
    => ["!_Category",
      .. input.ExpectedAliases ?? [],
      .. input.ExpectedDescription ?? [],
      input.Modifiers ? "modifiers: [!_Modifier{modifierKind:!_ModifierKind List},!_Modifier{modifierKind:!_ModifierKind Opt}]" : "",
      "name: " + input.Name,
      .. input.Output.TypeRefFor(TypeKindModel.Output),
      $"resolution: !_Resolution {input.Option}"];

  protected override CategoryDeclAst NewAliasedAst(string name, string? description = null, string[]? aliases = null)
    => new(AstNulls.At, new(AstNulls.At, name)) {
      Description = description ?? "",
      Aliases = aliases ?? [],
    };

  public void CategoryExpected(IGqlpSchemaCategory ast, ExpectedCategoryInput input)
    => AstExpected((CategoryDeclAst)ast, ExpectedCategory(input));
}

public interface ICategoryModelChecks
  : ICheckAliasedModel<string, CategoryModel>
{
  void CategoryExpected(IGqlpSchemaCategory ast, ExpectedCategoryInput input);
}

public sealed class ExpectedCategoryInput(
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
