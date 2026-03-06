using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseOutputField(
  IParserRepository parsers
) : ObjectFieldParser<IGqlpOutputField, OutputFieldAst>(
    parsers.GetArray<string>(),
    parsers.GetArray<IGqlpModifier>(),
    parsers.Get<IGqlpObjBase>())
{
  private readonly Parser<IGqlpInputParam>.LA _parameter = parsers.GetArray<IGqlpInputParam>();

  protected override void ApplyFieldParams(OutputFieldAst field, IGqlpInputParam[] parameters)
    => field.Parameter = parameters.FirstOrDefault();

  protected override OutputFieldAst ObjField(
    TokenAt at,
    string name,
    string description,
    IGqlpObjBase typeBase
  ) => new(at, name, description, typeBase);

  protected override IResult<IGqlpOutputField> FieldDefault(ITokenizer tokens, OutputFieldAst field)
    => field.Ok<IGqlpOutputField>();

  protected override IResultArray<IGqlpInputParam> FieldParam(ITokenizer tokens)
    => _parameter.Parse(tokens, "Output");
}
