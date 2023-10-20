namespace GqlPlus.Verifier.Ast;

public class FragmentAstTests
{
  [Fact]
  public void HashCode_Null()
    => TestHashCode(() => new FragmentAst(AstNulls.At, "", ""));

  [Theory, RepeatData(Repeats)]
  public void HashCode(string name, string onType, string field)
    => TestHashCode(() => new FragmentAst(AstNulls.At, name, onType, field.Fields()));

  [Theory, RepeatData(Repeats)]
  public void String(string name, string onType, string field)
    => new FragmentAst(AstNulls.At, name, onType, field.Fields())
    .TestString($"( !T {name} :{onType} {{ !F {field} }} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithDirective(string name, string onType, string field, string directive)
    => new FragmentAst(AstNulls.At, name, onType, field.Fields()) { Directives = directive.Directives() }
    .TestString($"( !T {name} ( !D {directive} ) :{onType} {{ !F {field} }} )");

  [Theory, RepeatData(Repeats)]
  public void Equality(string name, string onType, string field)
  {
    var left = new FragmentAst(AstNulls.At, name, onType, field.Fields());
    var right = new FragmentAst(AstNulls.At, name, onType, field.Fields());

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithName(string name1, string name2, string onType, string field)
  {
    if (name1 == name2) {
      return;
    }

    var left = new FragmentAst(AstNulls.At, name1, onType, field.Fields());
    var right = new FragmentAst(AstNulls.At, name2, onType, field.Fields());

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithOnType(string name, string onType1, string onType2, string field)
  {
    if (onType1 == onType2) {
      return;
    }

    var left = new FragmentAst(AstNulls.At, name, onType1, field.Fields());
    var right = new FragmentAst(AstNulls.At, name, onType2, field.Fields());

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithFields(string name, string onType, string field1, string field2)
  {
    if (field1 == field2) {
      return;
    }

    var left = new FragmentAst(AstNulls.At, name, onType, field1.Fields());
    var right = new FragmentAst(AstNulls.At, name, onType, field2.Fields());

    (left != right).Should().Be(field1 != field2);
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithDirective(string name, string onType, string field, string directive)
  {
    var left = new FragmentAst(AstNulls.At, name, onType, field.Fields()) { Directives = directive.Directives() };
    var right = new FragmentAst(AstNulls.At, name, onType, field.Fields()) { Directives = directive.Directives() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithDirective(string name, string onType, string field, string directive)
  {
    var left = new FragmentAst(AstNulls.At, name, onType, field.Fields()) { Directives = directive.Directives() };
    var right = new FragmentAst(AstNulls.At, name, onType, field.Fields());

    (left != right).Should().BeTrue();
  }
}
