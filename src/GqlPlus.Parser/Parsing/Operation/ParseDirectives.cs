using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseDirectives(
  Parser<IParserArg, IGqlpArg>.D argument
) : Parser<IGqlpDirective>.IA
{
  private readonly Parser<IParserArg, IGqlpArg>.L _argument = argument;

  public IResultArray<IGqlpDirective> Parse(ITokenizer tokens, string label)

  {
    List<IGqlpDirective> result = [];

    if (!tokens.Prefix('@', out string? name, out TokenAt at)) {
      return tokens.ErrorArray(label, "identifier after '@'", result);
    }

    while (!name.IsWhiteSpace()) {
      DirectiveAst directive = new(at, name!);
      result.Add(directive);

      IResult<IGqlpArg> argument = _argument.I.Parse(tokens, "Arg");
      if (!argument.Required(value => directive.Arg = value)) {
        if (argument.IsError()) {
          return argument.AsResultArray(result);
        }
      }

      if (!tokens.Prefix('@', out name, out at)) {
        return tokens.PartialArray(label, "identifier after '@'", () => result);
      }
    }

    return result.OkArray();
  }
}
