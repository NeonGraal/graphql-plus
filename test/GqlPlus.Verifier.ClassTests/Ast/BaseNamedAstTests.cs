namespace GqlPlus.Verifier.Ast;

public abstract class BaseNamedAstTests
{
  [Fact]
  public void HashCode()
    => NamedChecks.HashCode("");

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithName(string name)
  => NamedChecks.HashCode(name);

  [Theory, RepeatData(Repeats)]
  public void String(string name)
  => NamedChecks.String(name, ExpectedString(name));

  [Theory, RepeatData(Repeats)]
  public void Equality(string output)
    => NamedChecks.Equality(output);

  [Theory, RepeatData(Repeats)]
  public void Inequality(string output1, string output2)
    => NamedChecks.Inequality(output1, output2);

  protected virtual string ExpectedString(string name)
    => NamedChecks.ExpectedString(name);

  internal abstract BaseNamedAstChecks NamedChecks { get; }
}
