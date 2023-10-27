using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse;

internal class OutputFactories
  : IObjectFactories<OutputAst, OutputFieldAst, OutputReferenceAst>
{
  public string Label => "Output";

  public OutputFieldAst Field(ParseAt at, string name, string description, OutputReferenceAst typeReference)
    => new(at, name, description, typeReference);

  public OutputAst Object(ParseAt at, string name, string description)
    => new(at, name, description);

  public OutputReferenceAst Reference(ParseAt at, string name)
    => new(at, name);
}

internal class OutputParserFactories
  : OutputFactories, IObjectParser<OutputAst, OutputFieldAst, OutputReferenceAst>
{
  private readonly SchemaParser _parser;

  public OutputParserFactories(SchemaParser parser)
    => _parser = parser;

  public bool FieldDefault(OutputFieldAst field) => true;

  public bool FieldParameter(out ParameterAst? parameter)
    => _parser.ParseParameter(out parameter);

  public void ApplyParameter(OutputFieldAst result, ParameterAst? parameter)
    => result.Parameter = parameter;

  public bool ParseEnumLabel(OutputReferenceAst reference)
    => _parser.ParseOutputEnumLabel(reference);

  public bool FieldEnumLabel(OutputFieldAst field) =>
    //TODO 
    false;
}
