using GqlPlus.Abstractions.Schema;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema;

public interface IParseDeclaration
{
  string Selector { get; }
  IResult<IGqlpDeclaration> Parser(ITokenizer tokens, string label);
}

internal class ParseDeclaration<TObject>(
  string selector,
  IParserRepository parsers
) : IParseDeclaration
  where TObject : IGqlpDeclaration
{
  public string Selector => selector;

  public IResult<IGqlpDeclaration> Parser(ITokenizer tokens, string label)
    => _declaration.Parse(tokens, label).AsResult<IGqlpDeclaration>();

  private readonly Parser<TObject>.L _declaration = parsers.ParserFor<TObject>();
}
