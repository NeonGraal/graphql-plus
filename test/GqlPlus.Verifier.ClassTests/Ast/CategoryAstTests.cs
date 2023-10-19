using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace GqlPlus.Verifier.Ast;

public class CategoryAstTests
{
  [Fact]
  public void HashCode()
    => new CategoryAst(AstNulls.At, "").GetHashCode().Should().Be(new CategoryAst(AstNulls.At, "").GetHashCode());

  [Theory, RepeatData(Repeats)]
  public void String(string output)
    => new CategoryAst(AstNulls.At, output).TestString($"( !c {output.Camelize()} (Parallel) {output} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithName(string name, string output)
    => new CategoryAst(AstNulls.At, name, output).TestString($"( !c {name} (Parallel) {output} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithAliases(string output, string alias1, string alias2)
    => new CategoryAst(AstNulls.At, output) { Aliases = new[] { alias1, alias2 } }
    .TestString($"( !c {output.Camelize()} [ {alias1} {alias2} ] (Parallel) {output} )");

  [Theory, RepeatData(Repeats)]
  public void Equality(string output)
  {
    var left = new CategoryAst(AstNulls.At, output);
    var right = new CategoryAst(AstNulls.At, output);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality(string output1, string output2)
  {
    if (output1 == output2) {
      return;
    }

    var left = new CategoryAst(AstNulls.At, output1);
    var right = new CategoryAst(AstNulls.At, output2);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithName(string output, string name)
  {
    var left = new CategoryAst(AstNulls.At, name, output);
    var right = new CategoryAst(AstNulls.At, name, output);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithName(string output, string name1, string name2)
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
}
