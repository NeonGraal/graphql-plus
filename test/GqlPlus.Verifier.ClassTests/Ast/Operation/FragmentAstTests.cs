namespace GqlPlus.Verifier.Ast.Operation;

public class FragmentAstTests : BaseNamedDirectivesAstTests<FragmentInput>
{
  [Fact]
  public void HashCode_Null()
    => _checks.HashCode(() => new FragmentAst(AstNulls.At, "", ""));

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenName(string name1, string name2, string onType, string field)
  => _checks.InequalityBetween(name1, name2,
      name => new FragmentAst(AstNulls.At, name, onType, field.Fields()),
      name1 == name2);

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenOnType(string name, string onType1, string onType2, string field)
    => _checks.InequalityBetween(onType1, onType2,
      onType => new FragmentAst(AstNulls.At, name, onType, field.Fields()),
      onType1 == onType2);

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenFields(string name, string onType, string field1, string field2)
    => _checks.InequalityBetween(field1, field2,
      field => new FragmentAst(AstNulls.At, name, onType, field.Fields()),
      field1 == field2);

  internal BaseNamedDirectivesAstChecks<FragmentInput, FragmentAst> _checks
    = new(input => new FragmentAst(AstNulls.At, input.Name, input.OnType, input.Field.Fields()));

  internal override IBaseNamedDirectivesAstChecks<FragmentInput> DirectivesChecks => _checks;

  protected override string ExpectedString(FragmentInput input)
    => $"( !T {input.Name} :{input.OnType} {{ !F {input.Field} }} )";

  protected override string ExpectedString(FragmentInput input, string directive)
    => $"( !T {input.Name} ( !D {directive} ) :{input.OnType} {{ !F {input.Field} }} )";
}

public record struct FragmentInput(string Name, string OnType, string Field);
