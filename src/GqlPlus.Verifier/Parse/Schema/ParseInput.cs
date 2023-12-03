using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseInput : ObjectParser<InputAst, InputFieldAst, InputReferenceAst>
{
  private readonly IParserDefault _default;

  public ParseInput(
    Parser<ModifierAst>.DA modifiers,
    TypeName name,
    IParserArray<TypeParameterAst> param,
    IParserArray<string> aliases,
    IParser<NullAst> option,
    IParser<ObjectDefinition<InputFieldAst, InputReferenceAst>> definition,
    IParserDefault defaultParser
  ) : base(modifiers, name, param, aliases, option, definition)
    => _default = defaultParser.ThrowIfNull();

  protected override string Label => "Input";

  protected override void ApplyDefinition(InputAst result, ObjectDefinition<InputFieldAst, InputReferenceAst> value)
  {
    result.Extends = value.Extends;
    result.Fields = value.Fields;
    result.Alternates = value.Alternates;
  }

  protected override bool ApplyOption(InputAst result, IResult<NullAst> option) => true;

  protected override InputFieldAst Field(TokenAt at, string name, string description, InputReferenceAst typeReference)
    => new(at, name, description, typeReference);

  protected override IResult<InputFieldAst> FieldDefault<TContext>(TContext tokens, InputFieldAst field)
    => _default.Parse(tokens).AsPartial(field, constant => field.Default = constant);

  protected override IResult<InputFieldAst> FieldEnumLabel<TContext>(TContext tokens, InputFieldAst field)
    => tokens.Error("Input", "':'", field);

  protected override IResultArray<ParameterAst> FieldParameter<TContext>(TContext tokens) => 0.EmptyArray<ParameterAst>();

  [ExcludeFromCodeCoverage]
  protected override void ApplyFieldParameters(InputFieldAst field, ParameterAst[] parameters) => throw new NotImplementedException();

  [return: NotNull]
  protected override InputAst MakeResult(TokenAt at, string? name, string description)
    => new(at, name!, description);

  protected override InputReferenceAst Reference(TokenAt at, string param) => new(at, param);
  protected override IResult<InputReferenceAst> TypeEnumLabel<TContext>(TContext tokens, InputReferenceAst reference)
    => reference.Ok();
}

internal class ParseInputDefinition : ParseObjectDefinition<InputFieldAst, InputReferenceAst>
{
  public ParseInputDefinition(
    Func<IParser<InputFieldAst>> field,
    Parser<ModifierAst>.DA modifiers,
    Func<IParser<InputReferenceAst>> reference
  ) : base(field, modifiers, reference) { }

  protected override string Label => "Input";
}
