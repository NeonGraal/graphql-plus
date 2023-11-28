using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseOutput : ObjectParser<OutputAst, OutputFieldAst, OutputReferenceAst>
{
  private readonly IParser<ParameterAst> _parameter;

  public ParseOutput(
    IParserArray<ModifierAst> modifiers,
    TypeName name,
    IParser<ObjectParameters> param,
    IParserArray<string> aliases,
    IParser<NullAst> option,
    IParser<ObjectDefinition<OutputFieldAst, OutputReferenceAst>> definition,
    IParser<ParameterAst> parameter
  ) : base(modifiers, name, param, aliases, option, definition)
    => _parameter = parameter.ThrowIfNull();

  protected override string Label => "Output";

  protected override bool ApplyDefinition(OutputAst result, IResult<ObjectDefinition<OutputFieldAst, OutputReferenceAst>> definition)
    => definition.Required(value => {
      result.Extends = value.Extends;
      result.Fields = value.Fields;
      result.Alternates = value.Alternates;
    });

  protected override bool ApplyOption(OutputAst result, IResult<NullAst> option) => true;

  protected override void ApplyParameter(OutputFieldAst field, ParameterAst? parameter)
    => field.Parameter = parameter;

  protected override OutputFieldAst Field(ParseAt at, string name, string description, OutputReferenceAst typeReference)
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

  protected override IResult<ParameterAst> FieldParameter<TContext>(TContext tokens)
    => _parameter.Parse(tokens);

  [return: NotNull]
  protected override OutputAst MakeResult(ParseAt at, string? name, string description)
    => new(at, name!, description);

  protected override OutputReferenceAst Reference(ParseAt at, string param)
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
    Func<IParserArray<ModifierAst>> modifiers,
    Func<IParser<OutputReferenceAst>> reference
  ) : base(field, modifiers, reference) { }

  protected override string Label => "Output";
}
