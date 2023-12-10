using System.Runtime.CompilerServices;

namespace GqlPlus.Verifier.Ast;

internal sealed class BaseNamedAstChecks<TAst>
  : BaseNamedAstChecks<string, TAst>, IBaseNamedAstChecks
  where TAst : AstBase
{
  public BaseNamedAstChecks(CreateBy<string> createInput,
    [CallerArgumentExpression(nameof(createInput))] string createExpression = "")
    : base(createInput, createExpression) { }
}

internal class BaseNamedAstChecks<TInput, TAst>
  : BaseAstChecks<TAst>, IBaseNamedAstChecks<TInput>
  where TAst : AstBase
{
  internal Func<TInput, TInput, bool> SameInput { get; init; }
    = (TInput input1, TInput input2) => input1!.Equals(input2);

  protected readonly CreateBy<TInput> CreateInput;
  protected readonly string Abbr;
  protected readonly string _createExpression;

  public BaseNamedAstChecks(CreateBy<TInput> createInput,
    [CallerArgumentExpression(nameof(createInput))] string createExpression = "")
    => (CreateInput, Abbr, _createExpression) = (createInput, createInput(default!).Abbr, createExpression);

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

  public string InputString(TInput input)
    => $"( !{Abbr} {input} )";
}

internal interface IBaseNamedAstChecks
  : IBaseNamedAstChecks<string>
{ }

internal interface IBaseNamedAstChecks<TInput>
{
  void HashCode(TInput input);
  void String(TInput input, string expected);
  void Equality(TInput input);
  void Inequality(TInput input1, TInput input2);
  string InputString(TInput input);
}
