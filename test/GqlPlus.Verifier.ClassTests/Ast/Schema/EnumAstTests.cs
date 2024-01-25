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
  public void HashCode_WithMembers(string name, string[] enumMembers)
      => _checks.HashCode(
        () => new EnumDeclAst(AstNulls.At, name) { Members = enumMembers.EnumMembers() });

  [Theory, RepeatData(Repeats)]
  public void String_WithMembers(string name, string[] enumMembers)
    => _checks.String(
      () => new EnumDeclAst(AstNulls.At, name) { Members = enumMembers.EnumMembers() },
      $"( !E {name} {enumMembers.Joined("!EM ")} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithMembers(string name, string[] enumMembers)
    => _checks.Equality(
      () => new EnumDeclAst(AstNulls.At, name) { Members = enumMembers.EnumMembers() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenEnumMembers(string name, string[] enumMembers1, string[] enumMembers2)
    => _checks.InequalityBetween(enumMembers1, enumMembers2,
      enumMember => new EnumDeclAst(AstNulls.At, name) { Members = enumMember.EnumMembers() },
      enumMembers1.SequenceEqual(enumMembers2));

  private readonly AstAliasedChecks<EnumDeclAst> _checks
    = new(name => new EnumDeclAst(AstNulls.At, name)) {
      SameInput = (name1, name2) => name1.Camelize() == name2.Camelize()
    };

  internal override IAstAliasedChecks<string> AliasedChecks => _checks;
}
