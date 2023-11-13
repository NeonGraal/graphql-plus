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

  public IResult<OutputFieldAst> FieldDefault(OutputFieldAst field)
    => field.Ok();

  public IResult<OutputFieldAst> FieldEnumLabel(OutputFieldAst field)
    => _parser.ParseOutputFieldLabel(field);

  public IResult<ParameterAst> FieldParameter()
    => _parser.ParseParameter();

  public void ApplyParameter(OutputFieldAst result, ParameterAst? parameter)
    => result.Parameter = parameter;

  public IResult<OutputReferenceAst> TypeEnumLabel(OutputReferenceAst reference)
    => _parser.ParseOutputEnumLabel(reference);
}
