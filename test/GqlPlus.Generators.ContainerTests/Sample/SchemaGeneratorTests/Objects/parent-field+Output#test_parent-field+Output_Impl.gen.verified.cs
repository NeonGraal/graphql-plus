//HintName: test_parent-field+Output_Impl.gen.cs
// Generated from parent-field+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Output;

public class testPrntFieldOutp
  : testRefPrntFieldOutp
  , ItestPrntFieldOutp
{
  public testNumber field { get; set; }
  public testPrntFieldOutp PrntFieldOutp { get; set; }
}

public class testRefPrntFieldOutp
  : ItestRefPrntFieldOutp
{
  public testNumber parent { get; set; }
  public testString AsString { get; set; }
  public testRefPrntFieldOutp RefPrntFieldOutp { get; set; }
}
