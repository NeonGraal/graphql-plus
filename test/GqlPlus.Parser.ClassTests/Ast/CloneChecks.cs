namespace GqlPlus.Ast;

internal sealed class CloneChecks<TInput, TAst>
  : AstBaseChecks<TInput, TAst>
  , ICloneChecks<TInput>
  where TAst : IGqlpError
{
  private readonly CloneBy<TInput> _cloneInput;
  private readonly string _cloneExpression;

  public CloneChecks(CreateBy<TInput> createInput, CloneBy<TInput> cloneInput,
    [CallerArgumentExpression(nameof(createInput))] string createExpression = "",
    [CallerArgumentExpression(nameof(cloneInput))] string cloneExpression = "")
    : base(createInput, createExpression)
    => (_cloneExpression, _cloneInput) = (cloneExpression, cloneInput);

  public void Clone_WithInput(TInput input)
  {
    TAst item1 = CreateInput(input);
    Equality(
        () => item1,
        () => _cloneInput(item1, input),
        _cloneExpression);
  }
}

internal interface ICloneChecks<TInput>
{
  void Clone_WithInput(TInput input);
}
