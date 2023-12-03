using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseOutput : ObjectParser<OutputAst, OutputFieldAst, OutputReferenceAst>
{
  private readonly IParserArray<ParameterAst> _parameter;

  public ParseOutput(
    Parser<ModifierAst>.DA modifiers,
    TypeName name,
    IParserArray<TypeParameterAst> param,
    IParserArray<string> aliases,
    IParser<NullAst> option,
    IParser<ObjectDefinition<OutputFieldAst, OutputReferenceAst>> definition,
    IParserArray<ParameterAst> parameter
  ) : base(modifiers, name, param, aliases, option, definition)
    => _parameter = parameter.ThrowIfNull();

  protected override string Label => "Output";

  protected override void ApplyDefinition(OutputAst result, ObjectDefinition<OutputFieldAst, OutputReferenceAst> value)
  {
    result.Extends = value.Extends;
    result.Fields = value.Fields;
    result.Alternates = value.Alternates;
  }

  protected override bool ApplyOption(OutputAst result, IResult<NullAst> option) => true;

  protected override void ApplyFieldParameters(OutputFieldAst field, ParameterAst[] parameters)
    => field.Parameters = parameters;

  protected override OutputFieldAst Field(TokenAt at, string name, string description, OutputReferenceAst typeReference)
    => new(at, name, description, typeReference);

  protected override IResult<OutputFieldAst> FieldDefault<TContext>(TContext tokens, OutputFieldAst field)
    => field.Ok();

  protected override IResult<OutputFieldAst> FieldEnumLabel<TContext>(TContext tokens, OutputFieldAst field)
  {
    if (tokens.Take('=')) {
      var at = tokens.At;

      if (!tokens.Identifier(out var label)) {
        return tokens.Error("Output", "label after '='", field);
      }

      if (!tokens.Take('.')) {
        field.Label = label;
        return field.Ok();
      }

      if (tokens.Identifier(out var value)) {
        field.Type = new OutputReferenceAst(at, label);
        field.Label = value;
        return field.Ok();
      }

      return tokens.Error("Output", "label after '.'", field);
    }

    return tokens.Error("Output", "':' or '='", field);
  }

  protected override IResultArray<ParameterAst> FieldParameter<TContext>(TContext tokens)
    => _parameter.Parse(tokens, Label);

  [return: NotNull]
  protected override OutputAst MakeResult(TokenAt at, string? name, string description)
    => new(at, name!, description);

  protected override OutputReferenceAst Reference(TokenAt at, string param)
    => new(at, param);

  protected override IResult<OutputReferenceAst> TypeEnumLabel<TContext>(TContext tokens, OutputReferenceAst reference)
  {
    if (tokens.Take('.')) {
      if (tokens.Identifier(out var label)) {
        reference.Label = label;
        return reference.Ok();
      }

      return tokens.Error("Output", "label after '.'", reference);
    }

    return reference.Ok();
  }
}

internal class ParseOutputDefinition : ParseObjectDefinition<OutputFieldAst, OutputReferenceAst>
{
  public ParseOutputDefinition(
    Func<IParser<OutputFieldAst>> field,
    Parser<ModifierAst>.DA modifiers,
    Func<IParser<OutputReferenceAst>> reference
  ) : base(field, modifiers, reference) { }

  protected override string Label => "Output";
}
