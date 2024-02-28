using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal abstract class DeclarationParser<TName, TParam, TOption, TDefinition, TPartial, TResult>(
  TName name,
  Parser<TParam>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<TOption>, TOption>.D option,
  Parser<TDefinition>.D definition
) : Parser<TResult>.I
  where TName : INameParser
  where TPartial : AstAliased
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
    TPartial partial = MakePartial(at, name, description);

    if (!hasName) {
      return tokens.Error(label, "name", ToResult(partial));
    }

    var parameters = _param.Parse(tokens, label);
    if (!ApplyParameters(partial, parameters)) {
      return parameters.AsPartial(ToResult(partial));
    }

    var aliases = Aliases.Parse(tokens, label);
    if (!aliases.Optional(value => partial.Aliases = value)) {
      return aliases.AsPartial(ToResult(partial));
    }

    if (!tokens.Take('{')) {
      return tokens.Partial(label, "'{' before definition", () => ToResult(partial));
    }

    var option = _option.I.Parse(tokens, label);
    if (!ApplyOption(partial, option)) {
      return option.AsPartial(ToResult(partial));
    }

    var definition = _definition.Parse(tokens, label);
    return definition.MapOk(
      value => MakeResult(partial, value).Ok(),
      () => definition.AsPartial(ToResult(partial)));
  }

  protected abstract bool ApplyOption(TPartial partial, IResult<TOption> option);
  protected abstract bool ApplyParameters(TPartial partial, IResultArray<TParam> parameter);

  [return: NotNull]
  protected abstract TPartial MakePartial(TokenAt at, string? name, string description);

  [return: NotNull]
  protected abstract TResult MakeResult(TPartial result, TDefinition value);
  protected abstract TResult ToResult(TPartial partial);
}

internal interface INameParser
{
  bool ParseName(Tokenizer tokens, out string? name, out TokenAt at);
}

internal abstract class DeclarationParser<TName, TParam, TOption, TDefinition, TResult>(
  TName name,
  Parser<TParam>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<TOption>, TOption>.D option,
  Parser<TDefinition>.D definition
) : DeclarationParser<TName, TParam, TOption, TDefinition, TResult, TResult>(name, param, aliases, option, definition)
  where TName : INameParser
  where TResult : AstAliased
  where TOption : struct
{
  protected sealed override TResult ToResult(TResult partial) => partial;
}

internal abstract class DeclarationParser<TParam, TDefinition, TResult>(
  ISimpleName name,
  Parser<TParam>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<TDefinition>.D definition
) : DeclarationParser<ISimpleName, TParam, NullOption, TDefinition, TResult>(name, param, aliases, option, definition)
  where TResult : AstAliased
{
}

internal abstract class DeclarationParser<TDefinition, TResult>(
  ISimpleName name,
  Parser<NullAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<TDefinition>.D definition
) : DeclarationParser<NullAst, TDefinition, TResult>(name, param, aliases, option, definition)
  where TResult : AstAliased
{
}
