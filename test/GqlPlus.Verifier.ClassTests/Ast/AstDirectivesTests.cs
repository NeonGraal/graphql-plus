namespace GqlPlus.Verifier.Ast;

public abstract class AstDirectivesTests
  : AstDirectivesTests<string>
{ }

public abstract class AstDirectivesTests<I>
  : AstAbbreviatedTests<I>
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithDirective(I input, string[] directives)
  => DirectivesChecks.HashCode(input, directives);

  [Theory, RepeatData(Repeats)]
  public void String_WithDirective(I input, string[] directives)
    => DirectivesChecks.String(input, directives, DirectiveString(input, Directives(directives)));

  [Theory, RepeatData(Repeats)]
  public void Equality_WithDirective(I input, string[] directives)
    => DirectivesChecks.Equality(input, directives);

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithDirective(I input, string[] directives)
    => DirectivesChecks.Inequality_WithDirective(input, directives);

  [Theory, RepeatData(Repeats)]
  public void Inequality_ByDirectives(I input, string[] directives1, string[] directives2)
    => DirectivesChecks.Inequality_ByDirectives(input, directives1, directives2);

  [Theory, RepeatData(Repeats)]
  public void Inequality_ByNames(I input1, I input2, string[] directives)
    => DirectivesChecks.Inequality_ByInputs(input1, input2, directives);

  protected virtual string DirectiveString(I input, string directives)
    => $"( !{AbbreviatedChecks.Abbr} {input}{directives} )";

  protected override string AbbreviatedString(I input)
    => DirectiveString(input, "");

  internal sealed override IAstAbbreviatedChecks<I> AbbreviatedChecks => DirectivesChecks;

  internal abstract IAstDirectivesChecks<I> DirectivesChecks { get; }

  private static string Directives(string[] directives)
    => " " + directives.Joined(d => $"( !d {d} )");
}

internal sealed class AstDirectivesChecks<TAst>
  : AstDirectivesChecks<string, TAst>, IAstDirectivesChecks
  where TAst : AstAbbreviated, IAstDirectives
{
  public AstDirectivesChecks(CreateBy<string> create)
    : base(create) { }
}

internal class AstDirectivesChecks<TInput, TAst>
  : AstAbbreviatedChecks<TInput, TAst>, IAstDirectivesChecks<TInput>
  where TAst : AstAbbreviated, IAstDirectives
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

internal interface IAstDirectivesChecks<I> : IAstAbbreviatedChecks<I>
{
  void HashCode(I input, string[] directives);
  void String(I input, string[] directives, string expected);
  void Equality(I input, string[] directives);
  void Inequality_WithDirective(I input, string[] directives);
  void Inequality_ByInputs(I input1, I input2, string[] directives);
  void Inequality_ByDirectives(I input, string[] directives1, string[] directives2);
}
