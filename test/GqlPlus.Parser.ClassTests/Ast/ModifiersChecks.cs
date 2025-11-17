namespace GqlPlus.Ast;

internal class ModifiersChecks<TInput, TAst>(
  BaseAstChecks<TAst>.CreateBy<TInput> createInput,
  Func<TAst, TAst> addModifiers,
  [CallerArgumentExpression(nameof(createInput))] string createExpression = ""
) : AstAbbreviatedChecks<TInput, TAst>(createInput, createExpression)
  , IModifiersChecks<TInput>
  where TAst : IGqlpModifiers
{
  public void Equality_WithModifiers(TInput input)
    => Equality(() => addModifiers(CreateInput(input)));
  public void HashCode_WithModifiers(TInput input)
    => HashCode(() => addModifiers(CreateInput(input)));
  public void Inequality_WithModifiers(TInput input)
    => InequalityWith(input, () => addModifiers(CreateInput(input)));
  public void Text_WithModifiers(TInput input)
    => Text(() => addModifiers(CreateInput(input)), ModifiersString(input));

  private string ModifiersString(TInput input)
    => InputString(input)
    .Replace(" )", " [] ? )", StringComparison.Ordinal);
}

internal interface IModifiersChecks<TInput>
{
  void HashCode_WithModifiers(TInput input);
  void Text_WithModifiers(TInput input);
  void Equality_WithModifiers(TInput input);
  void Inequality_WithModifiers(TInput input);
}
