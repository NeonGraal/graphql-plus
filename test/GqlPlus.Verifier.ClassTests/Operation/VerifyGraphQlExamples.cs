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

    return Verify(ast.Render(), ".gql", settings);
  }

  public class GraphQlExamplesData : TheoryData<string>
  {
    public GraphQlExamplesData()
    {
      Add("003");
      Add("005");
      Add("006");
      Add("007");
      Add("008");
      Add("009a");
      Add("010");
      Add("011");
    }
  }
}
