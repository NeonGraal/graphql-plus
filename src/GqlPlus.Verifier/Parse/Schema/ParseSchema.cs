using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseSchema : Parser<SchemaAst>.I
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

    var at = tokens.At;
    SchemaAst ast = new(at);

    var declarations = new List<AstDeclaration>();

    while (tokens.Identifier(out var selector)) {
      if (_parsers.TryGetValue(selector, out var parser)) {
        var declaration = parser(tokens, selector.Capitalize());
        declaration.WithResult(declarations.Add);
      } else {
        tokens.Error(label, $"declaration selector. '{selector}' unknown");
      }
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
