using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseOutputField : ObjectFieldParser<OutputFieldAst, OutputReferenceAst>
{
  private readonly Parser<ParameterAst>.LA _parameter;

  public ParseOutputField(
    Parser<string>.DA aliases,
    Parser<ModifierAst>.DA modifiers,
    Parser<OutputReferenceAst>.D reference,
    Parser<ParameterAst>.DA parameter
  ) : base(aliases, modifiers, reference)
    => _parameter = parameter;

  protected override void ApplyFieldParameters(OutputFieldAst field, ParameterAst[] parameters)
    => field.Parameters = parameters;

  protected override OutputFieldAst Field(TokenAt at, string name, string description, OutputReferenceAst typeReference)
    => new(at, name, description, typeReference);

  protected override IResult<OutputFieldAst> FieldDefault<TContext>(TContext tokens, OutputFieldAst field)
    => field.Ok();

  protected override IResult<OutputFieldAst> FieldEnumValue<TContext>(TContext tokens, OutputFieldAst field)
  {
    if (tokens.Take('=')) {
      var at = tokens.At;

      if (!tokens.Identifier(out var enumType)) {
        return tokens.Error("Output", "enum value after '='", field);
      }

      if (!tokens.Take('.')) {
        field.EnumValue = enumType;
        return field.Ok();
      }

      if (tokens.Identifier(out var enumValue)) {
        field.Type = new OutputReferenceAst(at, enumType);
        field.EnumValue = enumValue;
        return field.Ok();
      }

      return tokens.Error("Output", "enum value after '.'", field);
    }

    return tokens.Error("Output", "':' or '='", field);
  }

  protected override IResultArray<ParameterAst> FieldParameter<TContext>(TContext tokens)
    => _parameter.Parse(tokens, "Output");

  protected override OutputReferenceAst Reference(TokenAt at, string param)
    => new(at, param);
}
