
namespace GqlPlus.Ast.Schema.Simple;

public class EnumAstTests
  : AstTypeTests
{
  [Theory, RepeatData]
  public void HashCode_WithLabels(string name, string[] enumLabels)
      => _checks.HashCode(
        () => new EnumDeclAst(AstNulls.At, name, enumLabels.EnumLabels()));

  [Theory, RepeatData]
  public void Text_WithLabels(string name, string[] enumLabels)
    => _checks.Text(
      () => new EnumDeclAst(AstNulls.At, name, enumLabels.EnumLabels()),
      $"( !En {name} {enumLabels.Joined(s => "!EL " + s)} )");

  [Theory, RepeatData]
  public void Equality_WithLabels(string name, string[] enumLabels)
    => _checks.Equality(
      () => new EnumDeclAst(AstNulls.At, name, enumLabels.EnumLabels()));

  [Theory, RepeatData]
  public void HasValue_WithLabel(string name, string enumLabel)
  {
    EnumDeclAst enumType = new(AstNulls.At, name, new[] { enumLabel }.EnumLabels());

    bool result = enumType.HasValue(enumLabel);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Inequality_BetweenLabels(string name, string[] enumLabels1, string[] enumLabels2)
    => _checks.InequalityBetween(enumLabels1, enumLabels2,
      enumLabel => new EnumDeclAst(AstNulls.At, name, enumLabel.EnumLabels()),
      enumLabels1.SequenceEqual(enumLabels2));

  private readonly AstTypeChecks<EnumDeclAst> _checks
    = new(CreateEnum, CloneEnum);

  private static EnumDeclAst CloneEnum(EnumDeclAst original, string input)
    => original with { Name = input };
  private static EnumDeclAst CreateEnum(string input)
    => new(AstNulls.At, input, []);

  internal override IAstTypeChecks TypeChecks => _checks;
}
