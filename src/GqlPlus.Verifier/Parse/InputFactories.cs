using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse;

internal class InputFactories
  : IObjectFactories<InputAst, InputFieldAst, InputReferenceAst>
{
  public string Label => "Input";

  public InputFieldAst Field(ParseAt at, string name, string description, InputReferenceAst typeReference)
    => new(at, name, description, typeReference);

  public InputAst Object(ParseAt at, string name, string description)
    => new(at, name, description);

  public InputReferenceAst Reference(ParseAt at, string name)
    => new(at, name);
}

internal class InputParserFactories
  : InputFactories, IObjectParser<InputAst, InputFieldAst, InputReferenceAst>
{
  private readonly SchemaParser _parser;

  public InputParserFactories(SchemaParser parser)
    => _parser = parser;

  [ExcludeFromCodeCoverage]
  public void ApplyParameter(InputFieldAst result, ParameterAst? parameter) { }

  public IResult<InputFieldAst> FieldDefault(InputFieldAst field)
    => _parser.ParseDefault().AsPartial(field, constant => field.Default = constant);

  [ExcludeFromCodeCoverage]
  public IResult<InputFieldAst> FieldEnumLabel(InputFieldAst field)
    => field.Ok();

  public IResult<ParameterAst> FieldParameter()
    => 0.Empty<ParameterAst>();

  public IResult<InputReferenceAst> TypeEnumLabel(InputReferenceAst reference)
    => reference.Ok();
}
