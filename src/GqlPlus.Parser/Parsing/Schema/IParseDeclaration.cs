using GqlPlus.Abstractions.Schema;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema;

internal interface IParseDeclaration
{
  string Selector { get; }
  IResult<IGqlpDeclaration> Parser(Tokenizer tokens, string label);
}

internal class ParseDeclaration<TObject>(
  IDeclarationSelector<TObject> selector,
  Parser<TObject>.D declaration
) : IParseDeclaration
  where TObject : IGqlpDeclaration
{
  public string Selector => selector.Selector;

  public IResult<IGqlpDeclaration> Parser(Tokenizer tokens, string label)
    => _declaration.Parse(tokens, label).AsResult<IGqlpDeclaration>();

  private readonly Parser<TObject>.L _declaration = declaration;
}

internal interface IDeclarationSelector<TObject>
  where TObject : IGqlpDeclaration
{
  string Selector { get; }
}

internal class DeclarationSelector<TObject>(
  string selector
) : IDeclarationSelector<TObject>
  where TObject : IGqlpDeclaration
{
  string IDeclarationSelector<TObject>.Selector => selector;
}
