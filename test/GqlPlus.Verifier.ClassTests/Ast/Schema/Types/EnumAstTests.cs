namespace GqlPlus.Verifier.Ast.Schema.Types;

public class EnumAstTests : AstAliasedTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithParent(string name, string parent)
      => _checks.HashCode(
        () => new EnumDeclAst(AstNulls.At, name) { Parent = parent });

  [Theory, RepeatData(Repeats)]
  public void String_WithParent(string name, string parent)
    => _checks.Text(
      () => new EnumDeclAst(AstNulls.At, name) { Parent = parent },
      $"( !E {name} :{parent} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithParent(string name, string parent)
    => _checks.Equality(
      () => new EnumDeclAst(AstNulls.At, name) { Parent = parent });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenParent(string name, string parent1, string parent2)
    => _checks.InequalityBetween(parent1, parent2,
      parent => new EnumDeclAst(AstNulls.At, name) { Parent = parent },
      parent1 == parent2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithMembers(string name, string[] enumMembers)
      => _checks.HashCode(
        () => new EnumDeclAst(AstNulls.At, name) { Members = enumMembers.EnumMembers() });

  [Theory, RepeatData(Repeats)]
  public void String_WithMembers(string name, string[] enumMembers)
    => _checks.Text(
      () => new EnumDeclAst(AstNulls.At, name) { Members = enumMembers.EnumMembers() },
      $"( !E {name} {enumMembers.Joined(s => "!EM " + s)} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithMembers(string name, string[] enumMembers)
    => _checks.Equality(
      () => new EnumDeclAst(AstNulls.At, name) { Members = enumMembers.EnumMembers() });

  [SkippableTheory, RepeatData(Repeats)]
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
