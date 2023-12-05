
using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Parse;
using GqlPlus.Verifier.Parse.Operation;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier;

[UsesVerify]
public class SampleTests(
    Parser<OperationAst>.D operation,
    Parser<SchemaAst>.D schema)
{
  private readonly Parser<OperationAst>.L _operation = operation;
  private readonly Parser<SchemaAst>.L _schema = schema;

  [Theory]
  [InlineData("all")]
  [InlineData("default")]
  [InlineData("errors")]
  [InlineData("Intro_Schema")]
  [InlineData("Intro_Category")]
  [InlineData("Intro_Directive")]
  [InlineData("Intro_Type")]
  [InlineData("Intro_Enum")]
  [InlineData("Intro_Input")]
  [InlineData("Intro_Output")]
  [InlineData("Intro_Scalar")]
  public async Task VerifySampleSchema(string sample)
  {
    var schema = File.ReadAllText("Sample/Schema/" + sample + ".graphql+");
    Tokenizer tokens = new(schema);

    var ast = _schema.Parse(tokens, "Schema").Required();

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(SampleTests) + "/Schema");
    settings.UseFileName(sample);

    await Verify(ast.Render(), settings);
  }

  [Theory]
  [InlineData("error")]
  public async Task VerifySampleOperation(string sample)
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
  [ClassData(typeof(GraphQlExamplesData))]
  public async Task VerifyGraphQlExample(string example)
  {
    var operation = File.ReadAllText("Sample/GraphQl/Example_" + example + ".gql");
    OperationContext tokens = new(operation);
    var ast = _operation.Parse(tokens, "Operation").Required();

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(SampleTests) + "/GraphQl");
    settings.UseFileName("Example_" + example);

    await Verify(ast.Render(), settings);
  }

  public class GraphQlExamplesData : TheoryData<string>
  {
    private const string Examples = "003 005 006 007 008 009a 009b 010 012 013 014 016 018 019"
      + " 020 021 023 024 025 026 029 030 031 032";
    public GraphQlExamplesData()
    {
      foreach (var example in Examples.Split()) {
        Add(example);
      }
    }
  }
}
