using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Parsing.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Globals;

internal class ParseDirective(
  IDirectiveName name,
  Parser<IGqlpInputParam>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<DirectiveOption>, DirectiveOption>.D option,
  Parser<DirectiveLocation>.D definition
) : DeclarationParser<IDirectiveName, IGqlpInputParam, DirectiveOption, DirectiveLocation, IGqlpSchemaDirective>(name, param, aliases, option, definition)
{
  protected override IGqlpSchemaDirective MakeResult(AstPartial<IGqlpInputParam, DirectiveOption> partial, DirectiveLocation value)
    => new DirectiveDeclAst(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      Params = partial.Params,
      Option = partial.Option ?? DirectiveOption.Unique,
      Locations = value,
    };

  protected override IGqlpSchemaDirective ToResult(AstPartial<IGqlpInputParam, DirectiveOption> partial)
    => new DirectiveDeclAst(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      Params = partial.Params,
      Option = partial.Option ?? DirectiveOption.Unique,
    };
}

internal class DirectiveName
  : IDirectiveName
{
  public bool ParseName(Tokenizer tokens, out string? name, out TokenAt at)
    => tokens.Prefix('@', out name, out at);
}

internal interface IDirectiveName
  : INameParser
{ }

internal class ParseDirectiveDefinition(
  Parser<IEnumParser<DirectiveLocation>, DirectiveLocation>.D location
) : Parser<DirectiveLocation>.I
{
  private readonly Parser<IEnumParser<DirectiveLocation>, DirectiveLocation>.L _location = location;

  public IResult<DirectiveLocation> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    DirectiveLocation locations = DirectiveLocation.None;

    while (!tokens.Take("}")) {
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
