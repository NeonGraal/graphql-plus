using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseDirectives(
  Parser<IParserArgument, IGqlpArgument>.D argument
) : Parser<IGqlpDirective>.IA
{
  private readonly Parser<IParserArgument, IGqlpArgument>.L _argument = argument;

  public IResultArray<IGqlpDirective> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    List<IGqlpDirective> result = [];

    if (!tokens.Prefix('@', out string? name, out TokenAt? at)) {
      return tokens.ErrorArray(label, "identifier after '@'", result);
    }

    while (name is not null) {
      DirectiveAst directive = new(at, name);
      IResult<IGqlpArgument> argument = _argument.I.Parse(tokens, "Argument");
      if (!argument.Required(value => directive.Argument = (ArgumentAst)value)) {
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
