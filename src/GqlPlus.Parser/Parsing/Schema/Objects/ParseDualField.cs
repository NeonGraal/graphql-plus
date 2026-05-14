using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseDualField(
  IParserRepository parsers
) : ObjectFieldParser<IAstDualField, DualFieldAst>(parsers)
{
  [ExcludeFromCodeCoverage]
  protected override void ApplyFieldParams(DualFieldAst field, IAstInputParam[] parameters)
    => throw new InvalidOperationException();

  protected override DualFieldAst ObjField(
    TokenAt at,
    string name,
    string description,
    IAstObjBase typeBase
  ) => new(at, name, description, typeBase);

  protected override IResult<IAstDualField> FieldDefault(ITokenizer tokens, DualFieldAst field)
    => field.Ok<IAstDualField>();

  protected override IResultArray<IAstInputParam> FieldParam(ITokenizer tokens)
    => 0.EmptyArray<IAstInputParam>();

  internal static ParseDualField Factory(IParserRepository p) => new(p);
}
