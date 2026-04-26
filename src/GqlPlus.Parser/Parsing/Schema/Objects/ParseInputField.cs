using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseInputField(
  IParserRepository parsers
) : ObjectFieldParser<IAstInputField, InputFieldAst>(parsers)
{
  private readonly Parser<IParserDefault, IAstConstant>.L _default = parsers.ParserFor<IParserDefault, IAstConstant>();

  [ExcludeFromCodeCoverage]
  protected override void ApplyFieldParams(InputFieldAst field, IAstInputParam[] parameters)
    => throw new InvalidOperationException();

  protected override InputFieldAst ObjField(
    TokenAt at,
    string name,
    string description,
    IAstObjBase typeBase
  ) => new(at, name, description, typeBase);

  protected override IResult<IAstInputField> FieldDefault(ITokenizer tokens, InputFieldAst field)
    => _default.I
    .Parse(tokens, "Default")
    .AsPartial<IAstInputField>(field, constant => field.DefaultValue = constant);

  protected override IResultArray<IAstInputParam> FieldParam(ITokenizer tokens)
    => 0.EmptyArray<IAstInputParam>();
}
