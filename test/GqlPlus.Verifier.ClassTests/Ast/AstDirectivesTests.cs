namespace GqlPlus.Verifier.Ast;

public abstract class AstDirectivesTests
  : AstDirectivesTests<string>
{ }

public abstract class AstDirectivesTests<I> : AstBaseTests<I>
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
    => $"( !{NamedChecks.Abbr} {input}{directives} )";

  protected override string InputString(I input)
    => DirectiveString(input, "");

  internal override IAstBaseChecks<I> NamedChecks => DirectivesChecks;

  internal abstract IAstDirectivesChecks<I> DirectivesChecks { get; }

  private static string Directives(string[] directives)
    => " " + directives.Joined(d => $"( !d {d} )");
}
