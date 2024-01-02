namespace GqlPlus.Verifier.Ast.Operation;

public class FragmentAstTests : AstDirectivesTests<FragmentInput>
{
  [Fact]
  public void HashCode_Null()
    => _checks.HashCode(() => new FragmentAst(AstNulls.At, "", ""));

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenName(string name1, string name2, string onType, string[] fields)
  => _checks.InequalityBetween(name1, name2,
      name => new FragmentAst(AstNulls.At, name, onType, fields.Fields()),
      name1 == name2);

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenOnType(string name, string onType1, string onType2, string[] fields)
    => _checks.InequalityBetween(onType1, onType2,
      onType => new FragmentAst(AstNulls.At, name, onType, fields.Fields()),
      onType1 == onType2);

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenFields(string name, string onType, string[] fields1, string[] fields2)
    => _checks.InequalityBetween(fields1, fields2,
      field => new FragmentAst(AstNulls.At, name, onType, field.Fields()),
      fields1.SequenceEqual(fields2));

  internal AstDirectivesChecks<FragmentInput, FragmentAst> _checks
    = new(input => new FragmentAst(AstNulls.At, input.Name, input.OnType, new[] { input.Field }.Fields()));

  internal override IAstDirectivesChecks<FragmentInput> DirectivesChecks => _checks;

  protected override string DirectiveString(FragmentInput input, string directives)
    => $"( !t {input.Name}{directives} :{input.OnType} {{ !f {input.Field} }} )";
}

public record struct FragmentInput(string Name, string OnType, string Field);
