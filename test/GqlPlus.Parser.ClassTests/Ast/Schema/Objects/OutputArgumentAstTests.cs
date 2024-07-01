using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class OutputArgumentAstTests
  : AstObjectArgumentTests<IGqlpOutputArgument>
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithEnumValue(string name, string enumMember)
      => _checks.HashCode(
        () => new OutputArgumentAst(AstNulls.At, name) { EnumMember = enumMember });

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumValue(string name, string enumMember)
    => _checks.Text(
      () => new OutputArgumentAst(AstNulls.At, name) { EnumMember = enumMember },
      $"( {name}.{enumMember} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumValue(string name, string enumMember)
    => _checks.Equality(
      () => new OutputArgumentAst(AstNulls.At, name) { EnumMember = enumMember });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenEnumValues(string name, string enumValue1, string enumValue2)
    => _checks.InequalityBetween(enumValue1, enumValue2,
      enumMember => new OutputArgumentAst(AstNulls.At, name) { EnumMember = enumMember },
      enumValue1 == enumValue2);

  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjArgumentChecks<IGqlpOutputArgument, OutputArgumentAst> _checks
    = new(name => new OutputArgumentAst(AstNulls.At, name));

  internal override IAstObjArgumentChecks<IGqlpOutputArgument> ObjArgumentChecks => _checks;
}
