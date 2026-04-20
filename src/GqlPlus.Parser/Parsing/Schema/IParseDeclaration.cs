using GqlPlus.Ast.Schema;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema;

public interface IParseDeclaration
{
  string Selector { get; }
  IResult<IAstDeclaration> Parser(ITokenizer tokens, string label);
}

internal class ParseDeclaration<TObject>(
  string selector,
  IParserRepository parsers
) : IParseDeclaration
  where TObject : IAstDeclaration
{
  public string Selector => selector;

  public IResult<IAstDeclaration> Parser(ITokenizer tokens, string label)
    => _declaration.Parse(tokens, label).AsResult<IAstDeclaration>();

  private readonly Parser<TObject>.L _declaration = parsers.ParserFor<TObject>();
}
