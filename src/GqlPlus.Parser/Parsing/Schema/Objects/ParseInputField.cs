using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseInputField(
  Parser<string>.DA aliases,
  Parser<IGqlpModifier>.DA modifiers,
  Parser<IGqlpObjBase>.D parseBase,
  Parser<IParserDefault, IGqlpConstant>.D defaultParser
) : ObjectFieldParser<IGqlpInputField, InputFieldAst>(aliases, modifiers, parseBase)
{
  private readonly Parser<IParserDefault, IGqlpConstant>.L _default = defaultParser;

  [ExcludeFromCodeCoverage]
  protected override void ApplyFieldParams(InputFieldAst field, IGqlpInputParam[] parameters)
    => throw new InvalidOperationException();

  protected override InputFieldAst ObjField(TokenAt at, string name, string description, IGqlpObjBase typeBase)
    => new(at, name, description, typeBase);

  protected override IResult<IGqlpInputField> FieldDefault(ITokenizer tokens, InputFieldAst field)
    => _default.I
    .Parse(tokens, "Default")
    .AsPartial<IGqlpInputField>(field, constant => field.DefaultValue = constant);

  protected override IResultArray<IGqlpInputParam> FieldParam(ITokenizer tokens)
    => 0.EmptyArray<IGqlpInputParam>();

  protected override IGqlpObjBase ObjBase(TokenAt at, string param, string description)
    => new ObjBaseAst(at, param, description);
}
