using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse.Common;

internal class ParseDefault : IParserDefault
{
  private readonly IParser<ConstantAst> _constant;

  public ParseDefault(IParser<ConstantAst> constant)
    => _constant = constant.ThrowIfNull();

  public IResult<ConstantAst> Parse(Tokenizer tokens)
    => tokens.Take('=') ? _constant.Parse(tokens).MapEmpty(
          () => tokens.Error<ConstantAst>("Default", "value after '='")
        ) : 0.Empty<ConstantAst>();
}

public interface IParserDefault : IParser<ConstantAst> { }
