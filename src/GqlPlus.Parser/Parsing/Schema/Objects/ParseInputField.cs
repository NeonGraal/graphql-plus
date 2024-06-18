using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseInputField(
  Parser<string>.DA aliases,
  Parser<IGqlpModifier>.DA modifiers,
  Parser<IGqlpInputBase>.D parseBase,
  Parser<IParserDefault, IGqlpConstant>.D defaultParser
) : ObjectFieldParser<IGqlpInputField, InputFieldAst, IGqlpInputBase>(aliases, modifiers, parseBase)
{
  private readonly Parser<IParserDefault, IGqlpConstant>.L _default = defaultParser;

  protected override void ApplyFieldParameters(InputFieldAst field, InputParameterAst[] parameters)
    => throw new InvalidOperationException();

  protected override InputFieldAst ObjField(TokenAt at, string name, string description, IGqlpInputBase typeBase)
    => new(at, name, description, typeBase);

  protected override IResult<IGqlpInputField> FieldDefault<TContext>(TContext tokens, InputFieldAst field)
    => _default.I
    .Parse(tokens, "Default")
    .AsPartial<IGqlpInputField>(field, constant => field.DefaultValue = (ConstantAst?)constant);

  protected override IResult<IGqlpInputField> FieldEnumValue<TContext>(TContext tokens, InputFieldAst field)
    => tokens.Error<IGqlpInputField>("Input", "':'", field);

  protected override IResultArray<InputParameterAst> FieldParameter<TContext>(TContext tokens)
    => 0.EmptyArray<InputParameterAst>();

  protected override InputBaseAst ObjBase(TokenAt at, string param, string description)
    => new(at, param, description);
}
