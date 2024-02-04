using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Parse;
using GqlPlus.Verifier.Parse.Operation;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;
using GqlPlus.Verifier.Verification;

namespace GqlPlus.Verifier;

public partial class SampleTests(
    Parser<OperationAst>.D operation,
    Parser<SchemaAst>.D schemaParser,
    IVerify<SchemaAst> schemaVerifier)
{
  private readonly Parser<OperationAst>.L _operation = operation;
  private readonly Parser<SchemaAst>.L _schemaParser = schemaParser;

  [Theory]
  [ClassData(typeof(SampleSchemaData))]
  public async Task ParseSampleSchema(string sample)
  {
    var schema = File.ReadAllText("Sample/Schema/" + sample + ".graphql+");
    Tokenizer tokens = new(schema);

    var ast = _schemaParser.Parse(tokens, "Schema").Required();

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(SampleTests) + "/ParseSchema");
    settings.UseFileName(sample);

    await Verify(ast.Render(), settings);
  }

  [Theory]
  [ClassData(typeof(SampleSchemaData))]
  public async Task VerifySampleSchema(string sample)
  {
    var schema = File.ReadAllText("Sample/Schema/" + sample + ".graphql+");
    Tokenizer tokens = new(schema);

    var ast = _schemaParser.Parse(tokens, "Schema").Required();
    var errors = new TokenMessages();

    schemaVerifier.Verify(ast, errors);

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(SampleTests) + "/VerifySchema");
    settings.UseFileName(sample);

    await Verify(errors.Select(e => $"{e}").Order().Distinct(), settings);
  }

  [Theory]
  [ClassData(typeof(SampleOperationData))]
  public async Task ParseSampleOperation(string sample)
  {
    var operation = File.ReadAllText("Sample/Operation/" + sample + ".gql+");
    OperationContext tokens = new(operation);
    var ast = _operation.Parse(tokens, "Operation").Optional();

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(SampleTests) + "/ParseOperation");
    settings.UseFileName(sample);

    await Verify(ast?.Render(), settings);
  }

  [Theory]
  [ClassData(typeof(SampleGraphQlData))]
  public async Task ParseSampleGraphQl(string example)
  {
    var operation = File.ReadAllText("Sample/GraphQl/" + example + ".gql");
    OperationContext tokens = new(operation);
    var ast = _operation.Parse(tokens, "Operation").Required();

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(SampleTests) + "/ParseGraphQl");
    settings.UseFileName(example);

    await Verify(ast.Render(), settings);
  }
}
