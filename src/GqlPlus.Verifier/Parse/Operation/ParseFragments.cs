using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

internal abstract class ParseFragments : Parser<FragmentAst>.IA
{
  private readonly Parser<DirectiveAst>.LA _directives;
  private readonly Parser<IAstSelection>.LA _object;

  public ParseFragments(
    Parser<DirectiveAst>.DA directives,
    Parser<IAstSelection>.DA objectParser)
  {
    _directives = directives;
    _object = objectParser;
  }

  protected abstract bool FragmentPrefix<TContext>(ref TContext tokens)
    where TContext : Tokenizer;
  protected abstract bool TypePrefix<TContext>(ref TContext tokens)
    where TContext : Tokenizer;

  public IResultArray<FragmentAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var definitions = new List<FragmentAst>();

    while (FragmentPrefix(ref tokens)) {
      var at = tokens.At;
      if (!tokens.Identifier(out var name)) {
        return tokens.ErrorArray("Fragment", "name after 'fragment' or '&'", definitions);
      }

      if (!TypePrefix(ref tokens)) {
        return tokens.ErrorArray("Fragment", "':' or 'on' after fragment name", definitions);
      }

      if (!tokens.Identifier(out var onType)) {
        return tokens.ErrorArray("Fragment", "type after ':' or 'on'", definitions);
      }

      var directives = _directives.Parse(tokens, "Fragment");

      if (directives.IsError()) {
        return directives.AsResultArray(definitions);
      }

      var fields = _object.Parse(tokens, "Fragment");
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
