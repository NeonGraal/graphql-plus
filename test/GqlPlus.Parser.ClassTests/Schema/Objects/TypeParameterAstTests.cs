using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class TypeParamAstTests : AstAbbreviatedTests
{
  [Theory, RepeatData]
  public void HashCode_WithConstraint(string name, string constraint)
      => _checks.HashCode(
        () => new TypeParamAst(AstNulls.At, name) { Constraint = constraint });

  [Theory, RepeatData]
  public void String_WithConstraint(string name, string constraint)
  => _checks.Text(
      () => new TypeParamAst(AstNulls.At, name) { Constraint = constraint },
      $"( ${name} :{constraint} )");

  [Theory, RepeatData]
  public void Equality_WithConstraint(string name, string constraint)
    => _checks.Equality(
      () => new TypeParamAst(AstNulls.At, name) { Constraint = constraint });

  [Theory, RepeatData]
  public void Inequality_WithConstraint(string name, string constraint)
    => _checks.InequalityWith(name,
      () => new TypeParamAst(AstNulls.At, name) { Constraint = constraint });

  protected override string AbbreviatedString(string input)
    => $"( ${input} )";

  private readonly AstAbbreviatedChecks<TypeParamAst> _checks
    = new(name => new TypeParamAst(AstNulls.At, name));

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
