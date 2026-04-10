using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Parsing.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Globals;

internal class ParseDirective(
  IParserRepository parsers
) : DeclarationParser<IDirectiveName, IAstInputParam, DirectiveOption, DirectiveLocation, IAstSchemaDirective>(parsers)
{
  protected override IAstSchemaDirective MakeResult(AstPartial<IAstInputParam, DirectiveOption> partial, DirectiveLocation value)
    => new DirectiveDeclAst(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      Parameter = partial.Params.FirstOrDefault(),
      Option = partial.Option ?? DirectiveOption.Unique,
      Locations = value,
    };

  protected override IAstSchemaDirective ToResult(AstPartial<IAstInputParam, DirectiveOption> partial)
    => new DirectiveDeclAst(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      Parameter = partial.Params.FirstOrDefault(),
      Option = partial.Option ?? DirectiveOption.Unique,
    };
}

internal class DirectiveName
  : IDirectiveName
{
  public bool ParseName(ITokenizer tokens, [NotNullWhen(true)] out string? name, out TokenAt at)
    => tokens.Prefix('@', out name, out at);
}

internal interface IDirectiveName
  : INameParser
{ }

internal class ParseDirectiveDefinition(
  IParserRepository parsers
) : Parser<DirectiveLocation>.I
{
  private readonly Parser<IEnumParser<DirectiveLocation>, DirectiveLocation>.L _location = parsers.ParserFor<IEnumParser<DirectiveLocation>, DirectiveLocation>();

  public IResult<DirectiveLocation> Parse(ITokenizer tokens, string label)

  {
    DirectiveLocation locations = DirectiveLocation.None;

    while (!tokens.Take('}')) {
      IResult<DirectiveLocation> directiveLocation = _location.I.Parse(tokens, label);
      if (!directiveLocation.Required(value => locations |= value)) {
        return tokens.Partial(label, "location", () => locations);
      }
    }

    return locations == DirectiveLocation.None
      ? tokens.Partial(label, "at least one location", () => locations)
      : locations.Ok();
  }
}
