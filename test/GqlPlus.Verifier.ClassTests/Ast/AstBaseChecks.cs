using System.Runtime.CompilerServices;

namespace GqlPlus.Verifier.Ast;

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
    => (CreateInput, Abbr, _createExpression) = (createInput, createInput(default!).Abbr, createExpression);

  public string Abbr { get; }

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
  string Abbr { get; }
  void HashCode(TInput input);
  void String(TInput input, string expected);
  void Equality(TInput input);
  void Inequality(TInput input1, TInput input2);
}
