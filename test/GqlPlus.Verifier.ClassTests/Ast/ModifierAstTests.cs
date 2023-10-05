using System.Xml.Linq;

namespace GqlPlus.Verifier.Ast;

public class ModifierAstTests
{
  [Fact]

  public void String()
  {
    ModifierAst.Optional.TestString("?");
    ModifierAst.List.TestString("[]");
    new ModifierAst("key", true).TestString("[key?]");
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
    var left = new ModifierAst(key, optional);
    var right = new ModifierAst(key, optional);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithKey(string key, bool optional)
  {
    var left = new ModifierAst(key, optional);
    var right = ModifierAst.List;

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithKeys(string key1, string key2)
  {
    if (key1 == key2) {
      return;
    }

    var left = new ModifierAst(key1, false);
    var right = new ModifierAst(key2, false);

    (left != right).Should().BeTrue();
  }
}
