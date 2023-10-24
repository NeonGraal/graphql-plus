namespace GqlPlus.Verifier.Ast;

internal sealed class BaseDirectivesAstChecks<T>
  : BaseDirectivesAstChecks<string, T>, IBaseDirectivesAstChecks
  where T : AstBase, IAstDirectives
{
  public BaseDirectivesAstChecks(CreateBy<string> create)
    : base(create) { }
}

internal class BaseDirectivesAstChecks<I, T>
  : BaseNamedAstChecks<I, T>, IBaseDirectivesAstChecks<I>
  where T : AstBase, IAstDirectives
{
  public BaseDirectivesAstChecks(CreateBy<I> create)
    : base(create) { }

  public void HashCode(I input, string directive)
    => HashCode(
      () => CreateDirective(input, directive),
      _createExpression);

  public void Equality(I input, string directive)
    => Equality(
      () => CreateDirective(input, directive),
      _createExpression);

  public void Inequality_WithDirective(I input, string directive)
    => Inequality(
      () => CreateDirective(input, directive),
      () => CreateInput(input),
      factoryExpression: _createExpression);

  public void Inequality_ByDirectives(I input, string directive1, string directive2)
    => InequalityBetween(directive1, directive2,
      directive => CreateDirective(input, directive),
      directive1 == directive2, _createExpression);

  public void Inequality_ByInputs(I input1, I input2, string directive)
    => InequalityBetween(input1, input2,
      input => CreateDirective(input, directive),
      input1!.Equals(input2), _createExpression);

  public void String(I input, string directive, string expected)
    => String(
      () => CreateDirective(input, directive), expected,
      factoryExpression: _createExpression);

  public string DirectiveString(I input, string directive)
    => $"( !{Abbr} {input} ( !d {directive} ) )";

  private T CreateDirective(I input, string directive)
  {
    var t = CreateInput(input);
    t.Directives = directive.Directives();
    return t;
  }
}

internal interface IBaseDirectivesAstChecks
  : IBaseDirectivesAstChecks<string>, IBaseNamedAstChecks
{ }

internal interface IBaseDirectivesAstChecks<I> : IBaseNamedAstChecks<I>
{
  void HashCode(I input, string directive);
  void String(I input, string directive, string expected);
  void Equality(I input, string directive);
  void Inequality_WithDirective(I input, string directive);
  void Inequality_ByInputs(I input1, I input2, string directive);
  void Inequality_ByDirectives(I input, string directive1, string directive2);
  string DirectiveString(I input, string directive);
}
