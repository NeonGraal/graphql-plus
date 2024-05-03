using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Operation;

internal class ParseDirectives(
  Parser<IParserArgument, ArgumentAst>.D argument
) : Parser<DirectiveAst>.IA
{
  private readonly Parser<IParserArgument, ArgumentAst>.L _argument = argument;

  public IResultArray<DirectiveAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var result = new List<DirectiveAst>();

    if (!tokens.Prefix('@', out var name, out var at)) {
      return tokens.ErrorArray(label, "identifier after '@'", result);
    }

    while (name is not null) {
      var directive = new DirectiveAst(at, name);
      var argument = _argument.I.Parse(tokens, "Argument");
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
