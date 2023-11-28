﻿using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Parse.Common;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseInput : ObjectParser<InputAst, InputFieldAst, InputReferenceAst>
{
  private readonly IParserDefault _default;

  public ParseInput(
    IParserArray<ModifierAst> modifiers,
    TypeName name,
    IParser<ObjectParameters> param,
    IParserArray<string> aliases,
    IParser<NullAst> option,
    IParser<ObjectDefinition<InputFieldAst, InputReferenceAst>> definition,
    IParserDefault defaultParser
  ) : base(modifiers, name, param, aliases, option, definition)
    => _default = defaultParser.ThrowIfNull();

  protected override string Label => "Input";

  protected override bool ApplyDefinition(InputAst result, IResult<ObjectDefinition<InputFieldAst, InputReferenceAst>> definition)
    => definition.Required(value => {
      result.Extends = value.Extends;
      result.Fields = value.Fields;
      result.Alternates = value.Alternates;
    });

  protected override bool ApplyOption(InputAst result, IResult<NullAst> option) => true;
  protected override void ApplyParameter(InputFieldAst field, ParameterAst? parameter) => throw new NotImplementedException();

  protected override InputFieldAst Field(ParseAt at, string name, string description, InputReferenceAst typeReference)
    => new(at, name, description, typeReference);

  protected override IResult<InputFieldAst> FieldDefault<TContext>(TContext tokens, InputFieldAst field)
    => _default.Parse(tokens).AsPartial(field, constant => field.Default = constant);

  protected override IResult<InputFieldAst> FieldEnumLabel<TContext>(TContext tokens, InputFieldAst field)
    => tokens.Error("Input", "':'", field);

  protected override IResult<ParameterAst> FieldParameter<TContext>(TContext tokens) => 0.Empty<ParameterAst>();

  [return: NotNull]
  protected override InputAst MakeResult(ParseAt at, string? name, string description)
    => new(at, name!, description);

  protected override InputReferenceAst Reference(ParseAt at, string param) => new(at, param);
  protected override IResult<InputReferenceAst> TypeEnumLabel<TContext>(TContext tokens, InputReferenceAst reference)
    => reference.Ok();
}

internal class ParseInputDefinition : ParseObjectDefinition<InputFieldAst, InputReferenceAst>
{
  public ParseInputDefinition(
    Func<IParser<InputFieldAst>> field,
    Func<IParserArray<ModifierAst>> modifiers,
    Func<IParser<InputReferenceAst>> reference
  ) : base(field, modifiers, reference) { }

  protected override string Label => "Input";
}
