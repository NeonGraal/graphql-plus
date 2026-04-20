using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseOutputField(
  IParserRepository parsers
) : ObjectFieldParser<IAstOutputField, OutputFieldAst>(parsers)
{
  private readonly Parser<IAstInputParam>.LA _parameter = parsers.ArrayFor<IAstInputParam>();

  protected override void ApplyFieldParams(OutputFieldAst field, IAstInputParam[] parameters)
    => field.Parameter = parameters.FirstOrDefault();

  protected override OutputFieldAst ObjField(
    TokenAt at,
    string name,
    string description,
    IAstObjBase typeBase
  ) => new(at, name, description, typeBase);

  protected override IResult<IAstOutputField> FieldDefault(ITokenizer tokens, OutputFieldAst field)
    => field.Ok<IAstOutputField>();

  protected override IResultArray<IAstInputParam> FieldParam(ITokenizer tokens)
    => _parameter.Parse(tokens, "Output");
}
