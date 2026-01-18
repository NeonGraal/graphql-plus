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

  public IResult<IGqlpSelection> Parse(ITokenizer tokens, string label)

  {
    if (tokens.Take("...") || tokens.Take('|')) {
      TokenAt at = tokens.At;
      string? onType = null;
      IResult<IGqlpSelection>? value = ParseTypeOrSpread(tokens, at, ref onType);
      if (value is not null) {
        return value;
      }

      IResultArray<IGqlpDirective> directives = _directives.Parse(tokens, "Inline");
      IResultArray<IGqlpSelection> selections = _object.Parse(tokens, "Object");
      if (selections.IsOk()) {
        return selections.Select(MakeInline(at, directives, onType));
      }

      return tokens.Error<IGqlpSelection>("Inline", "an object");
    }

    return default(IGqlpSelection).Empty();
  }

  private Func<IEnumerable<IGqlpSelection>, IGqlpSelection> MakeInline(TokenAt at, IResultArray<IGqlpDirective> directives, string? onType)
    => values => {
      InlineAst selection = new(at, [.. values]) {
        OnType = onType,
      };
      directives.Optional(directives => selection.Directives = [.. directives]);
      return selection;
    };

  private IResult<IGqlpSelection>? ParseTypeOrSpread(ITokenizer tokens, TokenAt at, ref string? onType)
  {
    if (tokens.Take("on") || tokens.Take(':')) {
      if (!tokens.Identifier(out onType)) {
        return tokens.Error<IGqlpSelection>("Spread", "a type");
      }
    } else {
      if (tokens.Identifier(out string? name)) {
        SpreadAst selection = new(at, name);
        _directives.Parse(tokens, "Spread").Optional(directives => selection.Directives = [.. directives]);

        if (tokens is IOperationContext context) {
          context.AddSpread(selection);
        }

        return selection.Ok<IGqlpSelection>();
      }
    }

    return null;
  }
}
