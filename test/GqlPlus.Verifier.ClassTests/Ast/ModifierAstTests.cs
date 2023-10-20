namespace GqlPlus.Verifier.Ast;

public class ModifierAstTests
{
  [Fact]
  public void HashCode()
    => TestHashCode(() => ModifierAst.Optional(AstNulls.At));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithKey(string key, bool optional)
    => TestHashCode(() => new ModifierAst(AstNulls.At, key, optional));

  [Fact]
  public void String()
  {
    ModifierAst.Optional(AstNulls.At).TestString("?");
    ModifierAst.List(AstNulls.At).TestString("[]");
  }

  [Theory, RepeatData(Repeats)]
  public void String_WithKey(string key, bool optional)
  {
    var optString = optional ? "?" : "";
    new ModifierAst(AstNulls.At, key, optional).TestString($"[{key}{optString}]");
  }

  [Fact]
  public void Inequality()
  {
    var left = ModifierAst.Optional;
    var right = ModifierAst.List;

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithKey(string key, bool optional)
  {
    var left = new ModifierAst(AstNulls.At, key, optional);
    var right = new ModifierAst(AstNulls.At, key, optional);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithKey(string key, bool optional)
  {
    var left = new ModifierAst(AstNulls.At, key, optional);
    var right = ModifierAst.List(AstNulls.At);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithKeys(string key1, string key2)
  {
    if (key1 == key2) {
      return;
    }

    var left = new ModifierAst(AstNulls.At, key1, false);
    var right = new ModifierAst(AstNulls.At, key2, false);

    (left != right).Should().BeTrue();
  }
}
