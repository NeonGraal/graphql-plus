using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseDirective : DeclarationParser<DirectiveName, ParameterAst, DirectiveOption, DirectiveLocation, DirectiveAst>
{
  public ParseDirective(
    DirectiveName name,
    IParser<ParameterAst> param,
    IParserArray<string> aliases,
    IParser<DirectiveOption> option,
    IParser<DirectiveLocation> definition
  ) : base(name, param, aliases, option, definition) { }

  protected override string Label => "Directive";

  protected override void ApplyDefinition(DirectiveAst result, DirectiveLocation value)
    => result.Locations = value;

  protected override bool ApplyOption(DirectiveAst result, IResult<DirectiveOption> option)
    => option.Optional(value => result.Option = value);

  protected override bool ApplyParameter(DirectiveAst result, IResult<ParameterAst> parameter)
    => parameter.Optional(value => result.Parameter = value);

  [return: NotNull]
  protected override DirectiveAst MakeResult(ParseAt at, string? name, string description)
    => new(at, name!, description);
}

internal class DirectiveName : INameParser
{
  public bool ParseName(Tokenizer tokens, out string? name, out ParseAt at)
    => tokens.Prefix('@', out name, out at);
}

internal class ParseDirectiveOption : OptionParser<DirectiveOption>
{
  protected override string Label => "Directive";
}

internal class ParseDirectiveDefinition : IParser<DirectiveLocation>
{
  public IResult<DirectiveLocation> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    var locations = DirectiveLocation.None;

    while (!tokens.Take("}")) {
      var directiveLocation = tokens.ParseEnumValue<DirectiveLocation>("Directive");
      if (!directiveLocation.Required(location => locations |= location)) {
        return tokens.Partial("Directive", "location", () => locations);
      }
    }

    return locations == DirectiveLocation.None
      ? tokens.Partial("Directive", "at least one location", () => locations)
      : locations.Ok();
  }
}
