using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseSelection(
  IParserRepository parsers
) : Parser<IAstSelection>.I
{
  private readonly Parser<IAstDirective>.LA _directives = parsers.ArrayFor<IAstDirective>();
  private readonly Parser<IAstSelection>.LA _object = parsers.ArrayFor<IAstSelection>();

  public IResult<IAstSelection> Parse(ITokenizer tokens, string label)

  {
    if (tokens.Take("...") || tokens.Take('|')) {
      TokenAt at = tokens.At;
      string? onType = null;
      IResult<IAstSelection>? value = ParseTypeOrSpread(tokens, at, ref onType);
      if (value is not null) {
        return value;
      }

      IResultArray<IAstDirective> directives = _directives.Parse(tokens, "Inline");
      IResultArray<IAstSelection> selections = _object.Parse(tokens, "Object");
      if (selections.IsOk()) {
        return selections.Select(MakeInline(at, directives, onType));
      }

      return tokens.Error<IAstSelection>("Inline", "an object");
    }

    return default(IAstSelection).Empty();
  }

  private Func<IEnumerable<IAstSelection>, IAstSelection> MakeInline(TokenAt at, IResultArray<IAstDirective> directives, string? onType)
    => values => {
      InlineAst selection = new(at, [.. values]) {
        OnType = onType,
      };
      directives.Optional(directives => selection.Directives = [.. directives]);
      return selection;
    };

  private IResult<IAstSelection>? ParseTypeOrSpread(ITokenizer tokens, TokenAt at, ref string? onType)
  {
    if (tokens.Take("on") || tokens.Take(':')) {
      if (!tokens.Identifier(out onType)) {
        return tokens.Error<IAstSelection>("Spread", "a type");
      }
    } else {
      if (tokens.Identifier(out string? name)) {
        SpreadAst selection = new(at, name);
        _directives.Parse(tokens, "Spread").Optional(directives => selection.Directives = [.. directives]);

        if (tokens is IOperationContext context) {
          context.AddSpread(selection);
        }

        return selection.Ok<IAstSelection>();
      }
    }

    return null;
  }
}
