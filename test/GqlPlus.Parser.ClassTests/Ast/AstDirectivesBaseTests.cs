using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Ast;

public abstract class AstDirectivesBaseTests<TInput>
  : AstAbbreviatedBaseTests<TInput>
{
  [Theory, RepeatData]
  public void HashCode_WithDirectives(TInput input, string[] directives)
  => DirectivesChecks.HashCode_WithDirectives(input, directives);

  [Theory, RepeatData]
  public void Text_WithDirectives(TInput input, string[] directives)
    => DirectivesChecks.Text_WithDirectives(input, directives);

  [Theory, RepeatData]
  public void Equality_WithDirectives(TInput input, string[] directives)
    => DirectivesChecks.Equality_WithDirectives(input, directives);

  [Theory, RepeatData]
  public void Inequality_WithDirectives(TInput input, string[] directives)
    => DirectivesChecks.Inequality_WithDirectives(input, directives);

  [Theory, RepeatData]
  public void Inequality_ByDirectives_WithInput(TInput input, string[] directives1, string[] directives2)
    => DirectivesChecks.Inequality_ByDirectives_WithInput(input, directives1, directives2);

  [Theory, RepeatData]
  public void Inequality_ByInputs_WithDirectives(TInput input1, TInput input2, string[] directives)
    => DirectivesChecks.Inequality_ByInputs_WithDirectives(input1, input2, directives);

  internal sealed override IAstAbbreviatedChecks<TInput> AbbreviatedChecks => DirectivesChecks;

  internal abstract IAstDirectivesChecks<TInput> DirectivesChecks { get; }
}

internal class AstDirectivesChecks<TAst>(
  AstDirectivesChecks<string, TAst>.CreateDirectives<string> createDirectives
) : AstDirectivesChecks<string, TAst>(createDirectives)
  , IAstDirectivesChecks
  where TAst : IGqlpDirectives
{ }

internal class AstDirectivesChecks<TInput, TAst>(
  AstDirectivesChecks<TInput, TAst>.CreateDirectives<TInput> createDirectives
) : AstAbbreviatedChecks<TInput, TAst>(i => createDirectives(i, []))
  , IAstDirectivesChecks<TInput>
  where TAst : IGqlpDirectives
{
  internal delegate TAst CreateDirectives<TBy>(TBy input, string[] directives);

  public void HashCode_WithDirectives(TInput input, string[] directives)
    => HashCode(
      () => createDirectives(input, directives),
      CreateExpression);

  public void Equality_WithDirectives(TInput input, string[] directives)
    => Equality(
      () => createDirectives(input, directives),
      CreateExpression);

  public void Inequality_WithDirectives(TInput input, string[] directives)
    => Inequality(
      () => createDirectives(input, directives),
      () => CreateInput(input),
      factory1Expression: CreateExpression);

  public void Inequality_WithDirectivesObject(TInput input, string[] directives)
    => Inequality(
      () => createDirectives(input, directives),
      () => new TestDirectives(directives),
      CreateExpression);

  public void Inequality_ByDirectives_WithInput(TInput input, string[] directive1, string[] directive2)
    => this.SkipEqual(directive1, directive2)
    .InequalityBetween(directive1, directive2,
      directives => createDirectives(input, directives),
      directive1.SequenceEqual(directive2), CreateExpression);

  public void Inequality_ByInputs_WithDirectives(TInput input1, TInput input2, string[] directives)
    => this.SkipEqual(input1, input2)
    .InequalityBetween(input1, input2,
      input => createDirectives(input, directives),
      input1.ThrowIfNull().Equals(input2), CreateExpression);

  public void Text_WithDirectives(TInput input, string[] directives)
    => Text(
      () => createDirectives(input, directives),
      DirectiveString(input, Directives(directives)),
      factoryExpression: CreateExpression);

  protected virtual string DirectiveString(TInput input, string directives)
    => $"( !{Abbr} {input}{directives} )";

  protected override string AbbreviatedString(TInput input)
    => DirectiveString(input, "");

  private static string Directives(string[] directives)
    => " " + directives.Joined(d => $"( !d {d} )");

  private sealed record class TestDirectives
    : AstAbbreviated
    , IGqlpDirectives
  {
    public TestDirectives(string[] directives)
      : base(AstNulls.At)
      => Directives = directives.Directives();

    public IEnumerable<IGqlpDirective> Directives { get; }
    internal override string Abbr => "Te";
  }
}

internal interface IAstDirectivesChecks
  : IAstDirectivesChecks<string>
{ }

internal interface IAstDirectivesChecks<TInput>
  : IAstAbbreviatedChecks<TInput>
{
  void HashCode_WithDirectives(TInput input, string[] directives);
  void Text_WithDirectives(TInput input, string[] directives);
  void Equality_WithDirectives(TInput input, string[] directives);
  void Inequality_WithDirectivesObject(TInput input, string[] directives);
  void Inequality_WithDirectives(TInput input, string[] directives);
  void Inequality_ByInputs_WithDirectives(TInput input1, TInput input2, string[] directives);
  void Inequality_ByDirectives_WithInput(TInput input, string[] directives1, string[] directives2);
}
