namespace GqlPlus.Parse.Schema;

public abstract class TestNamed<TInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(TInput input)
    => NameChecks.WithMinimum(input);

  [Theory, RepeatData(Repeats)]
  public void WithNameBad_ReturnsFalse(decimal id)
    => NameChecks.WithNameBad(id);

  internal abstract ICheckNamed<TInput> NameChecks { get; }
}

internal abstract class CheckNamed<TInput, TNamed>(
  Parser<TNamed>.D parser
) : OneChecksParser<TNamed>(parser), ICheckNamed<TInput>
  where TNamed : AstNamed
{
  public void WithMinimum(TInput input)
  => TrueExpected(NameString(input), NamedFactory(input));

  public void WithNameBad(decimal id)
  => False($"{id}{{}}");

  protected internal abstract string NameString(TInput input);
  protected internal abstract TNamed NamedFactory(TInput input);
}

internal interface ICheckNamed<TInput>
{
  void WithMinimum(TInput input);
  void WithNameBad(decimal id);
}
