//HintName: test_parent+Output_Impl.gen.cs
// Generated from parent+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_Output;

public class testPrntOutp
  : testRefPrntOutp
  , ItestPrntOutp
{
}

public class testRefPrntOutp
  : ItestRefPrntOutp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
