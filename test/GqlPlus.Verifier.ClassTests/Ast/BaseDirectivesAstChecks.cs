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

  public void HashCode(I input, string[] directives)
    => HashCode(
      () => CreateDirective(input, directives),
      _createExpression);

  public void Equality(I input, string[] directives)
    => Equality(
      () => CreateDirective(input, directives),
      _createExpression);

  public void Inequality_WithDirective(I input, string[] directives)
    => Inequality(
      () => CreateDirective(input, directives),
      () => CreateInput(input),
      factoryExpression: _createExpression);

  public void Inequality_ByDirectives(I input, string[] directive1, string[] directive2)
    => InequalityBetween(directive1, directive2,
      directives => CreateDirective(input, directives),
      directive1.SequenceEqual(directive2), _createExpression);

  public void Inequality_ByInputs(I input1, I input2, string[] directives)
    => InequalityBetween(input1, input2,
      input => CreateDirective(input, directives),
      input1!.Equals(input2), _createExpression);

  public void String(I input, string[] directives, string expected)
    => String(
      () => CreateDirective(input, directives), expected,
      factoryExpression: _createExpression);

  public string DirectiveString(I input, string[] directives)
    => $"( !{Abbr} {input} {directives.Joined(d => $"( !d {d} )")} )";

  private T CreateDirective(I input, string[] directives)
  {
    var t = CreateInput(input);
    t.Directives = directives.Directives();
    return t;
  }
}

internal interface IBaseDirectivesAstChecks
  : IBaseDirectivesAstChecks<string>, IBaseNamedAstChecks
{ }

internal interface IBaseDirectivesAstChecks<I> : IBaseNamedAstChecks<I>
{
  void HashCode(I input, string[] directives);
  void String(I input, string[] directives, string expected);
  void Equality(I input, string[] directives);
  void Inequality_WithDirective(I input, string[] directives);
  void Inequality_ByInputs(I input1, I input2, string[] directives);
  void Inequality_ByDirectives(I input, string[] directives1, string[] directives2);
  string DirectiveString(I input, string[] directives);
}
