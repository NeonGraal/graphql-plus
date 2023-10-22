namespace GqlPlus.Verifier.Ast.Schema;

public class CategoryAstTests : BaseAliasedAstTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithOutputAndName(string name, string output)
    => _checks.HashCode(
      () => new CategoryAst(AstNulls.At, name, output));

  [Theory, RepeatData(Repeats)]
  public void String_WithOutputAndName(string name, string output)
    => _checks.String(
      () => new CategoryAst(AstNulls.At, name, "", output),
      $"( !C {name} (Parallel) {output} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithOutputAndName(string output, string name)
    => _checks.Equality(
      () => new CategoryAst(AstNulls.At, name, output));

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenNames(string output, string name1, string name2)
    => _checks.InequalityBetween(name1, name2,
      name => new CategoryAst(AstNulls.At, name, output),
      name1 == name2);

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenOutput(string output1, string output2, string name)
    => _checks.InequalityBetween(output1, output2,
      output => new CategoryAst(AstNulls.At, name, output),
      output1 == output2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithOption(string name, CategoryOption option)
      => _checks.HashCode(
        () => new CategoryAst(AstNulls.At, name) { Option = option });

  [Theory, RepeatData(Repeats)]
  public void String_WithOption(string name, CategoryOption option)
    => _checks.String(
      () => new CategoryAst(AstNulls.At, name) { Option = option },
      $"( !C {name.Camelize()} ({option}) {name} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithOption(string name, CategoryOption option)
    => _checks.Equality(
      () => new CategoryAst(AstNulls.At, name) { Option = option });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenOptions(string name, CategoryOption option1, CategoryOption option2)
    => _checks.InequalityBetween(option1, option2,
      option => new CategoryAst(AstNulls.At, name) { Option = option },
      option1 == option2);

  protected override string InputString(string input)
    => $"( !C {input.Camelize()} (Parallel) {input} )";

  protected override string AliasesString(string input, params string[] aliases)
    => $"( !C {input.Camelize()} [ {string.Join(" ", aliases)} ] (Parallel) {input} )";

  private readonly BaseAliasedAstChecks<CategoryAst> _checks
    = new(name => new CategoryAst(AstNulls.At, name)) {
      SameInput = (name1, name2) => name1.Camelize() == name2.Camelize()
    };

  internal override IBaseAliasedAstChecks<string> AliasedChecks => _checks;
}
