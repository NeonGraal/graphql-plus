using GqlPlus.Ast.Schema;
using GqlPlus.Parsing.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema;

internal class ParseSchema(
  IParserRepository parsers
) : IParser<IAstSchema>
{
  private delegate IResult<IAstDeclaration> Parser(ITokenizer tokens, string label);
  private readonly DeferMap<Parser> _parsers = parsers.GetDeclarations()
    .ToMap<IParseDeclaration, Parser>(d => d.Selector, d => d.Parser);

  public IResult<IAstSchema> Parse([NotNull] ITokenizer tokens, string label)

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

  internal static ParseSchema Factory(IParserRepository p) => new(p);
}
