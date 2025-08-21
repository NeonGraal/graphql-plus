using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseDualField(
  Parser<string>.DA aliases,
  Parser<IGqlpModifier>.DA modifiers,
  Parser<IGqlpDualBase>.D parseBase
) : ObjectFieldParser<IGqlpDualField, DualFieldAst, IGqlpDualBase>(aliases, modifiers, parseBase)
{
  [ExcludeFromCodeCoverage]
  protected override void ApplyFieldParams(DualFieldAst field, IGqlpInputParam[] parameters)
    => throw new InvalidOperationException();

  protected override DualFieldAst ObjField(TokenAt at, string name, string description, IGqlpDualBase typeBase)
    => new(at, name, description, typeBase);

  protected override IResult<IGqlpDualField> FieldDefault(ITokenizer tokens, DualFieldAst field)
    => field.Ok<IGqlpDualField>();

  protected override IResult<IGqlpDualField> FieldEnumValue(ITokenizer tokens, DualFieldAst field)
    => tokens.Partial<IGqlpDualField>("Dual", "':'", () => field);

  protected override IResultArray<IGqlpInputParam> FieldParam(ITokenizer tokens)
    => 0.EmptyArray<IGqlpInputParam>();

  protected override IGqlpDualBase ObjBase(TokenAt at, string param, string description)
    => new DualBaseAst(at, param, description);
}
