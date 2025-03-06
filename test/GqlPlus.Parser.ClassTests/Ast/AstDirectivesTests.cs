using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Ast;

public abstract class AstDirectivesTests
  : AstDirectivesTests<string>
{ }

public abstract class AstDirectivesTests<TInput>
  : AstAbbreviatedTests<TInput>
{
  [Theory, RepeatData]
  public void HashCode_WithDirective(TInput input, string[] directives)
  => DirectivesChecks.HashCode(input, directives);

  [Theory, RepeatData]
  public void String_WithDirective(TInput input, string[] directives)
    => DirectivesChecks.String(input, directives, DirectiveString(input, Directives(directives)));

  [Theory, RepeatData]
  public void Equality_WithDirective(TInput input, string[] directives)
    => DirectivesChecks.Equality(input, directives);

  [Theory, RepeatData]
  public void Inequality_WithDirective(TInput input, string[] directives)
    => DirectivesChecks.Inequality_WithDirective(input, directives);

  [SkippableTheory, RepeatData]
  public void Inequality_ByDirectives(TInput input, string[] directives1, string[] directives2)
    => DirectivesChecks.Inequality_ByDirectives(input, directives1, directives2);

  [SkippableTheory, RepeatData]
  public void Inequality_ByNames(TInput input1, TInput input2, string[] directives)
    => DirectivesChecks.Inequality_ByInputs(input1, input2, directives);

  protected virtual string DirectiveString(TInput input, string directives)
    => $"( !{AbbreviatedChecks.Abbr} {input}{directives} )";

  protected override string AbbreviatedString(TInput input)
    => DirectiveString(input, "");

  internal sealed override IAstAbbreviatedChecks<TInput> AbbreviatedChecks => DirectivesChecks;

  internal abstract IAstDirectivesChecks<TInput> DirectivesChecks { get; }

  private static string Directives(string[] directives)
    => " " + directives.Joined(d => $"( !d {d} )");
}

internal sealed class AstDirectivesChecks<TAst>(
  BaseAstChecks<TAst>.CreateBy<string> create
) : AstDirectivesChecks<string, TAst>(create), IAstDirectivesChecks
  where TAst : AstAbbreviated, IGqlpDirectives
{
}

internal class AstDirectivesChecks<TInput, TAst>(
  BaseAstChecks<TAst>.CreateBy<TInput> create
) : AstAbbreviatedChecks<TInput, TAst>(create), IAstDirectivesChecks<TInput>
  where TAst : AstAbbreviated, IGqlpDirectives
{
  public void HashCode(TInput input, string[] directives)
    => HashCode(
      () => CreateDirective(input, directives),
      CreateExpression);

  public void Equality(TInput input, string[] directives)
    => Equality(
      () => CreateDirective(input, directives),
      CreateExpression);

  public void Inequality_WithDirective(TInput input, string[] directives)
    => Inequality(
      () => CreateDirective(input, directives),
      () => CreateInput(input),
      factoryExpression: CreateExpression);

  public void Inequality_ByDirectives(TInput input, string[] directive1, string[] directive2)
    => InequalityBetween(directive1, directive2,
      directives => CreateDirective(input, directives),
      directive1.SequenceEqual(directive2), CreateExpression);

  public void Inequality_ByInputs(TInput input1, TInput input2, string[] directives)
    => InequalityBetween(input1, input2,
      input => CreateDirective(input, directives),
      input1.ThrowIfNull().Equals(input2), CreateExpression);

  public void String(TInput input, string[] directives, string expected)
    => Text(
      () => CreateDirective(input, directives), expected,
      factoryExpression: CreateExpression);

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
