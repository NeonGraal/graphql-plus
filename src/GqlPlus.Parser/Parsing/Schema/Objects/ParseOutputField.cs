using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseOutputField(
  Parser<string>.DA aliases,
  Parser<IGqlpModifier>.DA modifiers,
  Parser<IGqlpOutputBase>.D parseBase,
  Parser<InputParameterAst>.DA parameter
) : ObjectFieldParser<IGqlpOutputField, OutputFieldAst, IGqlpOutputBase>(aliases, modifiers, parseBase)
{
  private readonly Parser<InputParameterAst>.LA _parameter = parameter;

  protected override void ApplyFieldParameters(OutputFieldAst field, InputParameterAst[] parameters)
    => field.Parameters = parameters;

  protected override OutputFieldAst ObjField(TokenAt at, string name, string description, IGqlpOutputBase typeBase)
    => new(at, name, description, typeBase);

  protected override IResult<IGqlpOutputField> FieldDefault<TContext>(TContext tokens, OutputFieldAst field)
    => field.Ok<IGqlpOutputField>();

  protected override IResult<IGqlpOutputField> FieldEnumValue<TContext>(TContext tokens, OutputFieldAst field)
  {
    if (tokens.Take('=')) {
      tokens.String(out string? description);
      TokenAt at = tokens.At;

      if (!tokens.Identifier(out string? enumType)) {
        return tokens.Error<IGqlpOutputField>("Output", "enum value after '='", field);
      }

      if (!tokens.Take('.')) {
        field.BaseType = new OutputBaseAst(at, "", description) { EnumMember = enumType };
        return field.Ok<IGqlpOutputField>();
      }

      if (tokens.Identifier(out string? enumMember)) {
        field.BaseType = new OutputBaseAst(at, enumType, description) { EnumMember = enumMember };
        return field.Ok<IGqlpOutputField>();
      }

      return tokens.Error<IGqlpOutputField>("Output", "enum value after '.'", field);
    }

    return tokens.Error<IGqlpOutputField>("Output", "':' or '='", field);
  }

  protected override IResultArray<InputParameterAst> FieldParameter<TContext>(TContext tokens)
    => _parameter.Parse(tokens, "Output");

  protected override OutputBaseAst ObjBase(TokenAt at, string param, string description)
    => new(at, param, description);
}
