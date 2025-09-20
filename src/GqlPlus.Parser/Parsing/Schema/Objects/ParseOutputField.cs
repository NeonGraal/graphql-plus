using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseOutputField(
  Parser<string>.DA aliases,
  Parser<IGqlpModifier>.DA modifiers,
  Parser<IGqlpObjBase>.D parseBase,
  Parser<IGqlpInputParam>.DA parameter
) : ObjectFieldParser<IGqlpOutputField, OutputFieldAst>(aliases, modifiers, parseBase)
{
  private readonly Parser<IGqlpInputParam>.LA _parameter = parameter;

  protected override void ApplyFieldParams(OutputFieldAst field, IGqlpInputParam[] parameters)
    => field.Params = parameters;

  protected override OutputFieldAst ObjField(TokenAt at, string name, string description, IGqlpObjBase typeBase)
    => new(at, name, description, typeBase);

  protected override IResult<IGqlpOutputField> FieldDefault(ITokenizer tokens, OutputFieldAst field)
    => field.Ok<IGqlpOutputField>();

  protected override IResultArray<IGqlpInputParam> FieldParam(ITokenizer tokens)
    => _parameter.Parse(tokens, "Output");

  protected override IGqlpObjBase ObjBase(TokenAt at, string param, string description)
    => new OutputBaseAst(at, param, description);
}
