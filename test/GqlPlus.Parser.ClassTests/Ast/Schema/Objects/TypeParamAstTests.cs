using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace GqlPlus.Ast.Schema.Objects;

public class TypeParamAstTests
  : AstAbbreviatedTests
{
  [Theory, RepeatData]
  public void HashCode_WithConstraint(string name, string constraint)
      => _checks.HashCode(
        () => new TypeParamAst(AstNulls.At, name) { Constraint = constraint });

  [Theory, RepeatData]
  public void Text_WithConstraint(string name, string constraint)
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

  private readonly TypeParamAstChecks _checks = new();

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}

internal sealed class TypeParamAstChecks()
  : AstAbbreviatedChecks<TypeParamAst>(CreateTypeParam, CloneTypeParam)
{
  protected override string AbbreviatedString(string input)
    => $"( ${input} )";

  private static TypeParamAst CloneTypeParam(TypeParamAst original, string input)
    => original with { Name = input };
  private static TypeParamAst CreateTypeParam(string input)
    => new(AstNulls.At, input);
}
