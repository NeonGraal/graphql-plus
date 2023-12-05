using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseSchema : Parser<SchemaAst>.I
{

  private delegate IResult<AstDeclaration> Parser(Tokenizer tokens, string label);
  private readonly Dictionary<string, Parser> _parsers = [];

  private static Parser MakeParser<T>(Parser<T>.L parser)
    => (tokens, label) => parser.Parse(tokens, label).AsResult<AstDeclaration>();

  public ParseSchema(
    Parser<CategoryAst>.D category,
    Parser<DirectiveAst>.D directive,
    Parser<EnumAst>.D enumParser,
    Parser<InputAst>.D input,
    Parser<OutputAst>.D output,
    Parser<ScalarAst>.D scalar)
  {
    _parsers.Add("category", MakeParser<CategoryAst>(category));
    _parsers.Add("directive", MakeParser<DirectiveAst>(directive));
    _parsers.Add("enum", MakeParser<EnumAst>(enumParser));
    _parsers.Add("input", MakeParser<InputAst>(input));
    _parsers.Add("output", MakeParser<OutputAst>(output));
    _parsers.Add("scalar", MakeParser<ScalarAst>(scalar));
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
        declaration.WithMessage(tokens.Errors.Add);
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
      Errors = [.. tokens.Errors],
    };

    return ast.Ok();
  }
}
