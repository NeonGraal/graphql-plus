using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse.Schema;

internal abstract class DeclarationParser<TName, TParam, TOption, TDefinition, TResult>
  : IParser<TResult>
  where TName : INameParser
  where TResult : AstAliased
{
  private readonly TName _name;
  private readonly IParser<TParam> _param;
  private readonly IParser<TOption> _option;
  private readonly IParser<TDefinition> _definition;

  protected abstract string Label { get; }

  public DeclarationParser(
    TName name,
    IParser<TParam> param,
    IParser<TOption> option,
    IParser<TDefinition> definition)
  {
    _name = name.ThrowIfNull();
    _param = param.ThrowIfNull();
    _option = option.ThrowIfNull();
    _definition = definition.ThrowIfNull();
  }

  public IResult<TResult> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    tokens.String(out var description);
    _name.ParseName(tokens, out var name, out var at);

    TResult result = MakeResult(at, name, description);

    var parameter = _param.Parse(tokens);
    if (!ApplyParameter(result, parameter)) {
      return parameter.AsPartial(result);
    }

    var aliases = ParseAliases(tokens);
    if (!aliases.Optional(value => result.Aliases = value)) {
      return aliases.AsPartial(result);
    }

    if (!tokens.Take('{')) {
      return tokens.Partial(Label, "'{' before definition", () => result);
    }

    var option = _option.Parse(tokens);
    if (!ApplyOption(result, option)) {
      return option.AsPartial(result);
    }

    var definition = _definition.Parse(tokens);
    return ApplyDefinition(result, definition)
      ? result.Ok()
      : definition.AsPartial(result);
  }

  protected abstract bool ApplyDefinition(TResult result, IResult<TDefinition> definition);
  protected abstract bool ApplyOption(TResult result, IResult<TOption> option);
  protected abstract bool ApplyParameter(TResult result, IResult<TParam> parameter);

  [return: NotNull]
  protected abstract TResult MakeResult(ParseAt at, string? name, string description);

  private IResultArray<string> ParseAliases(Tokenizer tokens)
  {
    var aliases = new List<string>();
    if (tokens.Take('[')) {
      while (tokens.Identifier(out var alias)) {
        aliases.Add(alias);
      }

      if (!tokens.Take("]")) {
        return tokens.PartialArray(Label, "']' to end aliases", () => aliases);
      } else if (aliases.Count == 0) {
        return tokens.ErrorArray(Label, "at least one alias after '['", aliases);
      }
    }

    return aliases.OkArray();
  }
}

internal interface INameParser
{
  bool ParseName(Tokenizer tokens, out string? name, out ParseAt at);
}
