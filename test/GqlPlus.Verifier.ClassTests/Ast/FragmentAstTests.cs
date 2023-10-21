namespace GqlPlus.Verifier.Ast;

public class FragmentAstTests
{
  [Fact]
  public void HashCode_Null()
    => _checks.HashCode(() => new FragmentAst(AstNulls.At, "", ""));

  [Theory, RepeatData(Repeats)]
  public void HashCode(string name, string onType, string field)
    => _checks.HashCode(() => new FragmentAst(AstNulls.At, name, onType, field.Fields()));

  [Theory, RepeatData(Repeats)]
  public void String(string name, string onType, string field)
    => _checks.String(
      () => new FragmentAst(AstNulls.At, name, onType, field.Fields()),
      $"( !T {name} :{onType} {{ !F {field} }} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithDirective(string name, string onType, string field, string directive)
    => _checks.String(
      () => new FragmentAst(AstNulls.At, name, onType, field.Fields()) { Directives = directive.Directives() },
      $"( !T {name} ( !D {directive} ) :{onType} {{ !F {field} }} )");

  [Theory, RepeatData(Repeats)]
  public void Equality(string name, string onType, string field)
    => _checks.Equality(
      () => new FragmentAst(AstNulls.At, name, onType, field.Fields()));

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenName(string name1, string name2, string onType, string field)
  => _checks.InequalityBetween(name1, name2,
      name => new FragmentAst(AstNulls.At, name, onType, field.Fields()));

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenOnType(string name, string onType1, string onType2, string field)
    => _checks.InequalityBetween(onType1, onType2,
      onType => new FragmentAst(AstNulls.At, name, onType, field.Fields()));

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenFields(string name, string onType, string field1, string field2)
    => _checks.InequalityBetween(field1, field2,
      field => new FragmentAst(AstNulls.At, name, onType, field.Fields()));

  [Theory, RepeatData(Repeats)]
  public void Equality_WithDirective(string name, string onType, string field, string directive)
    => _checks.Equality(
      () => new FragmentAst(AstNulls.At, name, onType, field.Fields()) { Directives = directive.Directives() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithDirective(string name, string onType, string field, string directive)
    => _checks.Inequality(
      () => new FragmentAst(AstNulls.At, name, onType, field.Fields()) { Directives = directive.Directives() },
      () => new FragmentAst(AstNulls.At, name, onType, field.Fields()));

  internal BaseAstChecks<FragmentAst> _checks = new();
}
