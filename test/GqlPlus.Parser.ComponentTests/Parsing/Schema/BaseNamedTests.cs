namespace GqlPlus.Parsing.Schema;

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
) : BaseNamedChecks<TInput, TNamed, TNamed>(parser)
  where TNamed : AstNamed
{ }

internal abstract class BaseNamedChecks<TInput, TNamed, TSrc>(
  Parser<TSrc>.D parser
) : OneChecksParser<TSrc>(parser), IBaseNamedChecks<TInput>
  where TNamed : AstNamed, TSrc
  where TSrc : IGqlpNamed
{
  public void WithMinimum(TInput input)
  => TrueExpected(NameString(input), NamedFactory(input));

  public void WithNameBad(decimal id)
  => FalseExpected($"{id}{{}}");

  protected internal abstract string NameString(TInput input);
  protected internal abstract TNamed NamedFactory(TInput input);
}

internal interface IBaseNamedChecks<TInput>
{
  void WithMinimum(TInput input);
  void WithNameBad(decimal id);
}
