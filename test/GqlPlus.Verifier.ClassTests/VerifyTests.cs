using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Parse;

namespace GqlPlus.Verifier;

[UsesVerify]
public class VerifyTests
{
  [Theory]
  [InlineData("default")]
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
    var operation = File.ReadAllText("Sample/Schema_" + sample + ".graphql+");
    Tokenizer tokenizer = new(operation);
    SchemaParser parser = new(tokenizer);
    SchemaAst ast = parser.Parse();

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(VerifyTests));
    settings.UseFileName(nameof(VerifySampleSchema) + "_" + sample);

    await Verify(ast.Render(), settings);
  }

  [Theory]
  [InlineData("error")]
  public async Task VerifySampleOperation(string sample)
  {
    var operation = File.ReadAllText("Sample/Operation_" + sample + ".gql+");
    Tokenizer tokenizer = new(operation);
    OperationParser parser = new(tokenizer);
    parser.Parse().Required(out var ast);

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(VerifyTests));
    settings.UseFileName(nameof(VerifySampleOperation) + "_" + sample);

    await Verify(ast!.Render(), settings);
  }

  [Theory]
  [ClassData(typeof(GraphQlExamplesData))]
  public async Task VerifyGraphQlExample(string example)
  {
    var operation = File.ReadAllText("GraphQl/Example_" + example + ".gql");
    Tokenizer tokenizer = new(operation);
    OperationParser parser = new(tokenizer);
    parser.Parse().Required(out var ast);

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(VerifyTests));
    settings.UseFileName(nameof(VerifyGraphQlExample) + "_" + example);

    await Verify(ast!.Render(), settings);
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
