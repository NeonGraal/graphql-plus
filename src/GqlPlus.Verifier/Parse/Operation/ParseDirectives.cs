using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

internal class ParseDirectives : IParserArray<DirectiveAst>
{
  private readonly IParserArgument _argument;

  public ParseDirectives(IParserArgument argument)
    => _argument = argument.ThrowIfNull();

  public IResultArray<DirectiveAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var result = new List<DirectiveAst>();

    if (!tokens.Prefix('@', out var name, out var at)) {
      return tokens.ErrorArray(label, "identifier after '@'", result);
    }

    while (name is not null) {
      var directive = new DirectiveAst(at, name);
      var argument = _argument.Parse(tokens);
      if (!argument.Required(value => directive.Argument = value)) {
        if (argument.IsError()) {
          return argument.AsResultArray(result);
        }
      }

      result.Add(directive);
      if (!tokens.Prefix('@', out name, out at)) {
        return tokens.PartialArray(label, "identifier after '@'", () => result);
      }
    }

    return result.OkArray();
  }
}
