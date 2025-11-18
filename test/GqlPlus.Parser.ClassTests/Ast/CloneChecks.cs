namespace GqlPlus.Ast;

internal class CloneChecks<TInput, TAst>(
  BaseAstChecks<TAst>.CreateBy<TInput> createInput,
  BaseAstChecks<TAst>.CloneBy<TInput> cloneInput,
  [CallerArgumentExpression(nameof(createInput))] string createExpression = "",
  [CallerArgumentExpression(nameof(cloneInput))] string cloneExpression = ""
) : AstBaseChecks<TInput, TAst>(createInput, createExpression)
  , ICloneChecks<TInput>
  where TAst : IGqlpError
{
  private readonly CloneBy<TInput> _cloneInput = cloneInput;
  private readonly string _cloneExpression = cloneExpression;

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
