using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseDualField(
  Parser<string>.DA aliases,
  Parser<IGqlpModifier>.DA modifiers,
  Parser<IGqlpObjBase>.D parseBase
) : ObjectFieldParser<IGqlpDualField, DualFieldAst>(aliases, modifiers, parseBase)
{
  
  protected override void ApplyFieldParams(DualFieldAst field, IGqlpInputParam[] parameters)
    => throw new InvalidOperationException();

  protected override DualFieldAst ObjField(TokenAt at, string name, string description, IGqlpObjBase typeBase)
    => new(at, name, description, typeBase);

  protected override IResult<IGqlpDualField> FieldDefault(ITokenizer tokens, DualFieldAst field)
    => field.Ok<IGqlpDualField>();

  protected override IResultArray<IGqlpInputParam> FieldParam(ITokenizer tokens)
    => 0.EmptyArray<IGqlpInputParam>();
}
