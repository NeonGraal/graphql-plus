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

  public bool FieldDefault(InputFieldAst field)
  {
    if (_parser.ParseDefault(out var constant)) {
      field.Default = constant;
    }

    return true;
  }

  public bool FieldEnumLabel(InputFieldAst field) => false;

  public bool FieldParameter(out ParameterAst? parameter)
  {
    parameter = default;
    return false;
  }

  public bool TypeEnumLabel(InputReferenceAst reference) => true;
}
