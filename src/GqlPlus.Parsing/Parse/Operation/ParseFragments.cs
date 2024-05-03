using GqlPlus.Ast;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Operation;

internal abstract class ParseFragments(
  Parser<DirectiveAst>.DA directives,
  Parser<IAstSelection>.DA objectParser
) : Parser<FragmentAst>.IA
{
  private readonly Parser<DirectiveAst>.LA _directives = directives;
  private readonly Parser<IAstSelection>.LA _object = objectParser;

  protected abstract bool FragmentPrefix<TContext>(ref TContext tokens)
    where TContext : Tokenizer;
  protected abstract bool TypePrefix<TContext>(ref TContext tokens)
    where TContext : Tokenizer;

  public IResultArray<FragmentAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    List<FragmentAst> definitions = [];

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

      IResultArray<DirectiveAst> directives = _directives.Parse(tokens, "Fragment");

      if (directives.IsError()) {
        return directives.AsResultArray(definitions);
      }

      IResultArray<IAstSelection> fields = _object.Parse(tokens, "Fragment");
      if (!fields.Required(NewFragment)) {
        return fields.AsResultArray(definitions);
      }

      void NewFragment(IAstSelection[] selections)
        => definitions.Add(
          new FragmentAst(at, name, onType, selections) {
            Directives = directives.Optional()
          });
    }

    return definitions.OkArray();
  }
}

internal class ParseStartFragments : ParseFragments, IParserStartFragments
{
  public ParseStartFragments(
    Parser<DirectiveAst>.DA directives,
    Parser<IAstSelection>.DA objectParser)
    : base(directives, objectParser) { }

  protected override bool FragmentPrefix<TContext>(ref TContext tokens)
    => tokens.Take('&');
  protected override bool TypePrefix<TContext>(ref TContext tokens)
    => tokens.Take(':');
}

internal class ParseEndFragments : ParseFragments, IParserEndFragments
{
  public ParseEndFragments(
    Parser<DirectiveAst>.DA directives,
    Parser<IAstSelection>.DA objectParser)
    : base(directives, objectParser) { }

  protected override bool FragmentPrefix<TContext>(ref TContext tokens)
    => tokens.Take("fragment") || tokens.Take('&');
  protected override bool TypePrefix<TContext>(ref TContext tokens)
    => tokens.Take("on") || tokens.Take(':');
}

public interface IParserStartFragments : Parser<FragmentAst>.IA { }

public interface IParserEndFragments : Parser<FragmentAst>.IA { }
