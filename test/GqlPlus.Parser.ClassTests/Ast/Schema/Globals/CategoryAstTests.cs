using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Globals;

public class CategoryAstTests
  : AstAliasedTests
{
  [Theory, RepeatData]
  public void HashCode_WithOutputAndName(string name, string output)
    => _checks.HashCode(
      () => new CategoryDeclAst(AstNulls.At, name, new(AstNulls.At, output)));

  [Theory, RepeatData]
  public void String_WithOutputAndName(string name, string output)
    => _checks.Text(
      () => new CategoryDeclAst(AstNulls.At, name, new(AstNulls.At, output)),
      $"( !Ca {name} (Parallel) !Tr {output} )");

  [Theory, RepeatData]
  public void Equality_WithOutputAndName(string name, string output)
    => _checks.Equality(
      () => new CategoryDeclAst(AstNulls.At, name, new(AstNulls.At, output)));

  [Theory, RepeatData]
  public void HashCode_WithOutputDescription(string name, string description)
    => _checks.HashCode(
      () => new CategoryDeclAst(AstNulls.At, name, new(AstNulls.At, name, description)));

  [Theory, RepeatData]
  public void String_WithOutputDescription(string name, string description)
    => _checks.Text(
      () => new CategoryDeclAst(AstNulls.At, name, new(AstNulls.At, name, description)),
      $"( !Ca {name} (Parallel) '{description}' !Tr {name} )");

  [Theory, RepeatData]
  public void Equality_WithOutputDescription(string name, string description)
    => _checks.Equality(
      () => new CategoryDeclAst(AstNulls.At, name, new(AstNulls.At, name, description)));

  [Theory, RepeatData]
  public void Inequality_BetweenNames(string output, string name1, string name2)
    => _checks.InequalityBetween(name1, name2,
      name => new CategoryDeclAst(AstNulls.At, name, new(AstNulls.At, output)),
      name1 == name2);

  [Theory, RepeatData]
  public void Inequality_BetweenOutput(string output1, string output2, string name)
    => _checks.InequalityBetween(output1, output2,
      output => new CategoryDeclAst(AstNulls.At, name, new(AstNulls.At, output)),
      output1 == output2);

  [Theory, RepeatData]
  public void HashCode_WithOption(string name, CategoryOption option)
      => _checks.HashCode(
        () => new CategoryDeclAst(AstNulls.At, new(AstNulls.At, name)) { Option = option });

  [Theory, RepeatData]
  public void String_WithOption(string name, CategoryOption option)
    => _checks.Text(
      () => new CategoryDeclAst(AstNulls.At, new(AstNulls.At, name)) { Option = option },
      $"( !Ca {name.Camelize()} ({option}) !Tr {name} )");

  [Theory, RepeatData]
  public void Equality_WithOption(string name, CategoryOption option)
    => _checks.Equality(
      () => new CategoryDeclAst(AstNulls.At, new(AstNulls.At, name)) { Option = option });

  [Theory, RepeatData]
  public void Inequality_BetweenOptions(string name, CategoryOption option1, CategoryOption option2)
    => _checks.InequalityBetween(option1, option2,
      option => new CategoryDeclAst(AstNulls.At, new(AstNulls.At, name)) { Option = option },
      option1 == option2);

  protected override string AliasesString(string input, string description, string aliases)
    => $"( {DescriptionNameString(input.Camelize(), description)}{aliases} (Parallel) !Tr {input} )";

  private readonly AstAliasedChecks<CategoryDeclAst> _checks
    = new(name => new CategoryDeclAst(AstNulls.At, new(AstNulls.At, name)));

  internal override IAstAliasedChecks<string> AliasedChecks => _checks;

  protected override Func<string, string, bool> SameInput
    => (name1, name2) => name1.Camelize() == name2.Camelize();
}
