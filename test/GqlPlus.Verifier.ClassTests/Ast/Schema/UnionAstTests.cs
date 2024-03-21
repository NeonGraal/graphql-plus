namespace GqlPlus.Verifier.Ast.Schema;

public class UnionAstTests
  : AstAliasedTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithParent(string name, string parent)
      => _checks.HashCode(
        () => new UnionDeclAst(AstNulls.At, name, []) { Parent = parent });

  [Theory, RepeatData(Repeats)]
  public void String_WithParent(string name, string parent)
    => _checks.Text(
      () => new UnionDeclAst(AstNulls.At, name, []) { Parent = parent },
      $"( !U {name} :{parent} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithParent(string name, string parent)
    => _checks.Equality(
      () => new UnionDeclAst(AstNulls.At, name, []) { Parent = parent });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenParent(string name, string parent1, string parent2)
    => _checks.InequalityBetween(parent1, parent2,
      parent => new UnionDeclAst(AstNulls.At, name, []) { Parent = parent },
      parent1 == parent2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithMembers(string name, string[] unionMembers)
      => _checks.HashCode(
        () => new UnionDeclAst(AstNulls.At, name, unionMembers));

  [Theory, RepeatData(Repeats)]
  public void String_WithMembers(string name, string[] unionMembers)
    => _checks.Text(
      () => new UnionDeclAst(AstNulls.At, name, unionMembers),
      $"( !U {name} {unionMembers.Joined()} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithMembers(string name, string[] unionMembers)
    => _checks.Equality(
      () => new UnionDeclAst(AstNulls.At, name, unionMembers));

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenUnionMembers(string name, string[] unionMembers1, string[] unionMembers2)
    => _checks.InequalityBetween(unionMembers1, unionMembers2,
      unionMembers => new UnionDeclAst(AstNulls.At, name, unionMembers),
      unionMembers1.SequenceEqual(unionMembers2));

  private readonly AstAliasedChecks<UnionDeclAst> _checks
    = new(name => new UnionDeclAst(AstNulls.At, name, [])) {
      SameInput = (name1, name2) => name1.Camelize() == name2.Camelize()
    };

  internal override IAstAliasedChecks<string> AliasedChecks => _checks;
}
