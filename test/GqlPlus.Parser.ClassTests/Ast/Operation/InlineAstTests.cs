namespace GqlPlus.Ast.Operation;

public class InlineAstTests
  : AstDirectivesTests<string[]>
{
  [Theory, RepeatData]
  public void HashCode_WithOnType(string onType, string[] fields)
    => _checks.HashCode(() => new InlineAst(AstNulls.At, fields.Fields()) { OnType = onType });

  [Theory, RepeatData]
  public void String_WithOnType(string onType, string[] fields)
    => _checks.Text(
      () => new InlineAst(AstNulls.At, fields.Fields()) { OnType = onType },
      $"( !i :{onType} {{ {fields.Joined(s => "!f " + s)} }} )");

  [Theory, RepeatData]
  public void Equality_WithOnType(string onType, string[] fields)
    => _checks.Equality(
      () => new InlineAst(AstNulls.At, fields.Fields()) { OnType = onType });

  [Theory, RepeatData]
  public void Inequality_WithOnType(string onType, string[] fields)
    => _checks.InequalityWith(fields,
      () => new InlineAst(AstNulls.At, fields.Fields()) { OnType = onType });

  private readonly AstDirectivesChecks<string[], InlineAst> _checks = new(Inline);

  internal override IAstDirectivesChecks<string[]> DirectivesChecks => _checks;

  protected override string DirectiveString(string[] input, string directives)
    => $"( !i{directives} {{ {input.Joined(s => "!f " + s)} }} )";

  private static InlineAst Inline(string[] input, string[] directives)
    => new(AstNulls.At, input?.Fields() ?? []) { Directives = directives.Directives() };
  protected override bool InputEquals(string[]? input1, string[]? input2)
    => input1 is null ? input2 is null : input2 is not null && input1.SequenceEqual(input2);
}
