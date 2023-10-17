using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

[UsesVerify]
public class VerifyGraphQlExamples
{
  [Theory]
  [ClassData(typeof(GraphQlExamplesData))]
  public Task VerifyExample(string example)
  {
    var operation = File.ReadAllText("GraphQl/Example_" + example + ".gql");
    Tokenizer tokenizer = new(operation);
    OperationParser parser = new(tokenizer);
    OperationAst ast = parser.Parse();

    var settings = new VerifySettings();
    settings.UseTextForParameters(example);
    settings.ScrubEmptyLines();

    return Verify(ast.Render(), settings);
  }

  public class GraphQlExamplesData : TheoryData<string>
  {
    private const string Examples = "003 005 006 007 008 009a 009b 010 012 013 014 016 018 019"
      + " 020 021 023 024";
    public GraphQlExamplesData()
    {
      foreach (var example in Examples.Split()) {
        Add(example);
      }
    }
  }
}
