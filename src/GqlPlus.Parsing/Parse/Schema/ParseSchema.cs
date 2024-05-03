using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Schema;

internal class ParseSchema
  : Parser<SchemaAst>.I
{
  private delegate IResult<AstDeclaration> Parser(Tokenizer tokens, string label);
  private readonly Dictionary<string, Parser> _parsers = [];

  public ParseSchema(IEnumerable<IParseDeclaration> declarations)
  {
    foreach (IParseDeclaration declaration in declarations) {
      _parsers.Add(declaration.Selector, declaration.Parser);
    }
  }

  public IResult<SchemaAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    if (tokens.AtStart) {
      if (!tokens.Read()) {
        return tokens.Error<SchemaAst>(label, "text");
      }
    }

    TokenAt at = tokens.At;
    SchemaAst ast = new(at);

    List<AstDeclaration> declarations = [];

    tokens.String(out string? description);
    while (tokens.Identifier(out string? selector)) {
      if (_parsers.TryGetValue(selector, out Parser? parser)) {
        IResult<AstDeclaration> declaration = parser(tokens, selector.Capitalize());
        declaration.WithResult(d => declarations.Add(d with { Description = description }));
      } else {
        tokens.Error(label, $"declaration selector. '{selector}' unknown");
      }

      tokens.String(out description);
    }

    if (!tokens.AtEnd) {
      tokens.Error(label, "no more text");
    }

    if (tokens.Errors.Count == 0) {
      ast.Result = ParseResultKind.Success;
    }

    ast = ast with {
      Declarations = [.. declarations],
      Errors = tokens.Errors,
    };

    return ast.Ok();
  }
}
