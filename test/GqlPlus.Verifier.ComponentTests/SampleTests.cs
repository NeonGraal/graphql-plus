using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Parse;
using GqlPlus.Verifier.Parse.Operation;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;
using GqlPlus.Verifier.Verification;

namespace GqlPlus.Verifier;

[UsesVerify]
public class SampleTests(
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

    await Verify(errors.Select(e => $"{e}"), settings);
  }

  [Theory]
  [InlineData("error")]
  public async Task ParseSampleOperation(string sample)
  {
    var operation = File.ReadAllText("Sample/Operation_" + sample + ".gql+");
    OperationContext tokens = new(operation);
    var ast = _operation.Parse(tokens, "Operation").Optional();

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(SampleTests));
    settings.UseFileName("Operation_" + sample);

    await Verify(ast?.Render(), settings);
  }

  [Theory]
  [ClassData(typeof(SampleGraphQlData))]
  public async Task ParseSampleGraphQl(string example)
  {
    var operation = File.ReadAllText("Sample/GraphQl/Example_" + example + ".gql");
    OperationContext tokens = new(operation);
    var ast = _operation.Parse(tokens, "Operation").Required();

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(SampleTests) + "/ParseGraphQl");
    settings.UseFileName("Example_" + example);

    await Verify(ast.Render(), settings);
  }

  public class SampleSchemaData : TheoryData<string>
  {
    public SampleSchemaData()
    {
      Add("all");
      Add("default");
      Add("errors");
      Add("Intro_Schema");
      Add("Intro_Category");
      Add("Intro_Directive");
      Add("Intro_Setting");
      Add("Intro_Types");
      Add("Intro_Common");
      Add("Intro_Enum");
      Add("Intro_Object");
      Add("Intro_Input");
      Add("Intro_Output");
      Add("Intro_Scalar");
      Add("Intro_Complete");
    }
  }

  public class SampleGraphQlData : TheoryData<string>
  {
    private const string Examples = "003 005 006 007 008 009a 009b 010 012 013 014 016 018 019"
      + " 020 021 023 024 025 026 029 030 031 032";
    public SampleGraphQlData()
    {
      foreach (var example in Examples.Split()) {
        Add(example);
      }
    }
  }
}
