namespace GqlPlus.Verifier.Ast;

public class CategoryAstTests : BaseNamedAstTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithOutputAndName(string name, string output)
    => TestHashCode(() => new CategoryAst(AstNulls.At, name, output));

  [Theory, RepeatData(Repeats)]
  public void String_WithOutputAndName(string name, string output)
    => new CategoryAst(AstNulls.At, name, output).TestString($"( !c {name} (Parallel) {output} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithAliases(string output, string alias1, string alias2)
    => new CategoryAst(AstNulls.At, output) { Aliases = new[] { alias1, alias2 } }
    .TestString($"( !c {output.Camelize()} [ {alias1} {alias2} ] (Parallel) {output} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithOutputAndName(string output, string name)
  {
    var left = new CategoryAst(AstNulls.At, name, output);
    var right = new CategoryAst(AstNulls.At, name, output);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithOutputAndName(string output, string name1, string name2)
  {
    if (name1 == name2) {
      return;
    }

    var left = new CategoryAst(AstNulls.At, name1, output);
    var right = new CategoryAst(AstNulls.At, name2, output);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithAliases(string output, string alias1, string alias2)
  {
    var left = new CategoryAst(AstNulls.At, output) { Aliases = new[] { alias1, alias2 } };
    var right = new CategoryAst(AstNulls.At, output) { Aliases = new[] { alias2, alias1 } };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithAliases(string output, string alias1, string alias2)
  {
    var left = new CategoryAst(AstNulls.At, output) { Aliases = new[] { alias1, alias2 } };
    var right = new CategoryAst(AstNulls.At, output);

    (left != right).Should().BeTrue();
  }

  protected override string ExpectedString(string name)
    => $"( !c {name.Camelize()} (Parallel) {name} )";

  internal override BaseNamedAstChecks NamedChecks { get; } =
    new BaseNamedAstChecks<CategoryAst>(name => new CategoryAst(AstNulls.At, name)) {
      SameName = (name1, name2) => name1.Camelize() == name2.Camelize()
    };
}
