using GqlPlus.Abstractions.Operation;
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
    Parser<IGqlpOperation>.D operation,
    Parser<SchemaAst>.D schemaParser,
    IVerify<SchemaAst> schemaVerifier,
    IModeller<SchemaAst, SchemaModel> schemaModeller,
    ITypesModeller types)
{
  private readonly Parser<IGqlpOperation>.L _operation = operation;
  private readonly Parser<SchemaAst>.L _schemaParser = schemaParser;

  [Theory]
  [ClassData(typeof(SampleSchemaData))]
  public async Task ParseSampleSchema(string sample)
  {
    string schema = await File.ReadAllTextAsync("Sample/Schema/" + sample + ".graphql+");
    Tokenizer tokens = new(schema);

    SchemaAst ast = _schemaParser.Parse(tokens, "Schema").Required();

    VerifySettings settings = new();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(SampleTests) + "/ParseSchema");
    settings.UseFileName(sample);

    await Verify(ast.Render(), settings);
  }

  [Theory]
  [ClassData(typeof(SampleSchemaData))]
  public async Task ModelSampleSchema(string sample)
  {
    string schema = await File.ReadAllTextAsync("Sample/Schema/" + sample + ".graphql+");
    Tokenizer tokens = new(schema);
    SchemaAst ast = _schemaParser.Parse(tokens, "Schema").Required();

    TypesCollection context = TypesCollection.WithBuiltins(types);

    SchemaModel model = schemaModeller.ToModel(ast, context);
    context.AddModels(model.Types.Values);
    context.Errors.Clear();
    RenderStructure result = model.Render(context);
    if (context.Errors.Count > 0) {
      result.Add("_errors", context.Errors.Render());
    }

    VerifySettings settings = new();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(SampleTests) + "/ModelSchema");
    settings.UseFileName(sample);

    await Verify(result.ToYaml(), settings);
  }

  [Theory]
  [ClassData(typeof(SampleSchemaData))]
  public async Task VerifySampleSchema(string sample)
  {
    string schema = await File.ReadAllTextAsync("Sample/Schema/" + sample + ".graphql+");
    Tokenizer tokens = new(schema);

    SchemaAst ast = _schemaParser.Parse(tokens, "Schema").Required();
    TokenMessages errors = [];

    schemaVerifier.Verify(ast, errors);

    VerifySettings settings = new();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(SampleTests) + "/VerifySchema");
    settings.UseFileName(sample);

    await Verify(errors.Select(e => $"{e}").Order().Distinct(), settings);
  }

  [Theory]
  [ClassData(typeof(SampleOperationData))]
  public async Task ParseSampleOperation(string sample)
  {
    string operation = await File.ReadAllTextAsync("Sample/Operation/" + sample + ".gql+");
    OperationContext tokens = new(operation);
    IGqlpOperation? ast = _operation.Parse(tokens, "Operation").Optional();

    VerifySettings settings = new();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(SampleTests) + "/ParseOperation");
    settings.UseFileName(sample);

    await Verify(ast?.Render(), settings);
  }

  [Theory]
  [ClassData(typeof(SampleGraphQlData))]
  public async Task ParseSampleGraphQl(string example)
  {
    string operation = await File.ReadAllTextAsync("Sample/GraphQl/" + example + ".gql");
    OperationContext tokens = new(operation);
    IGqlpOperation ast = _operation.Parse(tokens, "Operation").Required();

    VerifySettings settings = new();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(SampleTests) + "/ParseGraphQl");
    settings.UseFileName(example);

    await Verify(ast.Render(), settings);
  }
}
