using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseParameter : IParser<ParameterAst>
{
  private readonly IParser<InputReferenceAst> _input;
  private readonly IParserArray<ModifierAst> _modifiers;
  private readonly IParserDefault _default;

  public ParseParameter(
    IParser<InputReferenceAst> input,
    IParserArray<ModifierAst> modifiers,
    IParserDefault defaultParser)
  {
    _input = input.ThrowIfNull();
    _modifiers = modifiers.ThrowIfNull();
    _default = defaultParser.ThrowIfNull();
  }

  public IResult<ParameterAst> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    if (!tokens.Take('(')) {
      return default(ParameterAst).Empty();
    }

    tokens.String(out var descr);
    var at = tokens.At;
    var input = _input.Parse(tokens);
    if (!input.IsOk()) {
      return tokens.Error<ParameterAst>("Parameter", "input reference after '('");
    }

    var parameter = new ParameterAst(at, input.Required() with { Description = descr });
    var modifiers = _modifiers.Parse(tokens, "Parameter");

    if (modifiers.IsError()) {
      return modifiers.AsResult(parameter);
    }

    modifiers.Optional(value => parameter.Modifiers = value);

    var constant = _default.Parse(tokens);
    return constant.Optional(value => parameter.Default = value)
      ? tokens.Take(')')
        ? parameter.Ok()
        : tokens.Partial("Parameter", "')' at end", () => parameter)
      : constant.AsResult(parameter);
  }
}
