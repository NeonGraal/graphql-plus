using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseOutputField(
  Parser<string>.DA aliases,
  Parser<IGqlpModifier>.DA modifiers,
  Parser<IGqlpOutputBase>.D objBase,
  Parser<InputParameterAst>.DA parameter
) : ObjectFieldParser<OutputFieldAst, IGqlpOutputBase>(aliases, modifiers, objBase)
{
  private readonly Parser<InputParameterAst>.LA _parameter = parameter;

  protected override void ApplyFieldParameters(OutputFieldAst field, InputParameterAst[] parameters)
    => field.Parameters = parameters;

  protected override OutputFieldAst ObjField(TokenAt at, string name, string description, IGqlpOutputBase typeBase)
    => new(at, name, description, typeBase);

  protected override IResult<OutputFieldAst> FieldDefault<TContext>(TContext tokens, OutputFieldAst field)
    => field.Ok();

  protected override IResult<OutputFieldAst> FieldEnumValue<TContext>(TContext tokens, OutputFieldAst field)
  {
    if (tokens.Take('=')) {
      tokens.String(out string? description);
      TokenAt at = tokens.At;

      if (!tokens.Identifier(out string? enumType)) {
        return tokens.Error("Output", "enum value after '='", field);
      }

      if (!tokens.Take('.')) {
        field.Type = new OutputBaseAst(at, "", description) { EnumValue = enumType };
        return field.Ok();
      }

      if (tokens.Identifier(out string? enumValue)) {
        field.Type = new OutputBaseAst(at, enumType, description) { EnumValue = enumValue };
        return field.Ok();
      }

      return tokens.Error("Output", "enum value after '.'", field);
    }

    return tokens.Error("Output", "':' or '='", field);
  }

  protected override IResultArray<InputParameterAst> FieldParameter<TContext>(TContext tokens)
    => _parameter.Parse(tokens, "Output");

  protected override OutputBaseAst ObjBase(TokenAt at, string param, string description)
    => new(at, param, description);
}
