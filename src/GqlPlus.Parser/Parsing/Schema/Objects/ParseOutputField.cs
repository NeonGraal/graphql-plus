using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseOutputField(
  Parser<string>.DA aliases,
  Parser<IGqlpModifier>.DA modifiers,
  Parser<IGqlpOutputBase>.D parseBase,
  Parser<IGqlpInputParam>.DA parameter
) : ObjectFieldParser<IGqlpOutputField, OutputFieldAst, IGqlpOutputBase>(aliases, modifiers, parseBase)
{
  private readonly Parser<IGqlpInputParam>.LA _parameter = parameter;

  protected override void ApplyFieldParams(OutputFieldAst field, IGqlpInputParam[] parameters)
    => field.Params = parameters;

  protected override OutputFieldAst ObjField(TokenAt at, string name, string description, IGqlpOutputBase typeBase)
    => new(at, name, description, typeBase);

  protected override IResult<IGqlpOutputField> FieldDefault(ITokenizer tokens, OutputFieldAst field)
    => field.Ok<IGqlpOutputField>();

  protected override IResult<IGqlpOutputField> FieldEnumValue(ITokenizer tokens, OutputFieldAst field)
  {
    if (tokens.Take('=')) {
      string description = tokens.Description();
      TokenAt at = tokens.At;
      if (!tokens.Identifier(out string? enumType)) {
        return tokens.Error<IGqlpOutputField>("Output", "enum value after '='", field);
      }

      if (!tokens.Take('.')) {
        field.BaseType = new OutputBaseAst(at, "", description);
        field.EnumLabel = enumType;
        return field.Ok<IGqlpOutputField>();
      }

      if (tokens.Identifier(out string? enumLabel)) {
        field.BaseType = new OutputBaseAst(at, enumType, description);
        field.EnumLabel = enumLabel;
        return field.Ok<IGqlpOutputField>();
      }

      return tokens.Error<IGqlpOutputField>("Output", "enum value after '.'", field);
    }

    return tokens.Error<IGqlpOutputField>("Output", "':' or '='", field);
  }

  protected override IResultArray<IGqlpInputParam> FieldParam(ITokenizer tokens)
    => _parameter.Parse(tokens, "Output");

  protected override IGqlpOutputBase ObjBase(TokenAt at, string param, string description)
    => new OutputBaseAst(at, param, description);
}
