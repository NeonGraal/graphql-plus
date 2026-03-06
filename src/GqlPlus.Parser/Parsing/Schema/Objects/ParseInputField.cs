using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseInputField(
  IParserRepository parsers
) : ObjectFieldParser<IGqlpInputField, InputFieldAst>(
    parsers.GetArray<string>(),
    parsers.GetArray<IGqlpModifier>(),
    parsers.Get<IGqlpObjBase>())
{
  private readonly Parser<IParserDefault, IGqlpConstant>.L _default = parsers.GetInterface<IParserDefault, IGqlpConstant>();

  [ExcludeFromCodeCoverage]
  protected override void ApplyFieldParams(InputFieldAst field, IGqlpInputParam[] parameters)
    => throw new InvalidOperationException();

  protected override InputFieldAst ObjField(
    TokenAt at,
    string name,
    string description,
    IGqlpObjBase typeBase
  ) => new(at, name, description, typeBase);

  protected override IResult<IGqlpInputField> FieldDefault(ITokenizer tokens, InputFieldAst field)
    => _default.I
    .Parse(tokens, "Default")
    .AsPartial<IGqlpInputField>(field, constant => field.DefaultValue = constant);

  protected override IResultArray<IGqlpInputParam> FieldParam(ITokenizer tokens)
    => 0.EmptyArray<IGqlpInputParam>();
}
