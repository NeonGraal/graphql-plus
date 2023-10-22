namespace GqlPlus.Verifier.Ast;

public abstract class BaseNamedAstTests
  : BaseNamedAstTests<string>
{ }

public abstract class BaseNamedAstTests<I>
{
  [Fact]
  public void HashCode_WithNull()
  => NamedChecks.HashCode(default!);

  [Theory, RepeatData(Repeats)]
  public void HashCode(I input)
  => NamedChecks.HashCode(input);

  [Theory, RepeatData(Repeats)]
  public void String(I input)
  => NamedChecks.String(input, InputString(input));

  [Theory, RepeatData(Repeats)]
  public void Equality(I input)
    => NamedChecks.Equality(input);

  [Theory, RepeatData(Repeats)]
  public void Inequality(I input1, I input2)
    => NamedChecks.Inequality(input1, input2);

  protected virtual string InputString(I input)
    => NamedChecks.InputString(input);

  internal abstract IBaseNamedAstChecks<I> NamedChecks { get; }
}
