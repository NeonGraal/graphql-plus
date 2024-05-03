using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Operation;

internal abstract class ParseFragments(
  Parser<IGqlpDirective>.DA directives,
  Parser<IGqlpSelection>.DA objectParser
) : Parser<IGqlpFragment>.IA
{
  private readonly Parser<IGqlpDirective>.LA _directives = directives;
  private readonly Parser<IGqlpSelection>.LA _object = objectParser;

  protected abstract bool FragmentPrefix<TContext>(ref TContext tokens)
    where TContext : Tokenizer;
  protected abstract bool TypePrefix<TContext>(ref TContext tokens)
    where TContext : Tokenizer;

  public IResultArray<IGqlpFragment> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    List<IGqlpFragment> definitions = [];

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

      IResultArray<IGqlpDirective> directives = _directives.Parse(tokens, "Fragment");

      if (directives.IsError()) {
        return directives.AsResultArray(definitions);
      }

      IResultArray<IGqlpSelection> fields = _object.Parse(tokens, "Fragment");
      if (!fields.Required(NewFragment)) {
        return fields.AsResultArray(definitions);
      }

      void NewFragment(IEnumerable<IGqlpSelection> selections)
        => definitions.Add(
          new FragmentAst(at, name, onType, [.. selections]) {
            Directives = [.. directives.Optional()]
          });
    }

    return definitions.OkArray();
  }
}

internal class ParseStartFragments(
  Parser<IGqlpDirective>.DA directives,
  Parser<IGqlpSelection>.DA objectParser
) : ParseFragments(directives, objectParser), IParserStartFragments
{
  protected override bool FragmentPrefix<TContext>(ref TContext tokens)
    => tokens.Take('&');
  protected override bool TypePrefix<TContext>(ref TContext tokens)
    => tokens.Take(':');
}

internal class ParseEndFragments(
  Parser<IGqlpDirective>.DA directives,
  Parser<IGqlpSelection>.DA objectParser
) : ParseFragments(directives, objectParser), IParserEndFragments
{
  protected override bool FragmentPrefix<TContext>(ref TContext tokens)
    => tokens.Take("fragment") || tokens.Take('&');
  protected override bool TypePrefix<TContext>(ref TContext tokens)
    => tokens.Take("on") || tokens.Take(':');
}

public interface IParserStartFragments
  : Parser<IGqlpFragment>.IA
{ }

public interface IParserEndFragments
  : Parser<IGqlpFragment>.IA
{ }
