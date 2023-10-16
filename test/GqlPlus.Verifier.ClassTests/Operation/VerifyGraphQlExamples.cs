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
    public GraphQlExamplesData()
    {
      Add("003");
      Add("005");
    }
  }
}
