using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Parser.Schema;

public abstract class BaseNamedTests<TInput, TParsed>(
  IBaseNamedChecks<TInput, TParsed> nameChecks
) where TParsed : IAstNamed
{
  [Theory, RepeatData]
  public void WithMinimum_ReturnsCorrectAst(TInput input)
    => nameChecks.WithMinimum(input);

  [Theory, RepeatData]
  public void WithNameBad_ReturnsFalse(decimal id)
    => nameChecks.WithNameBad(id);
}

internal abstract class BaseNamedChecks<TInput, TNamed>(
  IParserRepository parsers
) : BaseNamedChecks<TInput, TNamed, TNamed>(parsers)
  where TNamed : AstNamed
{ }

internal abstract class BaseNamedChecks<TInput, TNamed, TParsed>(
  IParserRepository parsers
) : OneChecksParser<TParsed>(parsers)
  , IBaseNamedChecks<TInput, TParsed>
  where TNamed : AstNamed, TParsed
  where TParsed : IAstNamed
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
  where TParsed : IAstNamed
{
  void WithMinimum(TInput input);
  void WithNameBad(decimal id);
}
