using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseInputField(
  Parser<string>.DA aliases,
  Parser<ModifierAst>.DA modifiers,
  Parser<InputReferenceAst>.D reference,
  Parser<IParserDefault, ConstantAst>.D defaultParser
) : ObjectFieldParser<InputFieldAst, InputReferenceAst>(aliases, modifiers, reference)
{
  private readonly Parser<IParserDefault, ConstantAst>.L _default = defaultParser;

  [ExcludeFromCodeCoverage]
  protected override void ApplyFieldParameters(InputFieldAst field, ParameterAst[] parameters)
    => throw new NotImplementedException();

  protected override InputFieldAst Field(TokenAt at, string name, string description, InputReferenceAst typeReference)
    => new(at, name, description, typeReference);

  protected override IResult<InputFieldAst> FieldDefault<TContext>(TContext tokens, InputFieldAst field)
    => _default.I.Parse(tokens, "Default").AsPartial(field, constant => field.Default = constant);

  protected override IResult<InputFieldAst> FieldEnumValue<TContext>(TContext tokens, InputFieldAst field)
    => tokens.Error("Input", "':'", field);

  protected override IResultArray<ParameterAst> FieldParameter<TContext>(TContext tokens)
    => 0.EmptyArray<ParameterAst>();

  protected override InputReferenceAst Reference(TokenAt at, string param, string description)
    => new(at, param, description);
}
