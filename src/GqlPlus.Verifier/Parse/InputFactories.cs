using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse;

internal readonly struct InputFactories
  : IObjectFactories<InputAst, InputFieldAst, InputReferenceAst>
{
  private readonly SchemaParser _parser;

  public InputFactories(SchemaParser parser)
    => _parser = parser;

  public string Label => "Input";

  public void ApplyParameter(InputFieldAst result, ParameterAst? parameter) { }

  public InputFieldAst Field(ParseAt at, string name, string description, InputReferenceAst typeReference)
    => new(at, name, description, typeReference);

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

  public InputAst Object(ParseAt at, string name, string description)
    => new(at, name, description);

  public bool ParseEnumLabel(InputReferenceAst reference) => true;

  public InputReferenceAst Reference(ParseAt at, string name)
    => new(at, name);
}
