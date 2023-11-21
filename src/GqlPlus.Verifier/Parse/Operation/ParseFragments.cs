using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

internal abstract class ParseFragments : IParserArray<FragmentAst>
{
  private readonly IParserArray<DirectiveAst> _directives;
  private readonly IParserArray<IAstSelection> _object;

  public ParseFragments(
    IParserArray<DirectiveAst> directives,
    IParserArray<IAstSelection> objectParser)
  {
    _directives = directives.ThrowIfNull();
    _object = objectParser.ThrowIfNull();
  }

  protected abstract bool FragmentPrefix<TContext>(ref TContext tokens)
    where TContext : Tokenizer;
  protected abstract bool TypePrefix<TContext>(ref TContext tokens)
    where TContext : Tokenizer;

  public IResultArray<FragmentAst> Parse<TContext>(TContext tokens)
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

      var directives = _directives.Parse(tokens);

      if (directives.IsError()) {
        return directives.AsResultArray(definitions);
      }

      var fields = _object.Parse(tokens);
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
    IParserArray<DirectiveAst> directives,
    IParserArray<IAstSelection> objectParser)
    : base(directives, objectParser) { }

  protected override bool FragmentPrefix<TContext>(ref TContext tokens)
    => tokens.Take('&');
  protected override bool TypePrefix<TContext>(ref TContext tokens)
    => tokens.Take(':');
}

internal class ParseEndFragments : ParseFragments, IParserEndFragments
{
  public ParseEndFragments(
    IParserArray<DirectiveAst> directives,
    IParserArray<IAstSelection> objectParser)
    : base(directives, objectParser) { }

  protected override bool FragmentPrefix<TContext>(ref TContext tokens)
    => tokens.Take("fragment") || tokens.Take('&');
  protected override bool TypePrefix<TContext>(ref TContext tokens)
    => tokens.Take("on") || tokens.Take(':');
}

public interface IParserStartFragments : IParserArray<FragmentAst> { }

public interface IParserEndFragments : IParserArray<FragmentAst> { }
