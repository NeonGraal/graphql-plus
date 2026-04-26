using GqlPlus.Ast.Schema;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema;

internal class ParseSchema
  : Parser<IAstSchema>.I
{
  private delegate IResult<IAstDeclaration> Parser(ITokenizer tokens, string label);
  private readonly Dictionary<string, Parser> _parsers = [];

  public ParseSchema(IParserRepository parsers)
  {
    foreach (IParseDeclaration declaration in parsers.GetDeclarations()) {
      _parsers.Add(declaration.Selector, declaration.Parser);
    }
  }

  public IResult<IAstSchema> Parse(ITokenizer tokens, string label)

  {
    if (tokens.AtStart) {
      if (!tokens.Read()) {
        return tokens.Error<IAstSchema>(label, "text");
      }
    }

    TokenAt at = tokens.At;
    SchemaAst ast = new(at);

    List<IAstDeclaration> declarations = [];

    tokens.TakeDescription();
    while (tokens.Identifier(out string? selector)) {
      if (_parsers.TryGetValue(selector, out Parser? parser)) {
        IResult<IAstDeclaration> declaration = parser(tokens, selector.Capitalize());
        declaration.WithResult(declarations.Add);
      } else {
        tokens.GetDescription();
        tokens.Error<IAstSchema>(label, $"declaration selector. '{selector}' unknown");
      }

      tokens.TakeDescription();
    }

    if (!tokens.AtEnd) {
      tokens.Error<IAstSchema>(label, "no more text");
    }

    if (tokens.Errors.Count == 0) {
      ast.Result = ParseResultKind.Success;
    }

    ast = ast with {
      Declarations = declarations.ArrayOf<AstDeclaration>(),
      Errors = tokens.Errors,
    };

    return ast.Ok<IAstSchema>();
  }
}
