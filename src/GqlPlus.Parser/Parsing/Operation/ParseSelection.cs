using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseSelection(
  Parser<IGqlpDirective>.DA directives,
  Parser<IGqlpSelection>.DA objectParser
) : Parser<IGqlpSelection>.I
{
  private readonly Parser<IGqlpDirective>.LA _directives = directives;
  private readonly Parser<IGqlpSelection>.LA _object = objectParser;

  public IResult<IGqlpSelection> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    if (tokens.Take("...") || tokens.Take('|')) {
      TokenAt at = tokens.At;
      string? onType = null;
      if (tokens.Take("on") || tokens.Take(':')) {
        if (!tokens.Identifier(out onType)) {
          return tokens.Error<IGqlpSelection>("Spread", "a type");
        }
      } else {
        if (tokens.Identifier(out string? name)) {
          SpreadAst selection = new(at, name);
          _directives.Parse(tokens, "Spread").Optional(directives => selection.Directives = [.. directives]);

          if (tokens is OperationContext context) {
            context.Spreads.Add(selection);
          }

          return selection.Ok<IGqlpSelection>();
        }
      }

      {
        IResultArray<IGqlpDirective> directives = _directives.Parse(tokens, "Inline");
        IResultArray<IGqlpSelection> selections = _object.Parse(tokens, "Object");
        if (selections.IsOk()) {
          return selections.Select(values => {
            InlineAst selection = new(at, [.. values]) {
              OnType = onType,
            };
            directives.Optional(directives => selection.Directives = [.. directives]);
            return selection as IGqlpSelection;
          });
        }
      }

      return tokens.Error<IGqlpSelection>("Inline", "an object");
    }

    return 0.Empty<IGqlpSelection>();
  }
}
