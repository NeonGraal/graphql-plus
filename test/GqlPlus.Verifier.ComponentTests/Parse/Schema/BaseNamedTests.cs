namespace GqlPlus.Verifier.Parse.Schema;

public abstract class BaseNamedTests<TInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(TInput input)
    => NameChecks.WithMinimum(input);

  [Theory, RepeatData(Repeats)]
  public void WithNameBad_ReturnsFalse(decimal id)
    => NameChecks.WithNameBad(id);

  internal abstract IBaseNamedChecks<TInput> NameChecks { get; }
}

internal abstract class BaseNamedChecks<TInput, TNamed>(
  Parser<TNamed>.D parser
) : OneChecksParser<TNamed>(parser), IBaseNamedChecks<TInput>
  where TNamed : AstNamed
{
  public void WithMinimum(TInput input)
  => TrueExpected(NameString(input), NamedFactory(input));

  public void WithNameBad(decimal id)
  => False($"{id}{{}}");

  protected internal abstract string NameString(TInput input);
  protected internal abstract TNamed NamedFactory(TInput input);
}

internal interface IBaseNamedChecks<TInput>
{
  void WithMinimum(TInput input);
  void WithNameBad(decimal id);
}
