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

  protected override void ApplyFieldParams(InputFieldAst field, IGqlpInputParam[] parameters)
    => throw new InvalidOperationException();

  protected override InputFieldAst ObjField(TokenAt at, string name, string description, IGqlpInputBase typeBase)
    => new(at, name, description, typeBase);

  protected override IResult<IGqlpInputField> FieldDefault(ITokenizer tokens, InputFieldAst field)
    => _default.I
    .Parse(tokens, "Default")
    .AsPartial<IGqlpInputField>(field, constant => field.DefaultValue = (ConstantAst?)constant);

  protected override IResult<IGqlpInputField> FieldEnumValue(ITokenizer tokens, InputFieldAst field)
    => tokens.Error<IGqlpInputField>("Input", "':'", field);

  protected override IResultArray<IGqlpInputParam> FieldParam(ITokenizer tokens)
    => 0.EmptyArray<IGqlpInputParam>();

  protected override IGqlpInputBase ObjBase(TokenAt at, string param, string description)
    => new InputBaseAst(at, param, description);
}
