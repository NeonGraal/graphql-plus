using GqlPlus.Ast.Operation;
using GqlPlus.Ast.Schema;
using GqlPlus.Modelling;
using GqlPlus.Parse;
using GqlPlus.Parse.Operation;
using GqlPlus.Rendering;
using GqlPlus.Result;
using GqlPlus.Token;
using GqlPlus.Verification;

namespace GqlPlus;

public class SampleTests(
    Parser<OperationAst>.D operation,
    Parser<SchemaAst>.D schemaParser,
    IVerify<SchemaAst> schemaVerifier,
    IModeller<SchemaAst, SchemaModel> schemaModeller,
    ITypesModeller types)
{
  private readonly Parser<OperationAst>.L _operation = operation;
  private readonly Parser<SchemaAst>.L _schemaParser = schemaParser;

  [Theory]
  [ClassData(typeof(SampleSchemaData))]
  public async Task ParseSampleSchema(string sample)
  {
    var schema = await File.ReadAllTextAsync("Sample/Schema/" + sample + ".graphql+");
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
  public async Task ModelSampleSchema(string sample)
  {
    var schema = await File.ReadAllTextAsync("Sample/Schema/" + sample + ".graphql+");
    Tokenizer tokens = new(schema);
    var ast = _schemaParser.Parse(tokens, "Schema").Required();

    var context = TypesCollection.WithBuiltins(types);

    var model = schemaModeller.ToModel(ast, context);
    context.AddModels(model.Types.Values);
    context.Errors.Clear();
    var result = model.Render(context);
    if (context.Errors.Count > 0) {
      result.Add("_errors", context.Errors.Render());
    }

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(SampleTests) + "/ModelSchema");
    settings.UseFileName(sample);

    await Verify(result.ToYaml(), settings);
  }

  [Theory]
  [ClassData(typeof(SampleSchemaData))]
  public async Task VerifySampleSchema(string sample)
  {
    var schema = await File.ReadAllTextAsync("Sample/Schema/" + sample + ".graphql+");
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
    var operation = await File.ReadAllTextAsync("Sample/Operation/" + sample + ".gql+");
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
    var operation = await File.ReadAllTextAsync("Sample/GraphQl/" + example + ".gql");
    OperationContext tokens = new(operation);
    var ast = _operation.Parse(tokens, "Operation").Required();

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(SampleTests) + "/ParseGraphQl");
    settings.UseFileName(example);

    await Verify(ast.Render(), settings);
  }
}
