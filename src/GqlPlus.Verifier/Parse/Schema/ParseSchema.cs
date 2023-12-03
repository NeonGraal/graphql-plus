using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseSchema : IParser<SchemaAst>
{

  private delegate IResult<AstDeclaration> Parser(Tokenizer tokens);
  private readonly Dictionary<string, Parser> _parsers = new();

  private static Parser MakeParser<T>(IParser<T> parser)
    => tokens => parser.Parse(tokens).AsResult<AstDeclaration>();

  public ParseSchema(
    IParser<CategoryAst> category,
    IParser<DirectiveAst> directive,
    IParser<EnumAst> enumParser,
    IParser<InputAst> input,
    IParser<OutputAst> output,
    IParser<ScalarAst> scalar)
  {
    _parsers.Add("category", MakeParser(category));
    _parsers.Add("directive", MakeParser(directive));
    _parsers.Add("enum", MakeParser(enumParser));
    _parsers.Add("input", MakeParser(input));
    _parsers.Add("output", MakeParser(output));
    _parsers.Add("scalar", MakeParser(scalar));
  }

  public IResult<SchemaAst> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    if (tokens.AtStart) {
      if (!tokens.Read()) {
        return tokens.Error<SchemaAst>("Schema", "text");
      }
    }

    var at = tokens.At;
    SchemaAst ast = new(at);

    var declarations = new List<AstDeclaration>();

    while (tokens.Identifier(out var selector)) {
      if (_parsers.TryGetValue(selector, out var parser)) {
        var declaration = parser(tokens);
        declaration.WithMessage(tokens.Errors.Add);
        declaration.WithResult(declarations.Add);
      } else {
        tokens.Error("Schema", $"declaration selector. '{selector}' unknown");
      }
    }

    if (!tokens.AtEnd) {
      tokens.Error("Schema", "no more text");
    }

    if (tokens.Errors.Count == 0) {
      ast.Result = ParseResultKind.Success;
    }

    ast = ast with {
      Declarations = declarations.ToArray(),
      Errors = tokens.Errors.ToArray(),
    };

    return ast.Ok();
  }
}
