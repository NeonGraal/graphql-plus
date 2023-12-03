using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse.Schema;

internal abstract class DeclarationParser<TName, TParam, TOption, TDefinition, TResult>
  : IParser<TResult>
  where TName : INameParser
  where TResult : AstAliased
{
  private readonly TName _name;
  private readonly IParserArray<TParam> _param;
  private readonly IParser<TOption> _option;
  private readonly IParser<TDefinition> _definition;

  protected readonly IParserArray<string> Aliases;
  protected abstract string Label { get; }

  public DeclarationParser(
    TName name,
    IParserArray<TParam> param,
    IParserArray<string> aliases,
    IParser<TOption> option,
    IParser<TDefinition> definition)
  {
    _name = name.ThrowIfNull();
    _param = param.ThrowIfNull();
    Aliases = aliases.ThrowIfNull();
    _option = option.ThrowIfNull();
    _definition = definition.ThrowIfNull();
  }

  public IResult<TResult> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    tokens.String(out var description);
    var hasName = _name.ParseName(tokens, out var name, out var at);
    TResult result = MakeResult(at, name, description);

    if (!hasName) {
      return tokens.Error(Label, "name", result);
    }

    var parameters = _param.Parse(tokens, Label);
    if (!ApplyParameters(result, parameters)) {
      return parameters.AsPartial(result);
    }

    var aliases = Aliases.Parse(tokens, Label);
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
    return definition.Required(value => ApplyDefinition(result, value))
      ? result.Ok()
      : definition.AsPartial(result);
  }

  protected abstract void ApplyDefinition(TResult result, TDefinition value);
  protected abstract bool ApplyOption(TResult result, IResult<TOption> option);
  protected abstract bool ApplyParameters(TResult result, IResultArray<TParam> parameter);

  [return: NotNull]
  protected abstract TResult MakeResult(TokenAt at, string? name, string description);
}

internal interface INameParser
{
  bool ParseName(Tokenizer tokens, out string? name, out TokenAt at);
}
