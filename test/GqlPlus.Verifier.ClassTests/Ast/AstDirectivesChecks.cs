namespace GqlPlus.Verifier.Ast;

internal sealed class AstDirectivesChecks<TAst>
  : AstDirectivesChecks<string, TAst>, IAstDirectivesChecks
  where TAst : AstBase, IAstDirectives
{
  public AstDirectivesChecks(CreateBy<string> create)
    : base(create) { }
}

internal class AstDirectivesChecks<TInput, TAst>
  : AstBaseChecks<TInput, TAst>, IAstDirectivesChecks<TInput>
  where TAst : AstBase, IAstDirectives
{
  public AstDirectivesChecks(CreateBy<TInput> create)
    : base(create) { }

  public void HashCode(TInput input, string[] directives)
    => HashCode(
      () => CreateDirective(input, directives),
      _createExpression);

  public void Equality(TInput input, string[] directives)
    => Equality(
      () => CreateDirective(input, directives),
      _createExpression);

  public void Inequality_WithDirective(TInput input, string[] directives)
    => Inequality(
      () => CreateDirective(input, directives),
      () => CreateInput(input),
      factoryExpression: _createExpression);

  public void Inequality_ByDirectives(TInput input, string[] directive1, string[] directive2)
    => InequalityBetween(directive1, directive2,
      directives => CreateDirective(input, directives),
      directive1.SequenceEqual(directive2), _createExpression);

  public void Inequality_ByInputs(TInput input1, TInput input2, string[] directives)
    => InequalityBetween(input1, input2,
      input => CreateDirective(input, directives),
      input1!.Equals(input2), _createExpression);

  public void String(TInput input, string[] directives, string expected)
    => String(
      () => CreateDirective(input, directives), expected,
      factoryExpression: _createExpression);

  private TAst CreateDirective(TInput input, string[] directives)
    => CreateInput(input) with { Directives = directives.Directives() };
}

internal interface IAstDirectivesChecks
  : IAstDirectivesChecks<string>, IAstBaseChecks
{ }

internal interface IAstDirectivesChecks<I> : IAstBaseChecks<I>
{
  void HashCode(I input, string[] directives);
  void String(I input, string[] directives, string expected);
  void Equality(I input, string[] directives);
  void Inequality_WithDirective(I input, string[] directives);
  void Inequality_ByInputs(I input1, I input2, string[] directives);
  void Inequality_ByDirectives(I input, string[] directives1, string[] directives2);
}
