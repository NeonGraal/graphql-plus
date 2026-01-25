//HintName: test_parent+Output_Impl.gen.cs
// Generated from parent+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Output;

public class testPrntOutp
  : testRefPrntOutp
  , ItestPrntOutp
{
  public testPrntOutp PrntOutp { get; set; }
}

public class testRefPrntOutp
  : ItestRefPrntOutp
{
  public testNumber parent { get; set; }
  public testString AsString { get; set; }
  public testRefPrntOutp RefPrntOutp { get; set; }
}
