using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal abstract class DeclarationParser<TName, TParam, TOption, TDefinition, TResult>(
  TName name,
  Parser<TParam>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<TOption>, TOption>.D option,
  Parser<TDefinition>.D definition
) : Parser<TResult>.I
  where TName : INameParser
  where TResult : AstAliased
  where TOption : struct
{
  private readonly TName _name = name.ThrowIfNull();
  private readonly Parser<TParam>.LA _param = param;
  private readonly Parser<IOptionParser<TOption>, TOption>.L _option = option;
  private readonly Parser<TDefinition>.L _definition = definition;

  protected readonly Parser<string>.LA Aliases = aliases;

  public IResult<TResult> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    tokens.String(out var description);
    var hasName = _name.ParseName(tokens, out var name, out var at);
    TResult result = MakeResult(at, name, description);

    if (!hasName) {
      return tokens.Error(label, "name", result);
    }

    var parameters = _param.Parse(tokens, label);
    if (!ApplyParameters(result, parameters)) {
      return parameters.AsPartial(result);
    }

    var aliases = Aliases.Parse(tokens, label);
    if (!aliases.Optional(value => result.Aliases = value)) {
      return aliases.AsPartial(result);
    }

    if (!tokens.Take('{')) {
      return tokens.Partial(label, "'{' before definition", () => result);
    }

    var option = _option.I.Parse(tokens, label);
    if (!ApplyOption(result, option)) {
      return option.AsPartial(result);
    }

    var definition = _definition.Parse(tokens, label);
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
