
namespace GqlPlus.Ast.Schema.Simple;

public class UnionAstTests
  : AstTypeBaseTests
{
  [Theory, RepeatData]
  public void Inequality_BetweenParent(string name, string parent1, string parent2)
    => _checks.InequalityBetween(parent1, parent2,
      parent => new UnionDeclAst(AstNulls.At, name, []) { Parent = _checks.CreateParent(parent) },
      parent1 == parent2);

  [Theory, RepeatData]
  public void HashCode_WithMembers(string name, string[] unionMembers)
      => _checks.HashCode(
        () => new UnionDeclAst(AstNulls.At, name, unionMembers.UnionMembers()));

  [Theory, RepeatData]
  public void Text_WithMembers(string name, string[] unionMembers)
    => _checks.Text(
      () => new UnionDeclAst(AstNulls.At, name, unionMembers.UnionMembers()),
      $"( !Un {name} {unionMembers.Joined(s => "!UM " + s)} )");

  [Theory, RepeatData]
  public void Equality_WithMembers(string name, string[] unionMembers)
    => _checks.Equality(
      () => new UnionDeclAst(AstNulls.At, name, unionMembers.UnionMembers()));

  [Theory, RepeatData]
  public void HasValue_WithMember(string name, string unionMember)
  {
    UnionDeclAst union = new(AstNulls.At, name, new[] { unionMember }.UnionMembers());

    bool result = union.HasValue(unionMember);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Inequality_BetweenUnionMembers(string name, string[] unionMembers1, string[] unionMembers2)
    => _checks.InequalityBetween(unionMembers1, unionMembers2,
      unionMembers => new UnionDeclAst(AstNulls.At, name, unionMembers.UnionMembers()),
      unionMembers1.SequenceEqual(unionMembers2));

  private readonly AstTypeChecks<UnionDeclAst> _checks
    = new(CreateUnion);

  private static UnionDeclAst CloneUnion(UnionDeclAst original, string input)
    => original with { Name = input };
  private static UnionDeclAst CreateUnion(string input)
    => new(AstNulls.At, input, []);

  internal override IAstTypeChecks TypeChecks => _checks;
}
