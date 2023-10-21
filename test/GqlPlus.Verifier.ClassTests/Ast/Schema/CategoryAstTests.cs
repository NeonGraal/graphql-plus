namespace GqlPlus.Verifier.Ast.Schema;

public class CategoryAstTests : BaseNamedAstTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithOutputAndName(string name, string output)
    => _checks.HashCode(
      () => new CategoryAst(AstNulls.At, name, output));

  [Theory, RepeatData(Repeats)]
  public void String_WithOutputAndName(string name, string output)
    => _checks.String(
      () => new CategoryAst(AstNulls.At, name, output),
      $"( !c {name} (Parallel) {output} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithAliases(string output, string alias1, string alias2)
    => _checks.String(
      () => new CategoryAst(AstNulls.At, output) { Aliases = new[] { alias1, alias2 } },
      $"( !c {output.Camelize()} [ {alias1} {alias2} ] (Parallel) {output} )");

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
  public void Equality_WithAliases(string output, string alias1, string alias2)
    => _checks.Equality(
      () => new CategoryAst(AstNulls.At, output) { Aliases = new[] { alias1, alias2 } });

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithAliases(string output, string alias1, string alias2)
    => _checks.InequalityWith(output,
      () => new CategoryAst(AstNulls.At, output) { Aliases = new[] { alias1, alias2 } });

  protected override string ExpectedString(string input)
    => $"( !c {input.Camelize()} (Parallel) {input} )";

  private readonly BaseNamedAstChecks<CategoryAst> _checks
    = new(name => new CategoryAst(AstNulls.At, name)) {
      SameInput = (name1, name2) => name1.Camelize() == name2.Camelize()
    };

  internal override IBaseNamedAstChecks NamedChecks => _checks;
}
