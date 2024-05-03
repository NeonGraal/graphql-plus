using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Schema.Objects;

internal class ParseOutputField(
  Parser<string>.DA aliases,
  Parser<ModifierAst>.DA modifiers,
  Parser<OutputBaseAst>.D objBase,
  Parser<ParameterAst>.DA parameter
) : ObjectFieldParser<OutputFieldAst, OutputBaseAst>(aliases, modifiers, objBase)
{
  private readonly Parser<ParameterAst>.LA _parameter = parameter;

  protected override void ApplyFieldParameters(OutputFieldAst field, ParameterAst[] parameters)
    => field.Parameters = parameters;

  protected override OutputFieldAst ObjField(TokenAt at, string name, string description, OutputBaseAst typeBase)
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

  protected override IResultArray<ParameterAst> FieldParameter<TContext>(TContext tokens)
    => _parameter.Parse(tokens, "Output");

  protected override OutputBaseAst ObjBase(TokenAt at, string param, string description)
    => new(at, param, description);
}
