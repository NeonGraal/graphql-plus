using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseDualField(
  IParserRepository parsers
) : ObjectFieldParser<IGqlpDualField, DualFieldAst>(
    parsers.GetArray<string>(),
    parsers.GetArray<IGqlpModifier>(),
    parsers.Get<IGqlpObjBase>())
{
  [ExcludeFromCodeCoverage]
  protected override void ApplyFieldParams(DualFieldAst field, IGqlpInputParam[] parameters)
    => throw new InvalidOperationException();

  protected override DualFieldAst ObjField(
    TokenAt at,
    string name,
    string description,
    IGqlpObjBase typeBase
  ) => new(at, name, description, typeBase);

  protected override IResult<IGqlpDualField> FieldDefault(ITokenizer tokens, DualFieldAst field)
    => field.Ok<IGqlpDualField>();

  protected override IResultArray<IGqlpInputParam> FieldParam(ITokenizer tokens)
    => 0.EmptyArray<IGqlpInputParam>();
}
