namespace GqlPlus.Ast.Schema.Objects;

public partial class TypeParamAstTests
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

  [CheckTests(Inherited = true)]
  internal IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;

  [CheckTests]
  internal ICloneChecks<string> CloneChecks { get; }
    = new CloneChecks<string, TypeParamAst>(
      CreateTypeParam,
      (original, input) => original with { Name = input });

  internal static TypeParamAst CreateTypeParam(string input)
    => new(AstNulls.At, input);
}

internal sealed class TypeParamAstChecks()
  : AstAbbreviatedChecks<TypeParamAst>(TypeParamAstTests.CreateTypeParam)
{
  protected override string AbbreviatedString(string input)
    => $"( ${input} )";
}
