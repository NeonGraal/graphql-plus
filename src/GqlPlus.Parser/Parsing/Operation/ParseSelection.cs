using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseSelection(
  IParserRepository parsers
) : IParser<IAstSelection>
{
  private readonly ParserArray<IAstModifier> _modifiers = parsers.ArrayFor<IAstModifier>();
  private readonly ParserArray<IAstDirective> _directives = parsers.ArrayFor<IAstDirective>();
  private readonly ParserArray<IAstSelection> _object = parsers.ArrayFor<IAstSelection>();

  public IResult<IAstSelection> Parse([NotNull] ITokenizer tokens, string label)

  {
    if (tokens.Take("...") || tokens.Take('|')) {
      TokenAt at = tokens.At;
      string? onType = null;
      IResult<IAstSelection>? value = ParseTypeOrSpread(tokens, at, ref onType);
      if (value is not null) {
        return value;
      }

      IResultArray<IAstModifier> modifiers = _modifiers.Parse(tokens, "Inline");
      if (modifiers.IsError()) {
        return modifiers.AsResult<IAstSelection>();
      }

      IResultArray<IAstDirective> directives = _directives.Parse(tokens, "Inline");
      if (directives.IsError()) {
        return directives.AsResult<IAstSelection>();
      }

      IResultArray<IAstSelection> selections = _object.Parse(tokens, "Object");
      if (selections.IsOk()) {
        return selections.Select(MakeInline(at, modifiers, directives, onType));
      }

      return tokens.Error<IAstSelection>("Inline", "an object");
    }

    return default(IAstSelection).Empty();
  }

  private Func<IEnumerable<IAstSelection>, IAstSelection> MakeInline(TokenAt at, IResultArray<IAstModifier> modifiers, IResultArray<IAstDirective> directives, string? onType)
    => values => {
      InlineAst selection = new(at, [.. values]) {
        OnType = onType,
      };
      modifiers.Optional(mods => selection.Modifiers = [.. mods]);
      directives.Optional(dirs => selection.Directives = [.. dirs]);
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
        IResultArray<IAstModifier> modifiers = _modifiers.Parse(tokens, "Spread");
        if (!modifiers.Optional(mods => selection.Modifiers = [.. mods])) {
          return modifiers.AsResult<IAstSelection>();
        }

        IResultArray<IAstDirective> directives = _directives.Parse(tokens, "Spread");
        if (!directives.Optional(dirs => selection.Directives = [.. dirs])) {
          return directives.AsResult<IAstSelection>();
        }

        if (tokens is IOperationContext context) {
          context.AddSpread(selection);
        }

        return selection.Ok<IAstSelection>();
      }
    }

    return null;
  }

  internal static ParseSelection Factory(IParserRepository p) => new(p);
}
