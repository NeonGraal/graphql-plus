using GqlPlus.Ast;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Operation;

internal class ParseSelection(
  Parser<DirectiveAst>.DA directives,
  Parser<IAstSelection>.DA objectParser
) : Parser<IAstSelection>.I
{
  private readonly Parser<DirectiveAst>.LA _directives = directives;
  private readonly Parser<IAstSelection>.LA _object = objectParser;

  public IResult<IAstSelection> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    if (tokens.Take("...") || tokens.Take('|')) {
      TokenAt at = tokens.At;
      string? onType = null;
      if (tokens.Take("on") || tokens.Take(':')) {
        if (!tokens.Identifier(out onType)) {
          return tokens.Error<IAstSelection>("Spread", "a type");
        }
      } else {
        if (tokens.Identifier(out string? name)) {
          SpreadAst selection = new(at, name);
          _directives.Parse(tokens, "Spread").Optional(directives => selection.Directives = directives);

          if (tokens is OperationContext context) {
            context.Spreads.Add(selection);
          }

          return selection.Ok<IAstSelection>();
        }
      }

      {
        IResultArray<DirectiveAst> directives = _directives.Parse(tokens, "Inline");
        IResultArray<IAstSelection> selections = _object.Parse(tokens, "Object");
        if (selections.IsOk()) {
          return selections.Select(values => {
            InlineAst selection = new(at, values) {
              OnType = onType,
            };
            directives.Optional(directives => selection.Directives = directives);
            return selection as IAstSelection;
          });
        }
      }

      return tokens.Error<IAstSelection>("Inline", "an object");
    }

    return AstNulls.Selection.Empty();
  }
}
