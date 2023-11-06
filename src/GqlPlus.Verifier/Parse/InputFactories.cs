using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse;

internal class InputFactories
  : IObjectFactories<InputAst, InputFieldAst, InputReferenceAst>
{
  public string Label => "Input";

  public InputFieldAst Field(ParseAt at, string name, string description, InputReferenceAst typeReference)
    => new(at, name, description, typeReference);
  public InputFieldAst NullField()
    => new(AstNulls.At, "", NullReference());
  public InputAst Object(ParseAt at, string name, string description)
    => new(at, name, description);

  public InputReferenceAst Reference(ParseAt at, string name)
    => new(at, name);
  public InputReferenceAst NullReference()
    => new(AstNulls.At, "");
}

internal class InputParserFactories
  : InputFactories, IObjectParser<InputAst, InputFieldAst, InputReferenceAst>
{
  private readonly SchemaParser _parser;

  public InputParserFactories(SchemaParser parser)
    => _parser = parser;

  public void ApplyParameter(InputFieldAst result, ParameterAst? parameter) { }

  public IResult<InputFieldAst> FieldDefault(InputFieldAst field)
    => _parser.ParseDefault().AsPartial(field, constant => field.Default = constant);

  public IResult<InputFieldAst> FieldEnumLabel(InputFieldAst field)
    => field.Ok();

  public IResult<ParameterAst> FieldParameter()
    => new ResultEmpty<ParameterAst>();

  public IResult<InputReferenceAst> TypeEnumLabel(InputReferenceAst reference)
    => reference.Ok();
}
