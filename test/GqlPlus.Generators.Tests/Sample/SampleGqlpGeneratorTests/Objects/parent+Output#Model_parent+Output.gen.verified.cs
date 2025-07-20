//HintName: Model_parent+Output.gen.cs
// Generated from parent+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_parent_Output;

public interface IPrntOutp
  : IRefPrntOutp
{
}
public class OutputPrntOutp
  : OutputRefPrntOutp
  , IPrntOutp
{
}

public interface IRefPrntOutp
{
  Number parent { get; }
  String AsString { get; }
}
public class OutputRefPrntOutp
  : IRefPrntOutp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
