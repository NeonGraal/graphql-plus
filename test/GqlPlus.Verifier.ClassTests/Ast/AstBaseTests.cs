using System.Runtime.CompilerServices;

namespace GqlPlus.Verifier.Ast;

[TracePerTest]
public abstract class AstBaseTests<TInput>
{
  [Fact]
  public void HashCode_WithNull()
  => BaseChecks.HashCode(default!);

  [Theory, RepeatData(Repeats)]
  public void HashCode(TInput input)
  => BaseChecks.HashCode(input);

  [Theory, RepeatData(Repeats)]
  public void String(TInput input)
  => BaseChecks.String(input, InputString(input));

  [Theory, RepeatData(Repeats)]
  public void Equality(TInput input)
    => BaseChecks.Equality(input);

  [Theory, RepeatData(Repeats)]
  public void Inequality(TInput input1, TInput input2)
    => BaseChecks.Inequality(input1, input2);

  protected virtual string InputString(TInput input)
    => $"( !{input} )";

  internal abstract IAstBaseChecks<TInput> BaseChecks { get; }
}

internal sealed class AstBaseChecks<TAst>
  : AstBaseChecks<string, TAst>, IAstBaseChecks
  where TAst : AstBase
{
  public AstBaseChecks(CreateBy<string> createInput,
    [CallerArgumentExpression(nameof(createInput))] string createExpression = "")
    : base(createInput, createExpression) { }
}

internal class AstBaseChecks<TInput, TAst>
  : BaseAstChecks<TAst>, IAstBaseChecks<TInput>
  where TAst : AstBase
{
  internal Func<TInput, TInput, bool> SameInput { get; init; }
    = (TInput input1, TInput input2) => input1!.Equals(input2);

  protected readonly CreateBy<TInput> CreateInput;
  protected readonly string _createExpression;

  public AstBaseChecks(CreateBy<TInput> createInput,
    [CallerArgumentExpression(nameof(createInput))] string createExpression = "")
    => (CreateInput, _createExpression) = (createInput, createExpression);

  public void HashCode(TInput input)
    => HashCode(
      () => CreateInput(input) with { At = AstNulls.At },
      _createExpression);

  public void String(TInput input, string expected)
    => String(
      () => CreateInput(input), expected,
      factoryExpression: _createExpression);

  public void Equality(TInput input)
    => Equality(
      () => CreateInput(input), _createExpression);

  public void Inequality(TInput input1, TInput input2)
    => InequalityBetween(input1, input2, CreateInput,
      SameInput(input1, input2), _createExpression);

  public void InequalityWith(TInput input, Creator factory,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
    => Inequality(factory,
      () => CreateInput(input),
      factoryExpression: factoryExpression);
}

internal interface IAstBaseChecks
  : IAstBaseChecks<string>
{ }

internal interface IAstBaseChecks<TInput>
{
  void HashCode(TInput input);
  void String(TInput input, string expected);
  void Equality(TInput input);
  void Inequality(TInput input1, TInput input2);
}
