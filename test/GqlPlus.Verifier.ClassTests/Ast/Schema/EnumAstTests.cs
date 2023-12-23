namespace GqlPlus.Verifier.Ast.Schema;

public class EnumAstTests : AstAliasedTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithExtends(string name, string extends)
      => _checks.HashCode(
        () => new EnumDeclAst(AstNulls.At, name) { Extends = extends });

  [Theory, RepeatData(Repeats)]
  public void String_WithExtends(string name, string extends)
    => _checks.String(
      () => new EnumDeclAst(AstNulls.At, name) { Extends = extends },
      $"( !E {name} :{extends} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithExtends(string name, string extends)
    => _checks.Equality(
      () => new EnumDeclAst(AstNulls.At, name) { Extends = extends });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenExtends(string name, string extends1, string extends2)
    => _checks.InequalityBetween(extends1, extends2,
      extends => new EnumDeclAst(AstNulls.At, name) { Extends = extends },
      extends1 == extends2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithEnumValues(string name, string[] enumValues)
      => _checks.HashCode(
        () => new EnumDeclAst(AstNulls.At, name) { Values = enumValues.EnumValues() });

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumValues(string name, string[] enumValues)
    => _checks.String(
      () => new EnumDeclAst(AstNulls.At, name) { Values = enumValues.EnumValues() },
      $"( !E {name} {enumValues.Joined("!EV ")} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumValues(string name, string[] enumValues)
    => _checks.Equality(
      () => new EnumDeclAst(AstNulls.At, name) { Values = enumValues.EnumValues() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenEnumValues(string name, string[] enumValues1, string[] enumValues2)
    => _checks.InequalityBetween(enumValues1, enumValues2,
      enumValue => new EnumDeclAst(AstNulls.At, name) { Values = enumValue.EnumValues() },
      enumValues1.SequenceEqual(enumValues2));

  private readonly AstAliasedChecks<EnumDeclAst> _checks
    = new(name => new EnumDeclAst(AstNulls.At, name)) {
      SameInput = (name1, name2) => name1.Camelize() == name2.Camelize()
    };

  internal override IAstAliasedChecks<string> AliasedChecks => _checks;
}
