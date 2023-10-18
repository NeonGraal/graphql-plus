using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier;

[UsesVerify]
public class VerifyTests
{
  [Theory]
  [InlineData("Operation_error")]
  public async Task VerifySample(string sample)
  {
    var operation = File.ReadAllText("Sample/" + sample + ".gql+");
    Tokenizer tokenizer = new(operation);
    OperationParser parser = new(tokenizer);
    OperationAst ast = parser.Parse();

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(VerifyTests));
    settings.UseFileName(nameof(VerifySample) + "_" + sample);

    await Verify(ast.Render(), settings);
  }

  [Theory]
  [ClassData(typeof(GraphQlExamplesData))]
  public async Task VerifyGraphQlExample(string example)
  {
    var operation = File.ReadAllText("GraphQl/Example_" + example + ".gql");
    Tokenizer tokenizer = new(operation);
    OperationParser parser = new(tokenizer);
    OperationAst ast = parser.Parse();

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(VerifyTests));
    settings.UseFileName(nameof(VerifyGraphQlExample) + "_" + example);

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
