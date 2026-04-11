using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal abstract class ParseFragments(
  IParserRepository parsers
) : Parser<IAstFragment>.IA
{
  private readonly Parser<IAstDirective>.LA _directives = parsers.ArrayFor<IAstDirective>();
  private readonly Parser<IAstSelection>.LA _object = parsers.ArrayFor<IAstSelection>();

  protected abstract bool FragmentPrefix(ref ITokenizer tokens);
  protected abstract bool TypePrefix(ref ITokenizer tokens);

  public IResultArray<IAstFragment> Parse(ITokenizer tokens, string label)

  {
    List<IAstFragment> definitions = [];

    while (FragmentPrefix(ref tokens)) {
      TokenAt at = tokens.At;
      if (!tokens.Identifier(out string? name)) {
        return tokens.ErrorArray("Fragment", "name after 'fragment' or '&'", definitions);
      }

      if (!TypePrefix(ref tokens)) {
        return tokens.ErrorArray("Fragment", "':' or 'on' after fragment name", definitions);
      }

      if (!tokens.Identifier(out string? onType)) {
        return tokens.ErrorArray("Fragment", "type after ':' or 'on'", definitions);
      }

      IResultArray<IAstDirective> directives = _directives.Parse(tokens, "Fragment");

      if (directives.IsError()) {
        return directives.AsResultArray(definitions);
      }

      IResultArray<IAstSelection> fields = _object.Parse(tokens, "Fragment");
      if (!fields.Required(NewFragment)) {
        return fields.AsResultArray(definitions);
      }

      void NewFragment(IEnumerable<IAstSelection> selections)
        => definitions.Add(
          new FragmentAst(at, name, onType, [.. selections]) {
            Directives = [.. directives.Optional()]
          });
    }

    return definitions.OkArray();
  }
}

internal class ParseStartFragments(
  IParserRepository parsers
) : ParseFragments(parsers), IParserStartFragments
{
  protected override bool FragmentPrefix(ref ITokenizer tokens)
    => tokens.Take('&');
  protected override bool TypePrefix(ref ITokenizer tokens)
    => tokens.Take(':');
}

internal class ParseEndFragments(
  IParserRepository parsers
) : ParseFragments(parsers), IParserEndFragments
{
  protected override bool FragmentPrefix(ref ITokenizer tokens)
    => tokens.Take("fragment") || tokens.Take('&');
  protected override bool TypePrefix(ref ITokenizer tokens)
    => tokens.Take("on") || tokens.Take(':');
}

public interface IParserStartFragments
  : Parser<IAstFragment>.IA
{ }

public interface IParserEndFragments
  : Parser<IAstFragment>.IA
{ }
