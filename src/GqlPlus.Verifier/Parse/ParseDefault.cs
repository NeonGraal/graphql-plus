using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse;

internal class ParseDefault : IParserDefault
{
  private readonly Parser<ConstantAst>.L _constant;

  public ParseDefault(Parser<ConstantAst>.D constant)
    => _constant = constant;

  public IResult<ConstantAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
    => tokens.Take('=') ? _constant.Parse(tokens, "Default").MapEmpty(
          () => tokens.Error<ConstantAst>("Default", "value after '='")
        ) : 0.Empty<ConstantAst>();
}

public interface IParserDefault : Parser<ConstantAst>.I { }
