using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema;

internal class ParseSchema
  : Parser<IGqlpSchema>.I
{
  private delegate IResult<IGqlpDeclaration> Parser(Tokenizer tokens, string label);
  private readonly Dictionary<string, Parser> _parsers = [];

  public ParseSchema(IEnumerable<IParseDeclaration> declarations)
  {
    foreach (IParseDeclaration declaration in declarations) {
      _parsers.Add(declaration.Selector, declaration.Parser);
    }
  }

  public IResult<IGqlpSchema> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    if (tokens.AtStart) {
      if (!tokens.Read()) {
        return tokens.Error<IGqlpSchema>(label, "text");
      }
    }

    TokenAt at = tokens.At;
    SchemaAst ast = new(at);

    List<IGqlpDeclaration> declarations = [];

    tokens.TakeDescription();
    while (tokens.Identifier(out string? selector)) {
      if (_parsers.TryGetValue(selector, out Parser? parser)) {
        IResult<IGqlpDeclaration> declaration = parser(tokens, selector.Capitalize());
        declaration.WithResult(declarations.Add);
      } else {
        tokens.GetDescription();
        tokens.Error(label, $"declaration selector. '{selector}' unknown");
      }

      tokens.TakeDescription();
    }

    if (!tokens.AtEnd) {
      tokens.Error(label, "no more text");
    }

    if (tokens.Errors.Count == 0) {
      ast.Result = ParseResultKind.Success;
    }

    ast = ast with {
      Declarations = declarations.ArrayOf<AstDeclaration>(),
      Errors = tokens.Errors,
    };

    return ast.Ok<IGqlpSchema>();
  }
}
