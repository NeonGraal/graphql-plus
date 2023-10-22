namespace GqlPlus.Verifier.Ast;

public abstract class BaseDirectivesAstTests
  : BaseDirectivesAstTests<string>
{ }

public abstract class BaseDirectivesAstTests<I> : BaseNamedAstTests<I>
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithDirective(I input, string directive)
  => DirectivesChecks.HashCode(input, directive);

  [Theory, RepeatData(Repeats)]
  public void String_WithDirective(I input, string directive)
    => DirectivesChecks.String(input, directive, DirectiveString(input, directive));

  [Theory, RepeatData(Repeats)]
  public void Equality_WithDirective(I input, string directive)
    => DirectivesChecks.Equality(input, directive);

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithDirective(I input, string directive)
    => DirectivesChecks.Inequality_WithDirective(input, directive);

  [Theory, RepeatData(Repeats)]
  public void Inequality_ByDirectives(I input, string directive1, string directive2)
    => DirectivesChecks.Inequality_ByDirectives(input, directive1, directive2);

  [Theory, RepeatData(Repeats)]
  public void Inequality_ByNames(I input1, I input2, string directive)
    => DirectivesChecks.Inequality_ByInputs(input1, input2, directive);

  protected virtual string DirectiveString(I input, string directive)
    => DirectivesChecks.DirectiveString(input, directive);

  internal override IBaseNamedAstChecks<I> NamedChecks => DirectivesChecks;

  internal abstract IBaseDirectivesAstChecks<I> DirectivesChecks { get; }
}
