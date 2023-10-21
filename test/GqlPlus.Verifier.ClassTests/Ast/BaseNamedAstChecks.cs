using System.Runtime.CompilerServices;

namespace GqlPlus.Verifier.Ast;

internal sealed class BaseNamedAstChecks<T>
  : BaseNamedAstChecks<string, T>, IBaseNamedAstChecks
  where T : AstBase
{
  public BaseNamedAstChecks(CreateBy<string> createInput,
    [CallerArgumentExpression(nameof(createInput))] string createExpression = "")
    : base(createInput, createExpression) { }
}

internal class BaseNamedAstChecks<I, T>
  : BaseAstChecks<I, T>, IBaseNamedAstChecks<I>
  where T : AstBase
{
  internal Func<I, I, bool> SameInput { get; init; }
    = (I input1, I input2) => input1!.Equals(input2);

  protected readonly CreateBy<I> CreateInput;
  protected readonly string Abbr;
  protected readonly string _createExpression;

  public BaseNamedAstChecks(CreateBy<I> createInput,
    [CallerArgumentExpression(nameof(createInput))] string createExpression = "")
    => (CreateInput, Abbr, _createExpression) = (createInput, createInput(default!).Abbr, createExpression);

  public void HashCode(I input)
    => HashCode(
      () => CreateInput(input),
      _createExpression);

  public void String(I input, string expected)
    => String(
      () => CreateInput(input), expected,
      factoryExpression: _createExpression);

  public void Equality(I input)
    => Equality(
      () => CreateInput(input), _createExpression);

  public void Inequality(I input1, I input2)
    => InequalityBetween(input1, input2, CreateInput,
      SameInput(input1, input2), _createExpression);

  public void InequalityWith(I input, Creator factory,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
    => Inequality(factory,
      () => CreateInput(input),
      factoryExpression: factoryExpression);

  public string ExpectedString(I input)
    => $"( !{Abbr} {input} )";
}

internal interface IBaseNamedAstChecks
  : IBaseNamedAstChecks<string>
{ }

internal interface IBaseNamedAstChecks<I>
{
  void HashCode(I input);
  void String(I input, string expected);
  void Equality(I input);
  void Inequality(I input1, I input2);
  string ExpectedString(I input);
}
