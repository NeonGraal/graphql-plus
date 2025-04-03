using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Parsing;

namespace GqlPlus.Schema;

public abstract class BaseNamedTests<TInput, TParsed>(
  IBaseNamedChecks<TInput, TParsed> nameChecks
) where TParsed : IGqlpNamed
{
  [Theory, RepeatData]
  public void WithMinimum_ReturnsCorrectAst(TInput input)
    => nameChecks.WithMinimum(input);

  [Theory, RepeatData]
  public void WithNameBad_ReturnsFalse(decimal id)
    => nameChecks.WithNameBad(id);
}

internal abstract class BaseNamedChecks<TInput, TNamed>(
  Parser<TNamed>.D parser
) : BaseNamedChecks<TInput, TNamed, TNamed>(parser)
  where TNamed : AstNamed
{ }

internal abstract class BaseNamedChecks<TInput, TNamed, TParsed>(
  Parser<TParsed>.D parser
) : OneChecksParser<TParsed>(parser)
  , IBaseNamedChecks<TInput, TParsed>
  where TNamed : AstNamed, TParsed
  where TParsed : IGqlpNamed
{
  public void WithMinimum(TInput input)
    => TrueExpected(NameString(input), NamedFactory(input));

  public void WithNameBad(decimal id)
    => FalseExpected($"{id}{{}}");

  protected internal abstract string NameString(TInput input);
  protected internal abstract TNamed NamedFactory(TInput input);
}

public interface IBaseNamedChecks<TInput, TParsed>
  : IOneChecksParser<TParsed>
  where TParsed : IGqlpNamed
{
  void WithMinimum(TInput input);
  void WithNameBad(decimal id);
}
