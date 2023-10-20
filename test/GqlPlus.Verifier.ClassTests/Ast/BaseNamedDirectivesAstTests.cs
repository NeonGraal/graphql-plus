namespace GqlPlus.Verifier.Ast;

public abstract class BaseNamedDirectivesAstTests : BaseNamedAstTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithDirective(string name, string directive)
    => DirectivesChecks.HashCode(name, directive);

  [Theory, RepeatData(Repeats)]
  public void String_WithDirective(string name, string directive)
    => DirectivesChecks.String(name, directive, ExpectedString(name, directive));

  [Theory, RepeatData(Repeats)]
  public void Equality_WithDirective(string name, string directive)
    => DirectivesChecks.Equality(name, directive);

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithDirective(string name, string directive)
    => DirectivesChecks.Inequality(name, directive);

  [Theory, RepeatData(Repeats)]
  public void Inequality_ByDirectives(string name, string directive1, string directive2)
    => DirectivesChecks.Inequality_ByDirectives(name, directive1, directive2);

  [Theory, RepeatData(Repeats)]
  public void Inequality_ByNames(string name1, string name2, string directive)
    => DirectivesChecks.Inequality_ByNames(name1, name2, directive);

  protected virtual string ExpectedString(string name, string directive)
    => DirectivesChecks.ExpectedString(name, directive);

  internal override BaseNamedAstChecks NamedChecks => DirectivesChecks;

  internal abstract BaseNamedDirectivesAstChecks DirectivesChecks { get; }
}
