﻿using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseDirective(
  IDirectiveName name,
  Parser<ParameterAst>.DA param,
  Parser<string>.DA aliases,
  Parser<DirectiveOption>.D option,
  Parser<DirectiveLocation>.D definition
) : DeclarationParser<IDirectiveName, ParameterAst, DirectiveOption, DirectiveLocation, DirectiveDeclAst>(name, param, aliases, option, definition)
{
  protected override void ApplyDefinition(DirectiveDeclAst result, DirectiveLocation value)
    => result.Locations = value;

  protected override bool ApplyOption(DirectiveDeclAst result, IResult<DirectiveOption> option)
    => option.Optional(value => result.Option = value);

  protected override bool ApplyParameters(DirectiveDeclAst result, IResultArray<ParameterAst> parameter)
    => parameter.Optional(value => result.Parameters = value);

  [return: NotNull]
  protected override DirectiveDeclAst MakeResult(TokenAt at, string? name, string description)
    => new(at, name!, description);
}

internal class DirectiveName : IDirectiveName
{
  public bool ParseName(Tokenizer tokens, out string? name, out TokenAt at)
    => tokens.Prefix('@', out name, out at);
}

internal interface IDirectiveName : INameParser { }

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
