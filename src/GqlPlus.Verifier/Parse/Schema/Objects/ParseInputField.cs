using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

internal class ParseInputField(
  Parser<string>.DA aliases,
  Parser<ModifierAst>.DA modifiers,
  Parser<InputBaseAst>.D objBase,
  Parser<IParserDefault, ConstantAst>.D defaultParser
) : ObjectFieldParser<InputFieldAst, InputBaseAst>(aliases, modifiers, objBase)
{
  private readonly Parser<IParserDefault, ConstantAst>.L _default = defaultParser;

  [ExcludeFromCodeCoverage]
  protected override void ApplyFieldParameters(InputFieldAst field, ParameterAst[] parameters)
    => throw new InvalidOperationException();

  protected override InputFieldAst ObjField(TokenAt at, string name, string description, InputBaseAst typeBase)
    => new(at, name, description, typeBase);

  protected override IResult<InputFieldAst> FieldDefault<TContext>(TContext tokens, InputFieldAst field)
    => _default.I.Parse(tokens, "Default").AsPartial(field, constant => field.Default = constant);

  protected override IResult<InputFieldAst> FieldEnumValue<TContext>(TContext tokens, InputFieldAst field)
    => tokens.Error("Input", "':'", field);

  protected override IResultArray<ParameterAst> FieldParameter<TContext>(TContext tokens)
    => 0.EmptyArray<ParameterAst>();

  protected override InputBaseAst ObjBase(TokenAt at, string param, string description)
    => new(at, param, description);
}
