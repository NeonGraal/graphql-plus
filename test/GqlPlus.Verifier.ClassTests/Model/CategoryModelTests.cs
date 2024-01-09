using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;

public class CategoryModelTests
{
  [Theory, RepeatData(Repeats)]
  public void Model_Default(string output)
    => Model_Expected(
      new CategoryDeclAst(AstNulls.At, output),
      $@"!!_Category
name: {output.Camelize()}
output: {output}
resolution: !!_Resolution Parallel
");

  [Theory, RepeatData(Repeats)]
  public void Model_Name(string output, string name)
    => Model_Expected(
      new CategoryDeclAst(AstNulls.At, name, output),
      $@"!!_Category
name: {name}
output: {output}
resolution: !!_Resolution Parallel
");

  [Theory, RepeatData(Repeats)]
  public void Model_Description(string output, string contents)
    => Model_Expected(
      new CategoryDeclAst(AstNulls.At, output) { Description = contents },
      $@"!!_Category
description: {YamlQuoted(contents)}
name: {output.Camelize()}
output: {output}
resolution: !!_Resolution Parallel
");

  [Theory, RepeatData(Repeats)]
  public void Model_Aliases(string output, string[] aliases)
    => Model_Expected(
      new CategoryDeclAst(AstNulls.At, output) { Aliases = aliases },
      $@"!!_Category
aliases: [{string.Join(", ", aliases)}]
name: {output.Camelize()}
output: {output}
resolution: !!_Resolution Parallel
");

  [Theory, RepeatData(Repeats)]
  public void Model_Resolution(string output, CategoryOption option)
    => Model_Expected(
      new CategoryDeclAst(AstNulls.At, output) { Option = option },
      $@"!!_Category
name: {output.Camelize()}
output: {output}
resolution: !!_Resolution {option}
");

  [Theory, RepeatData(Repeats)]
  public void Model_Modifiers(string output)
    => Model_Expected(
      new CategoryDeclAst(AstNulls.At, output) { Modifiers = TestMods() },
      $@"!!_Category
modifiers: [!!_Modifier List, !!_Modifier Optional]
name: {output.Camelize()}
output: {output}
resolution: !!_Resolution Parallel
");

  [Theory, RepeatData(Repeats)]
  public void Model_All(string output, string name, string contents, string[] aliases, CategoryOption option)
    => Model_Expected(
      new CategoryDeclAst(AstNulls.At, name, output) {
        Aliases = aliases,
        Description = contents,
        Option = option,
        Modifiers = TestMods(),
      },
      $@"!!_Category
aliases: [{string.Join(", ", aliases)}]
description: {YamlQuoted(contents)}
modifiers: [!!_Modifier List, !!_Modifier Optional]
name: {name}
output: {output}
resolution: !!_Resolution {option}
");

  private static void Model_Expected(CategoryDeclAst category, string expected)
  {
    var model = category.ToModel();

    model.ToYaml().Should().Be(expected);
  }

  private static string YamlQuoted(string input)
    => $"'{input.Replace("'", "''")}'";
}
