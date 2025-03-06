using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Schema.Simple;

public class EnumAstTests
  : AstTypeTests
{
  [Theory, RepeatData]
  public void HashCode_WithMembers(string name, string[] enumMembers)
      => _checks.HashCode(
        () => new EnumDeclAst(AstNulls.At, name, enumMembers.EnumMembers()));

  [Theory, RepeatData]
  public void String_WithMembers(string name, string[] enumMembers)
    => _checks.Text(
      () => new EnumDeclAst(AstNulls.At, name, enumMembers.EnumMembers()),
      $"( !En {name} {enumMembers.Joined(s => "!EM " + s)} )");

  [Theory, RepeatData]
  public void Equality_WithMembers(string name, string[] enumMembers)
    => _checks.Equality(
      () => new EnumDeclAst(AstNulls.At, name, enumMembers.EnumMembers()));

  [SkippableTheory, RepeatData]
  public void Inequality_BetweenEnumMembers(string name, string[] enumMembers1, string[] enumMembers2)
    => _checks.InequalityBetween(enumMembers1, enumMembers2,
      enumMember => new EnumDeclAst(AstNulls.At, name, enumMember.EnumMembers()),
      enumMembers1.SequenceEqual(enumMembers2));

  private readonly AstTypeChecks<EnumDeclAst> _checks
    = new(name => new EnumDeclAst(AstNulls.At, name, []));

  internal override IAstTypeChecks TypeChecks => _checks;
}
