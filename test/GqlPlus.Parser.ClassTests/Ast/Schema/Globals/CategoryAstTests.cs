using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Operation;

namespace GqlPlus.Ast.Schema.Globals;

public partial class CategoryAstTests
  : AstAliasedBaseTests
{
  [Theory, RepeatData]
  public void HashCode_WithOutputAndName(string name, string output)
    => _checks.HashCode(
      () => new CategoryDeclAst(AstNulls.At, name, new TypeRefAst(AstNulls.At, output)));

  [Theory, RepeatData]
  public void Text_WithOutputAndName(string name, string output)
    => _checks.Text(
      () => new CategoryDeclAst(AstNulls.At, name, new TypeRefAst(AstNulls.At, output)),
      $"( !Ca {name} (Parallel) !Tr {output} )");

  [Theory, RepeatData]
  public void Equality_WithOutputAndName(string name, string output)
    => _checks.Equality(
      () => new CategoryDeclAst(AstNulls.At, name, new TypeRefAst(AstNulls.At, output)));

  [Theory, RepeatData]
  public void HashCode_WithOutputDescription(string name, string description)
    => _checks.HashCode(
      () => new CategoryDeclAst(AstNulls.At, name, new TypeRefAst(AstNulls.At, name, description)));

  [Theory, RepeatData]
  public void Text_WithOutputDescription(string name, string description)
    => _checks.Text(
      () => new CategoryDeclAst(AstNulls.At, name, new TypeRefAst(AstNulls.At, name, description)),
      $"( !Ca {name} (Parallel) '{description}' !Tr {name} )");

  [Theory, RepeatData]
  public void Equality_WithOutputDescription(string name, string description)
    => _checks.Equality(
      () => new CategoryDeclAst(AstNulls.At, name, new TypeRefAst(AstNulls.At, name, description)));

  [Theory, RepeatData]
  public void Inequality_BetweenNames(string output, string name1, string name2)
    => _checks.InequalityBetween(name1, name2,
      name => new CategoryDeclAst(AstNulls.At, name, new TypeRefAst(AstNulls.At, output)),
      name1 == name2);

  [Theory, RepeatData]
  public void Inequality_BetweenOutput(string output1, string output2, string name)
    => _checks.InequalityBetween(output1, output2,
      output => new CategoryDeclAst(AstNulls.At, name, new TypeRefAst(AstNulls.At, output)),
      output1 == output2);

  [Theory, RepeatData]
  public void HashCode_WithOption(string name, CategoryOption option)
      => _checks.HashCode(
        () => CreateCategory(name) with { Option = option });

  [Theory, RepeatData]
  public void Text_WithOption(string name, CategoryOption option)
    => _checks.Text(
      () => CreateCategory(name) with { Option = option },
      $"( !Ca {name.Camelize()} ({option}) !Tr {name} )");

  [Theory, RepeatData]
  public void Equality_WithOption(string name, CategoryOption option)
    => _checks.Equality(
      () => CreateCategory(name) with { Option = option });

  [Theory, RepeatData]
  public void Inequality_BetweenOptions(string name, CategoryOption option1, CategoryOption option2)
    => _checks.InequalityBetween(option1, option2,
      option => CreateCategory(name) with { Option = option },
      option1 == option2);

  private readonly CategoryAstChecks _checks = new();

  internal override IAstAliasedChecks<string> AliasedChecks => _checks;

  [CheckTests]
  internal IModifiersChecks<string> ModifiersChecks { get; } = new CategoryModifiersChecks();

  [CheckTests]
  internal ICloneChecks<string> CloneChecks { get; }
    = new CloneChecks<string, CategoryDeclAst>(
      CreateCategory,
      (original, input) => original with { Output = new TypeRefAst(AstNulls.At, input) });

  internal static CategoryDeclAst CreateCategory(string name)
    => new(AstNulls.At, name.Camelize(), new TypeRefAst(AstNulls.At, name));

  protected override Func<string, string, bool> SameInput
    => (name1, name2) => name1.Camelize() == name2.Camelize();
}

internal sealed class CategoryAstChecks()
  : AstAliasedChecks<CategoryDeclAst>(CategoryAstTests.CreateCategory)
{
  protected override string AliasesString(string input, string description, string aliases)
    => $"( {DescriptionNameString(input.Camelize(), description)}{aliases} (Parallel) !Tr {input} )";
}

internal sealed class CategoryModifiersChecks()
  : ModifiersChecks<string, CategoryDeclAst>(
      CategoryAstTests.CreateCategory,
      ast => ast with { Modifiers = TestMods() })
{
  protected override string InputString(string input)
    => $"( !Ca {input.Camelize()} (Parallel) !Tr {input} )";
}
