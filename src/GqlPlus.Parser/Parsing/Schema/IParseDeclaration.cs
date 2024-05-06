using GqlPlus.Abstractions.Schema;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema;

internal interface IParseDeclaration
{
  string Selector { get; }
  IResult<IGqlpDeclaration> Parser(Tokenizer tokens, string label);
}

internal class ParseDeclaration<T>(
  string selector,
  Parser<T>.D declaration
) : IParseDeclaration
  where T : IGqlpDeclaration
{
  public string Selector { get; } = selector;

  public IResult<IGqlpDeclaration> Parser(Tokenizer tokens, string label)
    => _declaration.Parse(tokens, label).AsResult<IGqlpDeclaration>();

  private readonly Parser<T>.L _declaration = declaration;
}
