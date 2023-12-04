using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseDirective : DeclarationParser<DirectiveName, ParameterAst, DirectiveOption, DirectiveLocation, DirectiveAst>
{
  public ParseDirective(
    DirectiveName name,
    Parser<ParameterAst>.DA param,
    Parser<string>.DA aliases,
    Parser<DirectiveOption>.D option,
    Parser<DirectiveLocation>.D definition
  ) : base(name, param, aliases, option, definition) { }

  protected override string Label => "Directive";

  protected override void ApplyDefinition(DirectiveAst result, DirectiveLocation value)
    => result.Locations = value;

  protected override bool ApplyOption(DirectiveAst result, IResult<DirectiveOption> option)
    => option.Optional(value => result.Option = value);

  protected override bool ApplyParameters(DirectiveAst result, IResultArray<ParameterAst> parameter)
    => parameter.Optional(value => result.Parameters = value);

  [return: NotNull]
  protected override DirectiveAst MakeResult(TokenAt at, string? name, string description)
    => new(at, name!, description);
}

internal class DirectiveName : INameParser
{
  public bool ParseName(Tokenizer tokens, out string? name, out TokenAt at)
    => tokens.Prefix('@', out name, out at);
}

internal class ParseDirectiveDefinition : Parser<DirectiveLocation>.I
{
  public IResult<DirectiveLocation> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var locations = DirectiveLocation.None;

    while (!tokens.Take("}")) {
      var directiveLocation = tokens.ParseEnumValue<DirectiveLocation>(label);
      if (!directiveLocation.Required(location => locations |= location)) {
        return tokens.Partial(label, "location", () => locations);
      }
    }

    return locations == DirectiveLocation.None
      ? tokens.Partial(label, "at least one location", () => locations)
      : locations.Ok();
  }
}
