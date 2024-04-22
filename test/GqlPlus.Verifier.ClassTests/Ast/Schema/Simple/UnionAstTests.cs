using GqlPlus.Verifier.Ast.Schema.Simple;

namespace GqlPlus.Verifier.Ast.Schema.Types;

public class UnionAstTests
  : AstTypeTests
{
  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenParent(string name, string parent1, string parent2)
    => _checks.InequalityBetween(parent1, parent2,
      parent => new UnionDeclAst(AstNulls.At, name, []) { Parent = parent },
      parent1 == parent2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithMembers(string name, string[] unionMembers)
      => _checks.HashCode(
        () => new UnionDeclAst(AstNulls.At, name, unionMembers.UnionMembers()));

  [Theory, RepeatData(Repeats)]
  public void String_WithMembers(string name, string[] unionMembers)
    => _checks.Text(
      () => new UnionDeclAst(AstNulls.At, name, unionMembers.UnionMembers()),
      $"( !U {name} {unionMembers.Joined(s => "!UM " + s)} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithMembers(string name, string[] unionMembers)
    => _checks.Equality(
      () => new UnionDeclAst(AstNulls.At, name, unionMembers.UnionMembers()));

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenUnionMembers(string name, string[] unionMembers1, string[] unionMembers2)
    => _checks.InequalityBetween(unionMembers1, unionMembers2,
      unionMembers => new UnionDeclAst(AstNulls.At, name, unionMembers.UnionMembers()),
      unionMembers1.SequenceEqual(unionMembers2));

  private readonly AstTypeChecks<UnionDeclAst> _checks
    = new(name => new UnionDeclAst(AstNulls.At, name, []));

  internal override IAstTypeChecks TypeChecks => _checks;
}
