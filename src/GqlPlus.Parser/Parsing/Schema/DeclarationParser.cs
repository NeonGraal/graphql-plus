using System.Net.Http.Headers;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema;

internal abstract class DeclarationParser<TName, TParam, TOption, TDefinition, TResult>(
  TName name,
  Parser<TParam>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<TOption>, TOption>.D option,
  Parser<TDefinition>.D definition
) : Parser<TResult>.I
  where TName : INameParser
  where TOption : struct
{
  private readonly TName _name = name.ThrowIfNull();
  private readonly Parser<TParam>.LA _param = param;
  private readonly Parser<IOptionParser<TOption>, TOption>.L _option = option;
  private readonly Parser<TDefinition>.L _definition = definition;

  protected readonly Parser<string>.LA Aliases = aliases;

  public IResult<TResult> Parse(ITokenizer tokens, string label)

  {
    string description = tokens.GetDescription();
    bool hasName = _name.ParseName(tokens, out string? name, out TokenAt? at);
    AstPartial<TParam, TOption> partial = new(at, name ?? "", description);

    if (!hasName) {
      return tokens.Error(label, "name", ToResult(partial));
    }

    IResultArray<TParam> parameters = _param.Parse(tokens, label);
    if (!parameters.Optional(value => partial.Params = [.. value ?? []])) {
      return parameters.AsPartial(ToResult(partial));
    }

    IResultArray<string> aliases = Aliases.Parse(tokens, label);
    if (!aliases.Optional(value => partial.Aliases = [.. value])) {
      return aliases.AsPartial(ToResult(partial));
    }

    if (!tokens.Take('{')) {
      return tokens.Partial(label, "'{' before definition", () => ToResult(partial));
    }

    IResult<TOption> option = _option.I.Parse(tokens, label);
    if (!option.Optional(value => partial.Option = value)) {
      return option.AsPartial(ToResult(partial));
    }

    IResult<TDefinition> definition = _definition.Parse(tokens, label);
    return definition.MapOk(value => AsResult(partial, value), NotOk);

    IResult<TResult> NotOk()
    {
      TokenMessage message = definition is IResultMessage messageResult
        ? messageResult.Message
        : tokens.Error(label, "definition");
      return ToResult(partial).Partial(message);
    }
  }

  protected virtual IResult<TResult> AsResult(AstPartial<TParam, TOption> partial, TDefinition value)
    => MakeResult(partial, value).Ok();

  [return: NotNull]
  protected abstract TResult MakeResult(AstPartial<TParam, TOption> partial, TDefinition value);
  protected abstract TResult ToResult(AstPartial<TParam, TOption> partial);
}

internal interface INameParser
{
  bool ParseName(ITokenizer tokens, [NotNullWhen(true)] out string? name, out TokenAt at);
}

internal abstract class DeclarationParser<TParam, TDefinition, TResult>(
  ISimpleName name,
  Parser<TParam>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<TDefinition>.D definition
) : DeclarationParser<ISimpleName, TParam, NullOption, TDefinition, TResult>(name, param, aliases, option, definition)
{ }

internal abstract class DeclarationParser<TDefinition, TResult>(
  ISimpleName name,
  Parser<NullAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<TDefinition>.D definition
) : DeclarationParser<NullAst, TDefinition, TResult>(name, param, aliases, option, definition)
{ }

internal record class AstPartial<TParam, TOption>(
  ITokenAt At,
  string Name,
  string Description
) : AstDeclaration(At, Name, Description)
  where TOption : struct
{
  internal override string Abbr => "Pa";
  public override string Label => "Partial";
  internal TOption? Option { get; set; }
  internal TParam[] Params { get; set; } = [];
}
