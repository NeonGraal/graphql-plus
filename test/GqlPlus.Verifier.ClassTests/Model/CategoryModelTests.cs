using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;

public class CategoryModelTests
{
  [Theory, RepeatData(Repeats)]
  public void Model_Default(string output)
    => _checks.Category_Expected(
      new(AstNulls.At, output),
      $@"!!_Category
name: {output.Camelize()}
output: {output}
resolution: !!_Resolution Parallel
");

  [Theory, RepeatData(Repeats)]
  public void Model_Name(string output, string name)
    => _checks.Category_Expected(
      new(AstNulls.At, name, output),
      $@"!!_Category
name: {name}
output: {output}
resolution: !!_Resolution Parallel
");

  [Theory, RepeatData(Repeats)]
  public void Model_Description(string output, string contents)
    => _checks.Category_Expected(
      new(AstNulls.At, output) { Description = contents },
      $@"!!_Category
description: {_checks.YamlQuoted(contents)}
name: {output.Camelize()}
output: {output}
resolution: !!_Resolution Parallel
");

  [Theory, RepeatData(Repeats)]
  public void Model_Aliases(string output, string[] aliases)
    => _checks.Category_Expected(
      new(AstNulls.At, output) { Aliases = aliases },
      $@"!!_Category
aliases: [{string.Join(", ", aliases)}]
name: {output.Camelize()}
output: {output}
resolution: !!_Resolution Parallel
");

  [Theory, RepeatData(Repeats)]
  public void Model_Resolution(string output, CategoryOption option)
    => _checks.Category_Expected(
      new(AstNulls.At, output) { Option = option },
      $@"!!_Category
name: {output.Camelize()}
output: {output}
resolution: !!_Resolution {option}
");

  [Theory, RepeatData(Repeats)]
  public void Model_Modifiers(string output)
    => _checks.Category_Expected(
      new(AstNulls.At, output) { Modifiers = TestMods() },
      $@"!!_Category
modifiers: [!!_Modifier List, !!_Modifier Optional]
name: {output.Camelize()}
output: {output}
resolution: !!_Resolution Parallel
");

  [Theory, RepeatData(Repeats)]
  public void Model_All(string output, string name, string contents, string[] aliases, CategoryOption option)
    => _checks.Category_Expected(
      new(AstNulls.At, name, output) {
        Aliases = aliases,
        Description = contents,
        Option = option,
        Modifiers = TestMods(),
      },
      $@"!!_Category
aliases: [{string.Join(", ", aliases)}]
description: {_checks.YamlQuoted(contents)}
modifiers: [!!_Modifier List, !!_Modifier Optional]
name: {name}
output: {output}
resolution: !!_Resolution {option}
");

  private readonly CategoryModelChecks _checks = new();
}
