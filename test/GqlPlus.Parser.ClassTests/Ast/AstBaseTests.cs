using System.Runtime.CompilerServices;

namespace GqlPlus.Ast;

[TracePerTest]
public abstract class AstBaseTests<TInput>
{
  [Fact]
  public void HashCode_WithNull()
  => BaseChecks.HashCode_WithInput(default!);

  [Theory, RepeatData]
  public void HashCode_WithInput(TInput input)
  => BaseChecks.HashCode_WithInput(input);

  [Theory, RepeatData]
  public void Text_WithInput(TInput input)
  => BaseChecks.Text_WithInput(input);

  [Theory, RepeatData]
  public void Clone_WithInput(TInput input)
    => BaseChecks.Clone_WithInput(input);

  [Theory, RepeatData]
  public void Equality_WithInput(TInput input)
    => BaseChecks.Equality_WithInput(input);

  [Theory, RepeatData]
  public void Inequality_WithInputs(TInput input1, TInput input2)
    => BaseChecks
      .SkipIf(SameInput(input1, input2))
      .Inequality_WithInputs(input1, input2);

  protected virtual Func<TInput, TInput, bool> SameInput { get; }
    = (input1, input2) => input1.ThrowIfNull().Equals(input2);

  protected virtual string InputString(TInput input)
    => $"( !{input} )";

  internal abstract IAstBaseChecks<TInput> BaseChecks { get; }
}

internal class AstBaseChecks<TInput, TAst>
  : BaseAstChecks<TAst>
  , IAstBaseChecks<TInput>
  where TAst : IGqlpError
{
  protected readonly CreateBy<TInput> CreateInput;
  protected readonly CloneBy<TInput> CloneInput;
  protected readonly string CreateExpression;

  public AstBaseChecks(CreateBy<TInput> createInput, CloneBy<TInput> cloneInput,
    [CallerArgumentExpression(nameof(createInput))] string createExpression = "")
    => (CreateInput, CreateExpression, CloneInput) = (createInput, createExpression, cloneInput);

  public void HashCode_WithInput(TInput input)
    => HashCode(
      () => CreateInput(input),
      CreateExpression);

  public void Text_WithInput(TInput input)
    => Text(
      () => CreateInput(input),
      InputString(input),
      factoryExpression: CreateExpression);

  public void Clone_WithInput(TInput input)
  {
    TAst item1 = CreateInput(input);
    Equality(
        () => item1,
        () => CloneInput(item1, input),
        CreateExpression);
  }

  public void Equality_WithInput(TInput input)
    => Equality(
      () => CreateInput(input),
      CreateExpression);

  public void Inequality_WithInputs(TInput input1, TInput input2)
    => InequalityBetween(input1, input2, CreateInput, CreateExpression);

  public void InequalityWith(TInput input, AstCreator factory,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
    => Inequality(factory,
      () => CreateInput(input),
      factory1Expression: factoryExpression);

  protected virtual string InputString(TInput input)
    => $"( !{input} )";
}

internal interface IAstBaseChecks
  : IAstBaseChecks<string>
{ }

internal interface IAstBaseChecks<TInput>
{
  void HashCode_WithInput(TInput input);
  void Text_WithInput(TInput input);
  void Clone_WithInput(TInput input);
  void Equality_WithInput(TInput input);
  void Inequality_WithInputs(TInput input1, TInput input2);
}
